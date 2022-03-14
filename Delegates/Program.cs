using System;
using System.Collections.Generic;

namespace Delegates
{
    internal class Program
    {
        private delegate void Back(int x);
        private delegate int OperBack(int x, Back callback);

        static int Abs(int x) { return x < 0 ? -x : x; }
        static int AbsBack(int x, Back callback) 
        { 
            x = Abs(x);
            callback(x);
            return x; 
        }
        static int Sqr(int x) { return x * x; }
        static int SqrBack(int x, Back callback)
        {
            x = Sqr(x);
            callback(x);
            return x;
        }
        static int Cub(int x) 
        {
            double y = (double)x;
            
            y = Math.Pow(y, 3);
            x = (int)y;

            return x;      
        }
        static int CubBack(int x, Back callback)
        {
            x = Cub(x);
            callback(x);
            return x;
        }
        static void Print(int x) { Console.WriteLine(x); }
        static void PrintLine(int x) { Console.WriteLine($"**{x}**"); }
        static void SuperPrint(int x) { Console.WriteLine($"-= {x} =-"); }
        static void Main(string[] args)
        {
            UserInterface();
        }
        static private void UserInterface()
        {
            Back output;
            List<OperBack> collection_custom_methods = new List<OperBack>();
            int user_method = new int();
            int custom_output = new int();
            int x = new int();

            while (true)
            {
                int final_method = new int();
                int check = 10;
                int check2 = 10;

                Console.Clear();
                Console.Write("1.Abs\n2.Sqr\n3.Cub\nchoice: ");

                user_method = Int32.Parse(Console.ReadLine());

                Console.Write("\n\n1.Print\n2.PrintLine\n3.SuperPrint\nchoice: ");

                custom_output = Int32.Parse(Console.ReadLine());
                
                switch (custom_output)
                {
                    case 1:
                        output = Print;
                        break;
                    case 2:
                        output = PrintLine;
                        break;
                    case 3:
                        output = SuperPrint;
                        break;
                    default:
                        output = SuperPrint;
                        break;
                }
                
                Console.Write("\n\n[*]What's the argument: ");
                
                x = Int32.Parse(Console.ReadLine());

                final_method = user_method % check;

                for (int i = 0; i < Math.Abs(user_method).ToString().Length; i++)
                {
                    switch (final_method)
                    {
                        case 1:
                            collection_custom_methods.Add(AbsBack);
                            break;
                        case 2:
                            collection_custom_methods.Add(SqrBack);
                            break;
                        case 3:
                            collection_custom_methods.Add(CubBack);
                            break;
                        default:
                            break;
                    }

                    check *= 10;
                    final_method = user_method % check / check2;
                    check2 *= 10;
                }

                Console.WriteLine("\n\n[*]Result:");
                foreach (OperBack i in collection_custom_methods)
                    i(x, output);

                collection_custom_methods.Clear();
                Console.ReadKey();
            }
        }
    }
}