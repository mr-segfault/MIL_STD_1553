﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL_STD_1553
{
    class media
    {
        public static int _ctr = 0;

        public static int send_onto_media(string frame)
        {
            Console.WriteLine("message ID: " + media._ctr);
            System.IO.File.AppendAllText(@"milbus.dat", frame);
            media._ctr++;
            return 0;
        }

        public static int recv_from_media(int id, float timestamp)
        {
            return 0;

        }
    }
}
