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
            Console.WriteLine("DATA WORD");
            string data_word = Convert.ToString(Convert.ToInt32(data), 2).PadLeft(16, '0');
            int par2 = chk_valid.parity(data_word);
            string data_frame = "PPP" + data_word;
            data_frame += Convert.ToString(Convert.ToInt32(par2), 2);
            Console.WriteLine("DATA: " + data);
            Console.WriteLine("PARITY1 = {0} PARITY2 = {1}", decode.par, par2);
            if (decode.par != par2)
                Console.WriteLine("Error: Calculated parity mismatch!");

            return data_frame;
        }
    }
}
