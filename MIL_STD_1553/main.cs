using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


// SOURCE MAY BE MODIFIED AND DISTRIBUTED FREELY
// MIL-STD-1553 stack by DoYouKnow

namespace MIL_STD_1553
{
    class main
    {


        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeFileHandle CreateNamedPipe(
           String pipeName,
           uint dwOpenMode,
           uint dwPipeMode,
           uint nMaxInstances,
           uint nOutBufferSize,
           uint nInBufferSize,
           uint nDefaultTimeOut,
           IntPtr lpSecurityAttributes);

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
            if (args.Length == 3)
            {
                if (args[0] == "decode")
                    // temporary cmdword decode until autodetection is working. Autodetection will require input of preamble specific to STATUS/COMMAND/DATA word type
                {
                    if (args[1] == "cmdword")
                    {
                        decode.cmdword_decode(args[2]);
                    }
                    if (args[1] == "status")
                    {
                        decode.statusword_decode(args[2]);
                    }
                    if (args[1] == "data")
                    {
                        decode.dataword_decode(args[2]);
                    }
                }
            }
            else {
                Console.WriteLine("Usage: MIL_STD_1553 [encode | decode] [cmdword | status | data] <frame>");
                return;
            }
 //           decode.cmdword_decode("PPP11111010011000000");

        }
    }
}