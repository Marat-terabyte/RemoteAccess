using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class CommandLineService
    {
        public string ExecuteCommand(string command)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c" + command;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            
            process.Start();
            
            if (command == "help")
                return process.StandardOutput.ReadToEnd();
            
            process.WaitForExit();

            if (process.ExitCode == 0)
                return process.StandardOutput.ReadToEnd();
            else
                return process.StandardError.ReadToEnd();
        }
    }
}
