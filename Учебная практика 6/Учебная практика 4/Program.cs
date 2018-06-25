using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Учебная_практика_4
{
    class Program
    {
        static void Main(string[] args)
        {

            double a1, a2, a3;
            int N;
            bool ok, decrease, increase;

            Console.WriteLine("Введите значение первого элемента последовательности");

            do
            {
                ok = Double.TryParse(Console.ReadLine(), out a1);
                if (!ok)
                {
                    Console.WriteLine("Введенное вами значение не является действительным числом. Пожалуйста, введите другое.");
                }

            } while (!ok);

            Console.WriteLine("Введите значение второго элемента последовательности");

            do
            {
                ok = Double.TryParse(Console.ReadLine(), out a2);
                if (!ok)
                {
                    Console.WriteLine("Введенное вами значение не является действительным числом. Пожалуйста, введите другое.");
                }

            } while (!ok);

            Console.WriteLine("Введите значение третьего элемента последовательности");

            do
            {
                ok = Double.TryParse(Console.ReadLine(), out a3);
                if (!ok)
                {
                    Console.WriteLine("Введенное вами значение не является действительным числом. Пожалуйста, введите другое.");
                }

            } while (!ok);

            Console.WriteLine("Введите количество элементов в последовательности");

            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out N);
                if ((!ok)||(N<=3))
                {
                    Console.WriteLine("Введенное вами значение не является действительным числом. Пожалуйста, введите другое.");
                }

            } while ((!ok) || (N <= 3));

            double[] a = new double[N];
            a[1] = a1;
            a[2] = a2;
            a[3] = a3;

            Console.WriteLine("");
            Console.WriteLine("Последовательность состоит из элементов:");
            Console.WriteLine(a1);
            Console.WriteLine(a2);
            Console.WriteLine(a3);

            for (int i = 4; i<N; i++)
            {

                a[i] = 0.7 * a[i-1] - 0.2 * a[i-2] + i * a[i-3];
                Console.WriteLine(a[i]);
            }

            Console.WriteLine("");

            increase = true;
            decrease = true;

            for (int i = 3; i<N; i++)
            {
                if (i % 2 == 1)
                {
                    if (a[i-2] < a[i])
                    {
                        decrease = false;
                    }
                    if (a[i - 2] > a[i])
                    {
                        increase = false;
                    }
                }
            }

            if (((increase == true)&&(decrease == true))|| ((increase == false) && (decrease == false)))
            {
                Console.WriteLine("Подпоследовательность, состоящая из нечетных элементов, не является возрастающей или убывающей");
            }

            if ((increase == true) && (decrease == false))
            {
                Console.WriteLine("Подпоследовательность, состоящая из нечетных элементов, является возрастающей");
            }

            if ((increase == false) && (decrease == true))
            {
                Console.WriteLine("Подпоследовательность, состоящая из нечетных элементов, является убывающей");
            }
        }
    }
}
