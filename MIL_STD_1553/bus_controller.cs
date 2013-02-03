using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL_STD_1553
{
    class bus_controller
    {
        public static int message_address(int address, int sub_address_mc, int wc_mc, int tr)
        {
            string address_typ = "";
            if (address == 0x1f)
                address_typ = " BROADCAST";
            if (tr == 1)
                Console.WriteLine("\nThis is a TRANSMIT{0} message addressed to 0x{1:X2}\n", address_typ, address);
            else
                Console.WriteLine("\nThis is a RECEIVE{0} message addressed to 0x{1:X2}\n", address_typ, address);

            if ((sub_address_mc == 0x1f) || (sub_address_mc == 0x00))
            {
                Console.WriteLine("\nThis frame contains a Mode Code Command\n");
                Console.WriteLine("\nMode Code to be performed: " + wc_mc);
                Console.WriteLine(mode_code.mode_code_typ(wc_mc));
                mode_code.mode_code_typ(wc_mc);
            }

            else
            {
                Console.WriteLine("\nThis frame is addressed to a component within the subsystem\n");
                Console.WriteLine("Address: " + sub_address_mc);
                Console.WriteLine("Or, it indicates the subsequent transmittal of {0} data words.\n", wc_mc);
            }
            return 0;
        }
    }
}
