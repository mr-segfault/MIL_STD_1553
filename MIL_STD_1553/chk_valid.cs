using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL_STD_1553
{
    class chk_valid
    {
        public static int parity(string message)
        {

            int par = 0;
            int par_ctr = 0;
            for (int i = 0; i < message.Length; i++)
            {
                // ASCII "1" is '49'
                if (message[i] == 49)
                {
                    par_ctr++;
                }
            }
            if (par_ctr % 2 == 1)
                par = 1;
            return par;
        }
        public static int check_frame_correctness(int address, int tr)
        {
            int frame_invalid = 0;
            if (address > 0x1F)
            {
                Console.WriteLine("\nError: Invalid frame!: Invalid address!\n");
                frame_invalid = 1;
            }
            if ((address == 0x1F) && (tr == 1))
            {
//                Console.WriteLine("\nError: Invalid frame!: Broadcast frames are not commanded to x-mit on RT\n");
                frame_invalid = 1;
            }
            return frame_invalid;
        }
    }
}
