using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL_STD_1553
{
    class decode
    {
        public static int cmdword_decode(string frame)
        {
            if (frame.Length != 20)
            {
                Console.WriteLine("Error: Invalid frame length! Frame length must be 20 bits including 3 preceding preamble bits");
                return 1;
            }
            string address  = frame.Substring(3, 5);
            int addy = Convert.ToInt32(address, 2);

            string tr_str = frame.Substring(8, 1);
            int tr = Convert.ToInt32(tr_str, 2);


            string suba_mc_str = frame.Substring(9, 5);
            int sub_address_mc = Convert.ToInt32(suba_mc_str, 2);


            string string_wcmc_arr = frame.Substring(14, 5);
            int wc_mc = Convert.ToInt32(string_wcmc_arr, 2);

            string parity_str = frame.Substring(19, 1);
            int par = Convert.ToInt32(parity_str, 2);
            encode.wr_msg(0, 0, 0, 0, 0, 0, 0, 0, 0, addy, tr, sub_address_mc, wc_mc, 0, 0, 1);
            return 0;
        }
//        public static int dataword_extractvars()
//        {

//        }

    }
}
