using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// SOURCE MAY BE MODIFIED AND DISTRIBUTED FREELY
// MIL-STD-1553 stack by DoYouKnow

namespace MIL_STD_1553
{
    class main
    {
        static void Main(string[] args)
        {


//            if (encode.wr_msg(0, 0, 0, 0, 0, 0, 0, 0, 0, 0x1f, 0, 19, 0, 1, 0, 0, 1) == 0) 
//                Console.WriteLine("COMMAND WORD SENT.\n\n");
//            if (encode.wr_msg(0, 0, 0, 0, 0, 0, 0, 0, 0, 0x1f, 0, 19, 0, 1, 16025, 0, 2) == 0) 
//                Console.WriteLine("\nDATA WORD SENT\n");
//            if (encode.wr_msg(0, 0, 0, 0, 0, 0, 0, 0, 0, 0x1f, 0, 19, 0, 1, 16050, 0, 2) == 0) 
//                Console.WriteLine("\nDATA WORD SENT\n");
//            if (encode.wr_msg(0, 0, 0, 0, 1, 0, 0, 0, 0, 0x1f, 0, 19, 0, 1, 0, 1, 3) == 0)
//                Console.WriteLine("\nSTATUS WORD SENT\n");
            Console.WriteLine("Number of command line parameters = {0}", args.Length);
            if (args.Length == 2)
            {
                if (args[0] == "decode")
                    // temporary cmdword decode until autodetection is working.
                { decode.cmdword_decode(args[1]); }
            }
            else {
                Console.WriteLine("Usage: MIL_STD_1553 [-server|-client <client address>] [encode | decode] {frame}");
                return;
            }
 //           decode.cmdword_decode("PPP11111010011000000");

        }
    }
}