using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL_STD_1553
{
    class mode_code
    {
        public static string mode_code_typ(int mode_code)
        {
            string mode_desc = "";
            switch (mode_code)
            {
                case (0):
                    mode_desc = "Dynamic bus control";
                    break;
                case (1):
                    mode_desc = "Synchronize";
                    break;
                case (2):
                    mode_desc = "Transmit status word";
                    break;
                case (3):
                    mode_desc = "Initiate self-test";
                    break;
                case (4):
                    mode_desc = "Transmitter shutdown";
                    break;
                case (5):
                    mode_desc = "Override transmitter shutdown";
                    break;
                case (6):
                    mode_desc = "Inhibit terminal flag bit";
                    break;
                case (7):
                    mode_desc = "Override Inhibit Terminal Flag bit";
                    break;
                case (8):
                    mode_desc = "Reset";
                    break;
                case (9):
                    mode_desc = "RESERVED";
                    break;
                case (10):
                    mode_desc = "RESERVED";
                    break;
                case (11):
                    mode_desc = "RESERVED";
                    break;
                case (12):
                    mode_desc = "RESERVED";
                    break;
                case (13):
                    mode_desc = "RESERVED";
                    break;
                case (14):
                    mode_desc = "RESERVED";
                    break;
                case (15):
                    mode_desc = "RESERVED";
                    break;
                case (16):
                    mode_desc = "Transmit Vector Word";
                    break;
                case (17):
                    mode_desc = "Synchronize";
                    break;
                case (18):
                    mode_desc = "Transmit Last Command Word";
                    break;
                case (19):
                    mode_desc = "Transmit BIT Word";
                    break;
                case (20):
                    mode_desc = "Selected Transmitter Shutdown";
                    break;
                case (21):
                    mode_desc = "Override Selected Transmitter Shutdown";
                    break;
                case (22):
                    mode_desc = "RESERVED";
                    break;
                case (23):
                    mode_desc = "RESERVED";
                    break;
                case (24):
                    mode_desc = "RESERVED";
                    break;
                case (25):
                    mode_desc = "RESERVED";
                    break;
                case (26):
                    mode_desc = "RESERVED";
                    break;
                case (27):
                    mode_desc = "RESERVED";
                    break;
                case (28):
                    mode_desc = "RESERVED";
                    break;
                case (29):
                    mode_desc = "RESERVED";
                    break;
                case (30):
                    mode_desc = "RESERVED";
                    break;
                case (31):
                    mode_desc = "RESERVED";
                    break;
                default:
                    Console.WriteLine("(MIL-STD-1553) DEBUG: Bits 10 through 14 not a mode code. Expect {0} sebsequent data words\n", mode_code);
                    break;
            }
            return mode_desc;
        }
    }
}
