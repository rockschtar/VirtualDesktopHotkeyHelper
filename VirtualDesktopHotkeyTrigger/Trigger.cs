using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace VirtualDesktopHotkeyTrigger {
    public class Trigger {

        public static Trigger Instance;

        internal InputSimulator InputSimulator { get; set; }

        internal HashSet<VirtualKeyCode> Modifiers { get; set; }
    
        public Trigger() {
            this.InputSimulator = new InputSimulator();
            this.Modifiers = new HashSet<VirtualKeyCode>();

            this.Modifiers.Add(VirtualKeyCode.LWIN);
            this.Modifiers.Add(VirtualKeyCode.LCONTROL);
        }

        private static Trigger GetInstance() {

            if (Instance == null) {
                Instance = new Trigger();
            }

            return Instance;
        }


        public static void Left() {      
            GetInstance().InputSimulator.Keyboard.ModifiedKeyStroke(Instance.Modifiers, VirtualKeyCode.LEFT);       
        }

        public static void Right() {
            GetInstance().InputSimulator.Keyboard.ModifiedKeyStroke(Instance.Modifiers, VirtualKeyCode.RIGHT);       
        }

       




    }
}
