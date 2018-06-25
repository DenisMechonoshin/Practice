using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Учебная_практика_3
{
    class Program
    {
        static void Main(string[] args)
        {

            double x, y, n;
            bool ok;

            Console.WriteLine("Введите значение координаты x");

            do
            {
                ok = Double.TryParse(Console.ReadLine(), out x);
                if (!ok)
                {
                    Console.WriteLine("Введенное вами значение координаты х не является действительным числом. Пожалуйста, введите другое.");
                }

            } while (!ok);

            Console.WriteLine("Введите значение координаты y");

            do
            {
                ok = Double.TryParse(Console.ReadLine(), out y);
                if (!ok)
                {
                    Console.WriteLine("Введенное вами значение координаты y не является действительным числом. Пожалуйста, введите другое.");
                }

            } while (!ok);

            n = Math.Sqrt(x * x + y * y);

            if ((n>=0.5)&&(n<=1))
            {
                Console.WriteLine("Точка с введенными координатами принадлежит фигуре");
                ok = true;
            }
            else
            {
                Console.WriteLine("Точка с введенными координатами не принадлежит фигуре");
                ok = false;
            }

        }
    }
}
