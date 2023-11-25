using System.Text;
using System.Management;
using System.Runtime.Versioning;
using System.Security.Principal;

namespace Client
{
    [SupportedOSPlatform("windows")]
    internal class ComputerInformationManager
    {
        private readonly ManagementObjectSearcher _searcher;

        public ComputerInformationManager()
        {
            _searcher = new ManagementObjectSearcher();
        }

        public string GetMainInformation()
        {
            StringBuilder sb = new StringBuilder();
            
            /* Software */
            sb.Append($"User: {Environment.UserName}\n");
            sb.Append($"Is admin: {isUserAdmin()}\n");
            sb.Append($"Current directory: {Environment.CurrentDirectory}\n");
            
            /* Hardware */
            sb.Append("Processors:\n");
            sb.Append(GetComputerSysInformation("Win32_Processor", "Name"));
            sb.Append("Video controllers:\n");
            sb.Append(GetComputerSysInformation("Win32_VideoController", "Name"));
            sb.Append("Video controller driver versions:\n");
            sb.Append(GetComputerSysInformation("Win32_VideoController", "DriverVersion"));
            sb.Append("Drive letters:\n");
            sb.Append(GetComputerSysInformation("Win32_CDROMDrive", "Drive"));

            return sb.ToString();
        }

        public StringBuilder GetComputerSysInformation(string winClass, string propertyName)
        {
            StringBuilder sb = new StringBuilder();

            string query = $"SELECT * FROM {winClass}";
            _searcher.Query = new ObjectQuery(query);

            foreach (var item in _searcher.Get())
                sb.Append($"{item[propertyName].ToString()?.Trim()}\n");

            return sb;
        }

        public bool isUserAdmin()
        {
            bool isAdmin = false;

            using (var identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            return isAdmin;
        }
    }
}
