using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL_STD_1553
{
    class cmd_word
    {
        public static string frame_cmd_word(int address, int tr, int sub_address_mc, int wc_mc)

        {
        string cmd_word = Convert.ToString(address, 2).PadLeft(5, '0') + Convert.ToString(Convert.ToInt32(tr), 2) + Convert.ToString(sub_address_mc, 2).PadLeft(5, '0') + Convert.ToString(wc_mc, 2).PadLeft(5, '0');
        int par = chk_valid.parity(cmd_word);
        cmd_word += Convert.ToString(Convert.ToInt32(par), 2);
        string cmd_frame = "PPP" + cmd_word;
        Console.WriteLine("PARITY = " + par);

        return cmd_frame;
        }
    }
}
