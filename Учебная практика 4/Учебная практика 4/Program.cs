using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Учебная_практика_4
{
    class Program
    {
        static int ReadInteger(int LowerLimit, int HigherLimit, string ErrorMessage)
        {
            int count;
            bool confirmed;

            do
            {
                confirmed = Int32.TryParse(Console.ReadLine(), out count);
                if ((count < LowerLimit) || (count > HigherLimit) || (confirmed != true))
                {
                    Console.WriteLine(ErrorMessage);
                }
            } while ((count < LowerLimit) || (count > HigherLimit) || (confirmed != true));

            return count;

        }

        static double ReadDouble(double LowerLimit, double HigherLimit, string ErrorMessage)
        {
            double count;
            bool confirmed;

            do
            {
                confirmed = Double.TryParse(Console.ReadLine(), out count);
                if ((count < LowerLimit) || (count > HigherLimit) || (confirmed != true))
                {
                    Console.WriteLine(ErrorMessage);
                }
            } while ((count < LowerLimit) || (count > HigherLimit) || (confirmed != true));

            return count;

        }

        static void Main(string[] args)
        {
            double x1, x2, y1, y2, x0, y0, perimeter,side;        
            int SwitchNumber;

            perimeter = 0;

            Console.WriteLine("Вас приветствует программа по нахождению периметра произвольного десятиугольника. Каким способом вы хотите определить координаты его вершин?");
            
            Console.WriteLine("1 - Ввести все координаты вершин вручную");
            Console.WriteLine("2 - Заполнить значения координат случайными числами от -100 до 100");

            SwitchNumber = ReadInteger(1, 2, "Введенное вами число не соответствует ни одному из предложенных вариантов. Пожалуйста, введите другое");

            switch(SwitchNumber)
            {
                case 1:
                    {
                        Console.WriteLine("Введите координату х вершины 1");
                        x1 = ReadDouble(-999999999, 999999999, "Введенное вами число не является действительным. Пожалуйста, введите другое");
                        Console.WriteLine("Введите координату у вершины 1");
                        y1 = ReadDouble(-999999999, 999999999, "Введенное вами число не является действительным. Пожалуйста, введите другое");

                        x0 = x1;
                        y0 = y1;

                        for (int i=2;i<10;i++)
                        {
                            Console.WriteLine("Введите координату х вершины {0}", i);
                            x2 = ReadDouble(-999999999, 999999999, "Введенное вами число не является действительным. Пожалуйста, введите другое");
                            Console.WriteLine("Введите координату у вершины {0}", i);
                            y2 = ReadDouble(-999999999, 999999999, "Введенное вами число не является действительным. Пожалуйста, введите другое");

                            side = Math.Sqrt(Math.Pow((Math.Abs(x2 - x1)),2) + Math.Pow((Math.Abs(y2 - y1)), 2));
                            perimeter = perimeter + side;

                            if (i==10)
                            {
                                side = Math.Sqrt(Math.Pow((Math.Abs(x2 - x0)), 2) + Math.Pow((Math.Abs(y2 - y0)), 2));
                                perimeter = perimeter + side;
                            }

                            x1 = x2;
                            y1 = y2;
                        }

                        break;
                    }

                case 2:
                    {
                        Random rnd = new Random();
                                             
                        x1 = rnd.Next(200) - 100;                        
                        y1 = rnd.Next(200) - 100;

                        Console.WriteLine("Координаты вершины 1: {0}, {1}", x1, y1);

                        x0 = x1;
                        y0 = y1;

                        for (int i = 2; i < 10; i++)
                        {
                            x2 = rnd.Next(200) - 100;
                            y2 = rnd.Next(200) - 100;                            

                            Console.WriteLine("Координаты вершины {2}: {0}, {1}", x1, y1, i);

                            side = Math.Sqrt(Math.Pow((Math.Abs(x2 - x1)), 2) + Math.Pow((Math.Abs(y2 - y1)), 2));
                            perimeter = perimeter + side;

                            if (i == 10)
                            {
                                side = Math.Sqrt(Math.Pow((Math.Abs(x2 - x0)), 2) + Math.Pow((Math.Abs(y2 - y0)), 2));
                                perimeter = perimeter + side;
                            }

                            x1 = x2;
                            y1 = y2;
                        }

                        break;
                    }
            }

            Console.WriteLine("Периметр десятиугольника равен {0}", perimeter);
        }
    }
}
