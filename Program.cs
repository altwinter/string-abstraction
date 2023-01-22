using System;
using System.Text;

namespace Abstract
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = AIS.computation("human", "chimpanzee");
            Console.WriteLine("Result : " + result);
        }
    }
}