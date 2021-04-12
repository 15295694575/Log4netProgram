using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Log4netProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            LogHelper.InfoLog("This is a test");

            Thread.Sleep(1000);
        }
    }
}
