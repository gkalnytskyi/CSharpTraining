using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBase
{
    class Program
    {
        static void Main(string[] args)
        {
            new MainCoon().Fur();
            Console.ReadLine();
        }


        private class Animal
        {
            virtual public void Fur()
            {
                Console.WriteLine("N/A");
            }
        }

        private class Cat : Animal
        {
            override public void Fur()
            {
                Console.WriteLine("Yes");
            }
        }

        private class MainCoon : Cat
        {
            override public void Fur()
            {
                Console.WriteLine("Medium Long");
            }
        }
    }
}
