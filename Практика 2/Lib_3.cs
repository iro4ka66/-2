using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_2
{
    class Lib_3
    {
        public static int baeva (int[] mas)
        {
            int otvet=mas[0];
            for (int i=1; i<mas.Length;i++)
            {
                otvet -=mas[i];
            }
            return otvet;
        }


    }
}
