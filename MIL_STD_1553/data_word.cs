using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL_STD_1553
{
    class data_word
    {
        public static string frame_data_word(int data)
        {
            string data_word = Convert.ToString(Convert.ToInt32(data), 2).PadLeft(16, '0');
            int par = chk_valid.parity(data_word);
            string data_frame = "PPP" + data_word;
            data_frame += Convert.ToString(Convert.ToInt32(par), 2);
            Console.WriteLine("PARITY = " + par);
            return data_frame;
        }
    }
}
