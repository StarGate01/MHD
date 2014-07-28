#region Using statements

using System;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

#endregion

namespace MHDEDIT.Compile
{

    public class ScriptCompiler
    {

        private static List<string> compilerStdout = new List<string>();

        public static List<string> CompileAndSave(ScriptFile m_currentFile, string[] codePagePaths, string xmlRes, bool addpdb, string fileName)
        {
            compilerStdout.Clear();
            ProcessStartInfo compilerParams = new ProcessStartInfo();
            if (File.Exists("MHDCOMPILE.exe")) compilerParams.FileName = "MHDCOMPILE.exe";
            else
            {
                compilerStdout.Add("MHDEDIT: No compiler found");
                return compilerStdout;
            }
            string codePagePathsParam = "";
            foreach(string codePagePath in codePagePaths) codePagePathsParam += codePagePath + "|";
            codePagePathsParam = codePagePathsParam.Substring(0, codePagePathsParam.Length - 1);
            string referencesParam = "";
            foreach(string reference in m_currentFile.ReferencedAssemblies) referencesParam += reference + "|";
            referencesParam = referencesParam.Substring(0, referencesParam.Length - 1);
            compilerParams.Arguments = "\"" + codePagePathsParam + "\" \"" + xmlRes + "\" \"" + referencesParam + "\" \"" + fileName + "\" " + addpdb.ToString();
            compilerParams.CreateNoWindow = true;
            compilerParams.RedirectStandardOutput = true;
            compilerParams.UseShellExecute = false;
            Process compiler = new Process();
            compiler.StartInfo = compilerParams;
            compiler.Start();
            while (!compiler.StandardOutput.EndOfStream)
            {
                string line = compiler.StandardOutput.ReadLine();
                compilerStdout.Add(line);
            }
            return compilerStdout;
        }

    }
}
