using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    [SupportedOSPlatform("windows")]
    internal class WinRegistryService
    {
        private RegistryKey _regKey;

        public string Name
        {
            get { return _regKey.Name; }
        }

        public string[] SubKeyNames
        {
            get { return _regKey.GetSubKeyNames(); }
        }

        public WinRegistryService()
        {
            _regKey = Registry.CurrentUser;
        }

        public WinRegistryService(RegistryKey key)
        {
            _regKey = key;
        }

        public RegistryKey CreateSubKey(string subKeyName)
        {
            return _regKey.CreateSubKey(subKeyName);
        }

        public void CreateKey(string subKey, string name, string value)
        {
            RegistryKey key = CreateSubKey(subKey);
            key.SetValue(name, value);
            key.Close();
        }

        public void DeleteKey(string subKey)
        {
            _regKey.DeleteSubKey(subKey);
        }

        public void DeleteValue(string name)
        {
            _regKey.DeleteValue(name);
        }
    }
}
