﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL_STD_1553
{
    class media
    {
        public static int send_onto_media(string frame)
        {
            Console.WriteLine("Placing message on the bus with message ID: " + encode._ctr);
            Console.WriteLine("WORD BEING SENT ONTO FILE MEDIA...\n");
            System.IO.File.AppendAllText(@"milbus.dat", frame);
            return 0;
        }

        public static int recv_from_media(int id, float timestamp)
        {
            return 0;

        }
    }
}
