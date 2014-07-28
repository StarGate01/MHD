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

namespace MHDCOMPILE
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Starting MHDCOMPILE");
            try
            {
                if (args.Length != 5) throw new Exception("Invalid paramaters");
                string[] csFilesPaths = args[0].Split('|');
                string xmlFilePath = args[1];
                string[] references = args[2].Split('|');
                string targetFile = args[3];
                bool debug = Convert.ToBoolean(args[4]);
                Console.WriteLine("Configuration: ");
                Console.WriteLine(csFilesPaths.Length + " source files (" + references.Length + " referenced assemblies), 1 XML resource");
                Console.WriteLine("Generate debug file: " + debug.ToString());
                Dictionary<string, string> compilerParameters = new Dictionary<string, string>();
                compilerParameters["CompilerVersion"] = "v4.0";
                CodeDomProvider m_codeCompiler = CSharpCodeProvider.CreateProvider("cs", compilerParameters);
                CompilerParameters compileParameters = new CompilerParameters();
                compileParameters.GenerateExecutable = false;
                compileParameters.GenerateInMemory = false;
                compileParameters.IncludeDebugInformation = debug;
                compileParameters.OutputAssembly = targetFile;
                compileParameters.ReferencedAssemblies.AddRange(references);
                Console.WriteLine("Compressing resources ...");
                using (ResourceWriter writer = new ResourceWriter("resources.resx")) writer.AddResource("level.xml.gzip", MHD.Content.Level.Compression.Compress(System.IO.File.ReadAllBytes(xmlFilePath)));
                compileParameters.EmbeddedResources.Add("resources.resx");
                Console.WriteLine("Compiling scripts ...");
                Console.WriteLine("");
                System.Threading.Thread.Sleep(3000);
                CompilerResults results = m_codeCompiler.CompileAssemblyFromFile(compileParameters, csFilesPaths);
                CompilerErrorCollection resultErrors = new CompilerErrorCollection();
                if (results.Errors.Count > 0) resultErrors = results.Errors;
                File.Delete("resources.resx");
                foreach (CompilerError actError in resultErrors) Console.WriteLine("ERROR: " + actError.FileName.Substring(actError.FileName.LastIndexOf("\\") + 1) + " (" + actError.Line.ToString() + "," + actError.Column.ToString() + ") " + actError.ErrorText);
                if(resultErrors.Count == 0) Console.WriteLine("Build completed");
                m_codeCompiler.Dispose();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }

}
