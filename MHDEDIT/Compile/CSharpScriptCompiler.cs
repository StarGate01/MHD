#region Using statements

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;
using System.Resources;
using System.IO;

#endregion

namespace MHDEDIT.Compile
{

    public class CSharpScriptCompiler
    {

        private CodeDomProvider m_codeCompiler;

        public CSharpScriptCompiler()
        {
            Dictionary<string, string> compilerParameters = new Dictionary<string,string>();
            compilerParameters["CompilerVersion"] = "v4.0";
            m_codeCompiler = CSharpCodeProvider.CreateProvider("cs", compilerParameters);
        }

        public CompilerErrorCollection CompileAndSave(ScriptFile m_currentFile, string [] codePagePaths, string xmlRes, bool addpdb, string fileName)
        {
            CompilerErrorCollection resultErrors = new CompilerErrorCollection();
            CompilerParameters compilerParameters = new CompilerParameters();
            compilerParameters.GenerateExecutable = false;
            compilerParameters.GenerateInMemory = false;
            compilerParameters.IncludeDebugInformation = addpdb;
            compilerParameters.OutputAssembly = fileName;
            compilerParameters.ReferencedAssemblies.AddRange( m_currentFile.ReferencedAssemblies.ToArray());
            using (ResourceWriter writer = new ResourceWriter("resources.resx")) writer.AddResource("level.xml.gzip", MHD.Content.Level.Compression.Compress(System.IO.File.ReadAllBytes(xmlRes)));
            compilerParameters.EmbeddedResources.Add("resources.resx");
            CompilerResults results = m_codeCompiler.CompileAssemblyFromFile(compilerParameters, codePagePaths);
            if (results.Errors.Count > 0) resultErrors = results.Errors;
            else if (results.CompiledAssembly == null)
            {
                resultErrors.Add(new CompilerError("MHDEDIT", 0, 0, "0", "No result assembly from compiler!"));
            }
            File.Delete("resources.resx");
            return resultErrors;
        }

    }
}
