using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL_STD_1553
{
    class MIL_STD_1760E
    {
        public static int nuclearwpns_address(int sub_address_mc)
        {
            int is_nuclear = 0;
            if ((sub_address_mc == 19) || (sub_address_mc == 27))
            {
                Console.WriteLine("(MIL-STD-1760E) Likely US Nuclear weapon communication with a carriage store. Address: {0}", sub_address_mc);
                is_nuclear = 1;
            }
            return is_nuclear;
        }
    }
}
