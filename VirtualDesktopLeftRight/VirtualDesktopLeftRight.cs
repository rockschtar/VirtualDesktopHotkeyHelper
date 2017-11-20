using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualDesktopLeftRight {
    class VirtualDesktopLeftRight {
        static void Main(string[] args) {        
       
            if (args.Length > 0 && args[0].ToUpper() == Direction.RIGHT.ToString()) {
                VirtualDesktopHotkeyTrigger.Trigger.Right();

            } else {
                VirtualDesktopHotkeyTrigger.Trigger.Left();
            }


        }
    }
}
