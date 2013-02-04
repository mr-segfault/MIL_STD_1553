using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL_STD_1553
{
    class cmd_word
    {
        public static int last_cmd_dataflow;
        public static string frame_cmd_word(int address, int tr, int sub_address_mc, int wc_mc)
        {
            if (tr == 1)
            { last_cmd_dataflow = 1; }
            else
            {
                last_cmd_dataflow = 0;
            }
        string cmd_word = Convert.ToString(address, 2).PadLeft(5, '0') + Convert.ToString(Convert.ToInt32(tr), 2) + Convert.ToString(sub_address_mc, 2).PadLeft(5, '0') + Convert.ToString(wc_mc, 2).PadLeft(5, '0');
        int par2 = chk_valid.parity(cmd_word);
        cmd_word += Convert.ToString(Convert.ToInt32(par2), 2);
        string cmd_frame = "CMD" + cmd_word;
        Console.WriteLine("PARITY1 = {0} PARITY2 = {1}", decode.par, par2);
        if (decode.par != par2)
            Console.WriteLine("Error: Calculated parity mismatch!");

        return cmd_frame;
        }
    }
}
