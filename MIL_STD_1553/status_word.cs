using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL_STD_1553
{
    class status_word
    {
        public static string frame_status_word(int address, int message_error, int instrumentation, int service_request, int broadcast_cmd_received, int busy, int subsystem_flag, int dynamic_bus_acceptance, int terminal_flag)
        {
        Console.WriteLine("STATUS WORD");
        string status_word = Convert.ToString(address, 2).PadLeft(5, '0') + Convert.ToString(message_error, 2) + Convert.ToString(instrumentation, 2) + Convert.ToString(service_request, 2) + "000" + Convert.ToString(broadcast_cmd_received, 2) + Convert.ToString(busy, 2) + Convert.ToString(subsystem_flag, 2) + Convert.ToString(dynamic_bus_acceptance, 2) + Convert.ToString(terminal_flag, 2);
        int par2 = chk_valid.parity(status_word);
        status_word += Convert.ToString(Convert.ToInt32(par2), 2);
        string status_frame = "STA" + status_word;
        Console.WriteLine("PARITY1 = {0} PARITY2 = {1}", decode.par, par2);

        if (decode.par != par2)
            Console.WriteLine("Error: Calculated parity mismatch!");

        return status_frame;
        }
    }
}
