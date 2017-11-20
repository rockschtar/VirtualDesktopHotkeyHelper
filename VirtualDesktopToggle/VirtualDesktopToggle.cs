using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualDesktopToggle {
    class VirtualDesktopToggle {

        private static string ConfigName = "LastKeyCode";


        static void Main(string[] args) {
            var keycodeLeftRight = Direction.LEFT;


            if (GetLastKeyCode() == Direction.LEFT) {
                VirtualDesktopHotkeyTrigger.Trigger.Right();           
                keycodeLeftRight = Direction.RIGHT;
            } else {
                VirtualDesktopHotkeyTrigger.Trigger.Left();
            }

            SetLastKeyCode(keycodeLeftRight);
        }

        private static Direction GetLastKeyCode() {
            var appSettings = ConfigurationManager.AppSettings;
            var sepp = appSettings[ConfigName];
            String value = appSettings[ConfigName] ?? Direction.LEFT.ToString();
            return (Direction)Enum.Parse(typeof(Direction), value);
        }

        private static void SetLastKeyCode(Direction keycode) {

            try {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[ConfigName] == null) {
                    settings.Add(ConfigName, keycode.ToString());
                }
                else {
                    settings[ConfigName].Value = keycode.ToString();
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException) {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
