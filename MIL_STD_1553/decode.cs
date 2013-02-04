using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL_STD_1553
{
    class decode
    {
        public static int par = 0;
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
            par = Convert.ToInt32(parity_str, 2);

            encode.wr_msg(0, 0, 0, 0, 0, 0, 0, 0, 0, addy, tr, sub_address_mc, wc_mc, 0, 0, 1);
            return 0;
        }
        public static int dataword_decode(string frame)
        {
            if (frame.Length != 20)
            {
                Console.WriteLine("Error: Invalid frame length! Frame length must be 20 bits including 3 preceding preamble bits");
                return 1;
            }
            string data_str = frame.Substring(3,16);
            int data_int = Convert.ToInt32(data_str, 2);

            string parity_str = frame.Substring(19, 1);
            par = Convert.ToInt32(parity_str, 2);


            encode.wr_msg(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, data_int, 0, 2);
            return 0;
        }
        public static int statusword_decode(string frame)
        {
            if (frame.Length != 20)
            {
                Console.WriteLine("Error: Invalid frame length! Frame length must be 20 bits including 3 preceding preamble bits");
                return 1;
            }
            string address = frame.Substring(3, 5);
            int addy = Convert.ToInt32(address, 2);

            string msg_error_str = frame.Substring(8, 1);
            int msg_error = Convert.ToInt32(msg_error_str, 2);

            string instrumentation_str = frame.Substring(9, 1);
            int instrumentation = Convert.ToInt32(instrumentation_str, 2);

            string srvc_req_str = frame.Substring(10, 1);
            int srvc_req = Convert.ToInt32(srvc_req_str, 2);

            string broadcast_cmd_rcvd_str = frame.Substring(10, 1);
            int broadcast_cmd_rcvd = Convert.ToInt32(broadcast_cmd_rcvd_str, 2);

            string busy_str = frame.Substring(10, 1);
            int busy = Convert.ToInt32(busy_str, 2);

            string subsystem_str = frame.Substring(10, 1);
            int subsystem = Convert.ToInt32(subsystem_str, 2);

            string dyn_bus_accept_str = frame.Substring(10, 1);
            int dyn_bus_accept = Convert.ToInt32(dyn_bus_accept_str, 2);

            string parity_str = frame.Substring(19, 1);
            par = Convert.ToInt32(parity_str, 2);
            
            encode.wr_msg(0, msg_error, instrumentation, srvc_req, broadcast_cmd_rcvd, busy, subsystem, dyn_bus_accept, 0, addy, 0, 0, 0, 0, 0, 3);
            return 0;
        }

    }
}
