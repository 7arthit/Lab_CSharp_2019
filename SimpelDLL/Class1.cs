using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpelDLL
{
    public class Simple
    {
        public string SayHello(string name)
        {
            return "สวัสดีคุณ " + name;
        }

        public int AddNumber(int a, int b)
        {
            return a + b;
        }
    }
}
