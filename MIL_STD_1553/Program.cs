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
        static int wr_msg(int is_status, int message_error, int instrumentation, int service_request, int broadcast_cmd_received, int busy, int subsystem_flag, int dynamic_bus_acceptance, int terminal_flag, int address, int tr, int sub_address_mc, int wc_mc, int par, int data, int end_of_messages, int msg_type)
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
                Console.WriteLine("===================================================");
                Console.WriteLine(cmd_frame);

                Console.WriteLine("Placing message on the bus with message ID: " + Program._ctr);

                Console.WriteLine("\nCOMMAND WORD BEING SENT ONTO FILE MEDIA...\n");
                System.IO.File.AppendAllText(@"milbus.dat", cmd_frame);
                if (address > 0x1F)
                    Console.WriteLine("\nError: Invalid frame!: Invalid address!\n");
                if ((address == 0x1F) && (tr == 1))
                    Console.WriteLine("\nError: Invalid frame!: Broadcast frames are not commanded to x-mit on RT\n");
                string address_typ = "";
                //	fwrite(x, sizeof(x[0]), sizeof(x)/sizeof(x[0]), fp);
                Console.WriteLine("DEBUG output: \nis_status: " + is_status + ", message_error: " + message_error + ", instrumentation: " + instrumentation + ", service_request: " + service_request + ", broadcast_cmd_reserved " + broadcast_cmd_received + ", busy: " + busy + ", subsystem_flag: " + subsystem_flag + ", dynamic_bus_acceptance: " + dynamic_bus_acceptance + ", terminal_flag: " + terminal_flag + ", address: " + address + ", tr: " + tr + ", sub_address_mc: " + sub_address_mc + ", wc_mc: " + wc_mc + ", par: " + par + ", data: " + data + ", end_of_messages: " + end_of_messages + ", msg_type: " + msg_type + "\n");
                if (address == 0x1f)
                    address_typ = " BROADCAST";
                if (tr == 1)
                    Console.WriteLine("\nThis is a TRANSMIT{0} message addressed to 0x{1:X2}\n", address_typ, address);
                else
                    Console.WriteLine("\nThis is a RECEIVE{0} message addressed to 0x{1:X2}\n", address_typ, address);

                if ((sub_address_mc == 0x1f) || (sub_address_mc == 0x00))
                {
                    Console.WriteLine("\nThis frame contains a Mode Code Command\n");
                    Console.WriteLine("\nMode Code to be performed: " + wc_mc);
                    switch (wc_mc){
                        case 0: 
                            Console.WriteLine("(Dynamic bus control)");
                            break;
                        case 1:
                            Console.WriteLine("(Synchronize)");
                            break;
                        case 2:
                            Console.WriteLine("(Transmit status word)");
                            break;
                        case 3:
                            Console.WriteLine("(Initiate self-test)");
                            break;
                        case 4:
                            Console.WriteLine("(Transmitter shutdown)");
                            break;
                        case 5:
                            Console.WriteLine("(Override transmitter shutdown)");
                            break;
                        case 6:
                            Console.WriteLine("(Inhibit terminal flag bit)");
                            break;
                        case 7:
                            Console.WriteLine("(Override Inhibit Terminal Flag bit)");
                            break;
                        case 8:
                            Console.WriteLine("(Reset)");
                            break;
                        case 9:
                            Console.WriteLine("(RESERVED)");
                            break;
                        case 10:
                            Console.WriteLine("(RESERVED)");
                            break;
                        case 11:
                            Console.WriteLine("(RESERVED)");
                            break;
                        case 12:
                            Console.WriteLine("(RESERVED)");
                            break;
                        case 13:
                            Console.WriteLine("(RESERVED)");
                            break;
                        case 14:
                            Console.WriteLine("(RESERVED)");
                            break;
                        case 15:
                            Console.WriteLine("(RESERVED)");
                            break;
                        case 16:
                            Console.WriteLine("(Transmit Vector Word)");
                            break;
                        case 17:
                            Console.WriteLine("(Synchronize)");
                            break;
                        case 18:
                            Console.WriteLine("(Transmit Last Command Word)");
                            break;
                        case 19:
                            Console.WriteLine("(Transmit BIT Word)");
                            break;
                        case 20:
                            Console.WriteLine("(Selected Transmitter Shutdown)");
                            break;
                        case 21:
                            Console.WriteLine("(Override Selected Transmitter Shutdown)");
                            break;
                        case (22):
                            Console.WriteLine("(RESERVED)");
                            break;
                        case (23):
                            Console.WriteLine("(RESERVED)");
                            break;
                        case (24):
                            Console.WriteLine("(RESERVED)");
                            break;
                        case (25):
                            Console.WriteLine("(RESERVED)");
                            break;
                        case (26):
                            Console.WriteLine("(RESERVED)");
                            break;
                        case (27):
                            Console.WriteLine("(RESERVED)");
                            break;
                        case (28):
                            Console.WriteLine("(RESERVED)");
                            break;
                        case (29):
                            Console.WriteLine("(RESERVED)");
                            break;
                        case (30):
                            Console.WriteLine("(RESERVED)");
                            break;
                        case (31):
                            Console.WriteLine("(RESERVED)");
                            break;
                        default:
                            Console.WriteLine("DEBUG: Bits 10 through 14 not a mode code. Expect {0} sebsequent data words\n",wc_mc);
                            break;
                }
                }

                else
                {
                    Console.WriteLine("\nThis frame is addressed to a component within the subsystem\n");
                    Console.WriteLine("Address: " + sub_address_mc);
                    Console.WriteLine("Or, it indicates the subsequent transmittal of {0} data words.\n", wc_mc);
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
                Console.WriteLine("Placing message on the bus with message ID: " + Program._ctr);
                Console.WriteLine("\nDATA WORD BEING SENT ONTO FILE MEDIA...\n");
                Console.WriteLine("\nDATA: {0} PARITY: {1}\n", data, par);

                System.IO.File.AppendAllText(@"milbus.dat", dat_frame);

                //                    int NumberChars = 8;
                //                    byte[] bytes = new byte[NumberChars / 2];
                //                    for (int i = 0; i < 8; i += 2)
                //                    {
                //                        bytes[i / 2] = Convert.ToByte(data.Substring(i, 2), 16);
                //                    }

                Console.WriteLine("DEBUG output: \nis_status: " + is_status + ", message_error: " + message_error + ", instrumentation: " + instrumentation + ", service_request: " + service_request + ", broadcast_cmd_reserved " + broadcast_cmd_received + ", busy: " + busy + ", subsystem_flag: " + subsystem_flag + ", dynamic_bus_acceptance: " + dynamic_bus_acceptance + ", terminal_flag: " + terminal_flag + ", address: " + address + ", tr: " + tr + ", sub_address_mc: " + sub_address_mc + ", wc_mc: " + wc_mc + ", par: " + par + ", data: " + data + ", end_of_messages: " + end_of_messages + ", msg_type: " + msg_type + "\n");
                Console.WriteLine("===================================================");
                Program._ctr++;

            }
                        if (msg_type == STATUS_TYPE)
                        {
                            string status_frame = "PPP" + Convert.ToString(address, 2).PadLeft(5, '0') + Convert.ToString(message_error, 2) + Convert.ToString(instrumentation, 2) + Convert.ToString(service_request, 2) + "000" + Convert.ToString(broadcast_cmd_received, 2) + Convert.ToString(busy, 2) + Convert.ToString(subsystem_flag, 2) + Convert.ToString(dynamic_bus_acceptance, 2) + Convert.ToString(terminal_flag, 2) + Convert.ToString(par, 2);
                            Console.WriteLine(status_frame);
                            Console.WriteLine("Placing message on the bus with message ID: " + Program._ctr);
                            Console.WriteLine("\nSTATUS WORD BEING SENT ONTO FILE MEDIA...\n");
                            System.IO.File.AppendAllText(@"milbus.dat", status_frame);
                            Console.WriteLine("DEBUG output: \nis_status: " + is_status + ", message_error: " + message_error + ", instrumentation: " + instrumentation + ", service_request: " + service_request + ", broadcast_cmd_reserved " + broadcast_cmd_received + ", busy: " + busy + ", subsystem_flag: " + subsystem_flag + ", dynamic_bus_acceptance: " + dynamic_bus_acceptance + ", terminal_flag: " + terminal_flag + ", address: " + address + ", tr: " + tr + ", sub_address_mc: " + sub_address_mc + ", wc_mc: " + wc_mc + ", par: " + par + ", data: " + data + ", end_of_messages: " + end_of_messages + ", msg_type: " + msg_type + "\n");
                            Console.WriteLine("===================================================");
                            Program._ctr++;

                        }

            return _ctr;
        }
        static void Main(string[] args)
        {
            if (wr_msg(0, 0, 0, 0, 0, 0, 0, 0, 0, 0x1f, 0, 0, 0, 1, 0, 0, 1) == 0) 
                Console.WriteLine("COMMAND WORD SENT.\n\n");
            if (wr_msg(0, 0, 0, 0, 0, 0, 0, 0, 0, 0x1f, 0, 0, 0, 1, 16025, 0, 2) == 0) 
                Console.WriteLine("\nDATA WORD SENT\n");
            if (wr_msg(0, 0, 0, 0, 0, 0, 0, 0, 0, 0x1f, 0, 0, 0, 1, 16050, 1, 2) == 0) 
                Console.WriteLine("\nDATA WORD SENT\n");
            if (wr_msg(0, 0, 0, 0, 1, 0, 0, 0, 0, 0x1f, 0, 0, 0, 1, 0, 1, 3) == 0)
                Console.WriteLine("\nSTATUS WORD SENT\n");


        }
    }
}