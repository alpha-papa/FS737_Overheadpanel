﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overheadpanel
{
    class Panel
    {
        protected static bool is_debug = false;

        protected static void debug(String str)
        {
            if (is_debug)
            {
                Console.WriteLine(str);
            }
        }
    }
}
