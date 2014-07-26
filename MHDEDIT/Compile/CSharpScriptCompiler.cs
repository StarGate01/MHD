#region Using statements

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

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

        public void CompileAndSave(ScriptFile m_currentFile)
        {
            CompilerParameters compilerParameters = new CompilerParameters();
            compilerParameters.GenerateExecutable = false;
            compilerParameters.GenerateInMemory = false;
            compilerParameters.IncludeDebugInformation = true;
            compilerParameters.OutputAssembly = "Level.dll";
            compilerParameters.ReferencedAssemblies.AddRange( m_currentFile.ReferencedAssemblies.ToArray());

            CompilerResults results = m_codeCompiler.CompileAssemblyFromSource(compilerParameters,  m_currentFile.ScriptContent);
            if (results.Errors.Count > 0)
            {
                StringBuilder compilerErrors = new StringBuilder();
                foreach (CompilerError actError in results.Errors) compilerErrors.Append(
                    "(" + actError.Line.ToString() + "," + actError.Column.ToString() + ")" + actError.ErrorText + Environment.NewLine
                );
                throw new InvalidOperationException("Unable to compile scripts: " + Environment.NewLine + compilerErrors.ToString());
            }
            else if (results.CompiledAssembly == null)
            {
                throw new InvalidOperationException("Unable to compile scripts:" + Environment.NewLine + "No result assembly from compiler!");
            }
        }

    }
}
