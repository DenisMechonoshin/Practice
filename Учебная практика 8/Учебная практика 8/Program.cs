using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Учебная_практика_8
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

        static int[,] ReadMatrix(int Size)
        {
            int[,] Matrix = new int[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.WriteLine("Введите элемент матрицы с координатами {0} и {1}", i + 1, j + 1);
                    Matrix[i, j] = ReadInteger(0, 1, "Введенное вами число должно быть равно 0 или 1. Пожалуйста, введите другое");
                }
            }

            return Matrix;
        }

        
        static void ShowMatrix(int[,] Matrix, int Size)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(Matrix[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }
        }

        static void EulerPath(int[,] Matrix, int Size, int V)
        {
            for (int i=0;i<Size;i++)
            {
                if (Matrix[V,i] == 1)
                {
                    Matrix[V, i] = 0;
                    Matrix[i, V] = 0;
                    EulerPath(Matrix, Size, i);
                }
            }
            Console.WriteLine(V+1);
        }

        static void Main(string[] args)
        {
            int MatrixSize;

            Console.WriteLine("Вас приветствует программа по нахождению эйлеровой цепи в графе, заданном матрицей смежности. Чтобы начать работу с программой, введите число вершин в графе");
            MatrixSize = ReadInteger(1, 99999, "Введенное вами число не является натуральным. Пожалуйста, введите другое");
            int[,] Matrix = new int[MatrixSize, MatrixSize];

            Console.WriteLine("Теперь заполните матрицу смежности для этого графа. Не забывайте, что для корректной работы программы граф должен быть эйлеровым");

            Matrix = ReadMatrix(MatrixSize);

            Console.WriteLine("Эйлерова цепь для выбранного графа имеет следующий вид: ");

            EulerPath(Matrix, MatrixSize, 1);

        }
    }
}
