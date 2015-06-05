using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace JavaScript_EnDecoder
{
    class StaticUtils
    {
        static private Console Logger = new Console();
        public static int delay = 0;
        public static bool startConsole()
        {     
            if (Logger.IsHandleCreated)
            {
                return false;
            }
            Logger.Show();
            return true;
        }

        public static void Focus()
        {
            Logger.Focus();
        }

        public static void log(object text)
        {
            Logger.LogToText(text);
            
        }

        public static bool ConsoleIsRunning()
        {
            if (Logger.IsHandleCreated)
            {
                return true;
            }
            return false;
        }
    }
}
