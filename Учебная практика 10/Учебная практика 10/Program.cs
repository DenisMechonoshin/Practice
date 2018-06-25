using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Учебная_практика_10
{
    class Program
    {
        public static int ReadInteger(int LowerLimit, int HigherLimit, string ErrorMessage)
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

        public static double ReadDouble(double LowerLimit, double HigherLimit, string ErrorMessage)
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
            int n;
            Console.WriteLine("Введите количество чисел");

            n = ReadInteger(1, 999999, "Введенное вами число не является целым. Пожалуйста, введите другое");
            double[] x = new double[n];
            double summ = 0;

            for (int i=0;i<n;i++)
            {
                Console.WriteLine("Введите число под номером {0}",i);
                x[i] = ReadDouble(-999999, 999999, "Введенное вами число не является действительным. Пожалуйста, введите другое");
            }
            
            for (int i=0;i<n;i++)
            {
                summ = summ + x[i] * x[n - i - 1];
            }

            Console.WriteLine("Результат вычислений равен {0}", summ);
        }
    }
}
