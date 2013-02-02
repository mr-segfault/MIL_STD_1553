using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// SOURCE MAY BE MODIFIED AND DISTRIBUTED FREELY
// MIL-STD-1553 stack by DoYouKnow

namespace MIL_STD_1553
{
    class Program
    {
        private static int _ctr = 0;
        static int wr_msg(int is_status, int message_error, int instrumentation, int service_request, int broadcast_cmd_reserved, int busy, int subsystem_flag, int dynamic_bus_acceptance, int terminal_flag, int address, int tr, int sub_address_mc, int wc_mc, int par, int data, int end_of_messages, int msg_type)
        {
            int COMMAND_TYPE = 1;
            int DATA_TYPE = 2;
            int STATUS_TYPE = 3;
            int ctr = 0;
            bool idle = false;
            bool more_msgs = false;
            if (msg_type == COMMAND_TYPE)
            {
                string cmd_frame = "PPP" + Convert.ToString(address, 2).PadLeft(5, '0') + Convert.ToString(Convert.ToInt32(tr), 2) + Convert.ToString(sub_address_mc, 2).PadLeft(5, '0') + Convert.ToString(wc_mc, 2).PadLeft(5, '0') + Convert.ToString(Convert.ToInt32(par), 2);
                System.IO.File.AppendAllText(@"C:\Users\Michael\milbus.dat", cmd_frame);
                Console.WriteLine("===================================================");
                Console.WriteLine(cmd_frame);

                Console.WriteLine("Placing message on the bus with message ID: " + Program._ctr);

                Console.WriteLine("\nCOMMAND WORD BEING SENT ONTO VIRTUAL MEDIA...\n");
                if (address > 0x1F)
                    Console.WriteLine("\nError: Invalid frame!: Invalid address!\n");
                if ((address == 0x1F) && (tr == 1))
                    Console.WriteLine("\nError: Invalid frame!: Broadcast frames can't be x-mit\n");
                string address_typ = "";
                //	fwrite(x, sizeof(x[0]), sizeof(x)/sizeof(x[0]), fp);
                Console.WriteLine("DEBUG output: \nis_status: " + is_status + ", message_error: " + message_error + ", instrumentation: " + instrumentation + ", service_request: " + service_request + ", broadcast_cmd_reserved " + broadcast_cmd_reserved + ", busy: " + busy + ", subsystem_flag: " + subsystem_flag + ", dynamic_bus_acceptance: " + dynamic_bus_acceptance + ", terminal_flag: " + terminal_flag + ", address: " + address + ", tr: " + tr + ", sub_address_mc: " + sub_address_mc + ", wc_mc: " + wc_mc + ", par: " + par + ", data: " + data + ", end_of_messages: " + end_of_messages + ", msg_type: " + msg_type + "\n");
                if (address == 0x1f)
                    address_typ = " BROADCAST";
                if (tr == 1)
                    Console.WriteLine("\nThis is a" + address_typ + " TRANSMIT-type message\n");
                else
                    Console.WriteLine("\nThis is a" + address_typ + " RECEIVE-type message\n");

                if ((sub_address_mc == 0xff) || (sub_address_mc == 0x00))
                {
                    Console.WriteLine("\nThis is a Mode Code Command\n");
                    Console.WriteLine("\nMode Code to be performed: " + wc_mc);
                }

                else
                {
                    Console.WriteLine("\nThis frame is addressed to a component within the subsystem\n");
                    Console.WriteLine("Address: " + sub_address_mc);
                }

                Console.WriteLine("===================================================");
                Program._ctr++;

            }
            if (msg_type == DATA_TYPE)
            {
                int par_ctr = 0;
                string data_str = Convert.ToString(Convert.ToInt32(data), 2).PadLeft(16, '0');
                Console.WriteLine("===================================================");
                for (int i = 0; i < data_str.Length; i++)
                    if (data_str[i] == 1)
                        par_ctr++;
                if (par_ctr % 2 == 1)
                    par = 1;
                else
                    par = 0;
                string dat_frame = "PPP" + data_str + par;
                Console.WriteLine(dat_frame);
                System.IO.File.AppendAllText(@"C:\Users\Michael\milbus.dat", dat_frame);
                Console.WriteLine("Placing message on the bus with message ID: " + Program._ctr);
                Console.WriteLine("\nDATA WORD BEING SENT ONTO VIRTUAL MEDIA...\n");

                //                    int NumberChars = 8;
                //                    byte[] bytes = new byte[NumberChars / 2];
                //                    for (int i = 0; i < 8; i += 2)
                //                    {
                //                        bytes[i / 2] = Convert.ToByte(data.Substring(i, 2), 16);
                //                    }

                Console.WriteLine("DEBUG output: \nis_status: " + is_status + ", message_error: " + message_error + ", instrumentation: " + instrumentation + ", service_request: " + service_request + ", broadcast_cmd_reserved " + broadcast_cmd_reserved + ", busy: " + busy + ", subsystem_flag: " + subsystem_flag + ", dynamic_bus_acceptance: " + dynamic_bus_acceptance + ", terminal_flag: " + terminal_flag + ", address: " + address + ", tr: " + tr + ", sub_address_mc: " + sub_address_mc + ", wc_mc: " + wc_mc + ", par: " + par + ", data: " + data + ", end_of_messages: " + end_of_messages + ", msg_type: " + msg_type + "\n");
                Console.WriteLine("===================================================");
                Program._ctr++;

            }
            //            if (msg_type == STATUS_TYPE)
            //            {
            //
            //            }

            return _ctr;
        }
        static void Main(string[] args)
        {
            if (wr_msg(0, 0, 0, 0, 0, 0, 0, 0, 0, 0x1f, 0, 0, 0, 1, 16000, 0, 2) == 0) ;
            Console.WriteLine("\nSUCCESS\n");
            if (wr_msg(0, 0, 0, 0, 0, 0, 0, 0, 0, 0x1f, 0, 0, 0, 1, 16025, 0, 2) == 0) ;
            Console.WriteLine("\nSUCCESS\n");
            if (wr_msg(0, 0, 0, 0, 0, 0, 0, 0, 0, 0x1f, 0, 0, 0, 1, 16050, 1, 2) == 0) ;
            Console.WriteLine("\nSUCCESS\n");


        }
    }
}