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
            string data_flow_typ = "";
            string address_typ = "";
            if (address == 0x1f)
                address_typ = " BROADCAST";
            if (tr == 1)
            {
                data_flow_typ = "transmit";
                Console.WriteLine("(MIL-STD-1553) This is a TRANSMIT{0} message addressed as 0x{1:X2}\n", address_typ, address);
            }
            else
            {
                Console.WriteLine("(MIL-STD-1553) This is a RECEIVE{0} message addressed as 0x{1:X2}", address_typ, address);
                data_flow_typ = "received";
            }
            if ((sub_address_mc == 0x1f) || (sub_address_mc == 0x00))
            {
                Console.WriteLine("(MIL-STD-1553) This frame contains a Mode Code Command");
                Console.WriteLine("(MIL-STD-1553) Mode Code to be performed: " + wc_mc);
                Console.WriteLine(mode_code.mode_code_typ(wc_mc));
                mode_code.mode_code_typ(wc_mc);
            }

            else
            {
                Console.WriteLine("(MIL-STD-1553) This frame elicts {0} data by a component within a subsystem\n", data_flow_typ);
                Console.WriteLine("(MIL-STD-1553) Subsystem Address: " + sub_address_mc);
                MIL_STD_1760E.nuclearwpns_address(sub_address_mc);
                if (wc_mc == 0)
                { 
                    Console.WriteLine("(MIL-STD-1553) 32 data word(s) will be {0}.\n", data_flow_typ);
                }
                else
                Console.WriteLine("(MIL-STD-1553) {0} data word(s) will be {1}.\n", wc_mc, data_flow_typ);
            }
            return 0;
        }
        public static int recv_trans_data_tracker()
        {
            string data_flow = "";
            if (cmd_word.last_cmd_dataflow == 1)
                data_flow = "transmit";
            else
                data_flow = "received";

            Console.WriteLine("DATA WORD {0} by Remote Terminal", data_flow);
            return 0;

        }
    }
}
