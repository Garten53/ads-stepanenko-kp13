using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp134
{
    class Program
    {
        static void Main(string[] args)
        {
            
            LinkedList MyList = new LinkedList();
            MyList.AddLast(20);
            MyList.AddLast(13);
            MyList.AddLast(88);
            MyList.AddAfterMax(99);
            MyList.AddAfterMax(95);
            MyList.AddAfterMax(100);
            MyList.PrintList();
            Console.ReadKey();
        }
    }
}
