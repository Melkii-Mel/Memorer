using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorer.Src
{
    internal class AutorunHandler
    {
        public void Init()
        {
            const string FILE_PATH = @"..\..\..\Data\Data\Autorun.memorer";
            try
            {
                File.Open(FILE_PATH, FileMode.Open);
            }
            catch (FileNotFoundException)
            {
                SetAutorunValue(true);
                File.Create(FILE_PATH);
            }
            catch (IOException)
            {
                Application.Exit();
            }
        }
        private bool SetAutorunValue(bool autorun)
        {
            const string NAME = "Memorer";
            string ExePath = Application.ExecutablePath;
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                if (autorun)
                    reg.SetValue(NAME, ExePath);
                else
                    reg.DeleteValue(NAME);

                reg.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
