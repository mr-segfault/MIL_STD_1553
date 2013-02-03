using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// SOURCE MAY BE MODIFIED AND DISTRIBUTED FREELY
// MIL-STD-1553 stack by DoYouKnow

namespace MIL_STD_1553
{
    class encode
    {
        private static int frame_invalid = 0;
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
                Console.WriteLine("===================================================");
                string cmd_frame = cmd_word.frame_cmd_word(address, tr, sub_address_mc, wc_mc);
                Console.WriteLine(cmd_frame);
                media.send_onto_media(cmd_frame);
                chk_valid.check_frame_correctness(address, tr);
                bus_controller.message_address(address, sub_address_mc, wc_mc, tr);
                Console.WriteLine("DEBUG output: \nis_status: " + is_status + ", message_error: " + message_error + ", instrumentation: " + instrumentation + ", service_request: " + service_request + ", broadcast_cmd_reserved " + broadcast_cmd_received + ", busy: " + busy + ", subsystem_flag: " + subsystem_flag + ", dynamic_bus_acceptance: " + dynamic_bus_acceptance + ", terminal_flag: " + terminal_flag + ", address: " + address + ", tr: " + tr + ", sub_address_mc: " + sub_address_mc + ", wc_mc: " + wc_mc + ", par: " + par + ", data: " + data + ", end_of_messages: " + end_of_messages + ", msg_type: " + msg_type + "\n");

                Console.WriteLine("===================================================");

            }
            if (msg_type == DATA_TYPE)
            {
                Console.WriteLine("===================================================");
                string data_word_binary = data_word.frame_data_word(data);                
                Console.WriteLine(data_word_binary);
                media.send_onto_media(data_word_binary);
                Console.WriteLine("DEBUG output: \nis_status: " + is_status + ", message_error: " + message_error + ", instrumentation: " + instrumentation + ", service_request: " + service_request + ", broadcast_cmd_reserved " + broadcast_cmd_received + ", busy: " + busy + ", subsystem_flag: " + subsystem_flag + ", dynamic_bus_acceptance: " + dynamic_bus_acceptance + ", terminal_flag: " + terminal_flag + ", address: " + address + ", tr: " + tr + ", sub_address_mc: " + sub_address_mc + ", wc_mc: " + wc_mc + ", par: " + par + ", data: " + data + ", end_of_messages: " + end_of_messages + ", msg_type: " + msg_type + "\n");
                Console.WriteLine("===================================================");

            }
                        if (msg_type == STATUS_TYPE)
                        {
                            Console.WriteLine("===================================================");
                            string status_word_binary = status_word.frame_status_word(address, message_error, instrumentation, service_request, broadcast_cmd_received, busy, subsystem_flag, dynamic_bus_acceptance, terminal_flag);
                            Console.WriteLine(status_word_binary);
                            media.send_onto_media(status_word_binary);
                            Console.WriteLine("DEBUG output: \nis_status: " + is_status + ", message_error: " + message_error + ", instrumentation: " + instrumentation + ", service_request: " + service_request + ", broadcast_cmd_reserved " + broadcast_cmd_received + ", busy: " + busy + ", subsystem_flag: " + subsystem_flag + ", dynamic_bus_acceptance: " + dynamic_bus_acceptance + ", terminal_flag: " + terminal_flag + ", address: " + address + ", tr: " + tr + ", sub_address_mc: " + sub_address_mc + ", wc_mc: " + wc_mc + ", par: " + par + ", data: " + data + ", end_of_messages: " + end_of_messages + ", msg_type: " + msg_type + "\n");
                            Console.WriteLine("===================================================");

                        }
                        return 0;

        }
        static void Main(string[] args)
        {


            if (wr_msg(0, 0, 0, 0, 0, 0, 0, 0, 0, 0x1f, 0, 19, 0, 1, 0, 0, 1) == 0) 
                Console.WriteLine("COMMAND WORD SENT.\n\n");
            if (wr_msg(0, 0, 0, 0, 0, 0, 0, 0, 0, 0x1f, 0, 19, 0, 1, 16025, 0, 2) == 0) 
                Console.WriteLine("\nDATA WORD SENT\n");
            if (wr_msg(0, 0, 0, 0, 0, 0, 0, 0, 0, 0x1f, 0, 19, 0, 1, 16050, 0, 2) == 0) 
                Console.WriteLine("\nDATA WORD SENT\n");
            if (wr_msg(0, 0, 0, 0, 1, 0, 0, 0, 0, 0x1f, 0, 19, 0, 1, 0, 1, 3) == 0)
                Console.WriteLine("\nSTATUS WORD SENT\n");


        }
    }
}