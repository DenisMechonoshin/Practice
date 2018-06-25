using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Учебная_практика_9
{
    class Point2

    {
        public int data;
        public Point2 next, //адрес следующего элемента
        pred;//адрес предыдущего элемента
        public Point2()
        {
            data = 0;
            next = null;
            pred = null;
        }
        public Point2(int d)
        {
            data = d;
            next = null;
            pred = null;
        }
        public override string ToString()
        {
            return data + " ";
        }
    }

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

        static Point2 MakePoint2(int d)
        {
            Point2 p = new Point2(d);
            return p;
        }

        static Point2 MakeList2(int size) 

        {

            Console.WriteLine("Введите целочисленный элемент под номером 1");
            int info = ReadInteger(-999999999, 999999999,"Введенное вами число не является целым. Пожалуйста, введите другое");
            int k;
            Point2 beg = MakePoint2(info);
            for (int i = 1; i < size; i++)
            {
                k = i + 1;
                Console.WriteLine("Введите целочисленный элемент под номером {0}", k);
                info = ReadInteger(-999999999, 999999999, "Введенное вами число не является целым. Пожалуйста, введите другое");
                Point2 p = MakePoint2(info);
                p.next = beg;
                beg.pred = p;
                beg = p;

            }



            return beg;

        }

        static void FindSums(Point2 beg, int size, out int summ1, out int summ2)
        {
            int[] a = new int[size];

            Point2 p = beg;
            int sum1 = 0, sum2 = 0;

            for (int i = 0; i < size; i++)
            {

                a[i] = p.data;
                p = p.next;
                if (a[i] > 0 )
                {
                    sum1 = sum1 + a[i];
                }
                if (a[i] < 0)
                {
                    sum2 = sum2 + a[i];
                }


            }

            summ1 = sum1;
            summ2 = sum2;
        }
        
        static void Main(string[] args)
        {
            int Size,summ1,summ2;
            Point2 List;

            Console.WriteLine("Вас приветствует программа по работе с двунаправленным списком. Для начала работы с программой, введите количество элементов в списке");
            Size = ReadInteger(0, 999999999, "Введенное вами число не является натуральным. Пожалуйста, введите другое");
            List = MakeList2(Size);

            FindSums(List, Size, out summ1, out summ2);
            Console.WriteLine("Сумма всех положительных элементов в списке равна {0}", summ1);
            Console.WriteLine("Сумма всех отрицательных элементов в списке равна {0}", summ2);

        }
    }
}
