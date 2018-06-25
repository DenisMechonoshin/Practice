using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Учебная_практика_7
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

        static void Show(int K, int N)
        {
            int[] Show = new int[K];

            for(int i=0;i<K;i++)
            {
                Show[i] = 1;
            }

            for (int i = 1; i <= (Math.Pow(N,K)); i++)
            {                
                for (int j = 0; j < K; j++)
                {
                    Console.Write(Show[j]);
                    Console.Write(" ");

                    if (i % Math.Pow(N, (K-j-1)) == 0)        
                    {
                        Show[j]++;                        

                        if (Show[j]>N)
                        {
                            Show[j] = 1;
                            
                        }

                        if (j==K-1)
                        {
                            Console.WriteLine("");
                        }
                    }

                }
            }

        }

        static void Main(string[] args)
        {
            int N, K;
            

            Console.WriteLine("Вас приветствует программа по поиску размещений из N элементов по K с повторениями. Чтобы начать работу с программой, введите N");
            N = ReadInteger(1, 999999999, "Введенное вами число не является натуральным. Пожалуйста, введите другое");
            Console.WriteLine("Теперь введите K");
            K = ReadInteger(1, N, "Введенное вами число не является натуральным или превышает N. Пожалуйста, введите другое");

            Show(K, N);

        }
    }
}
