using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Учебная_практика_5
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

        static double[,] ReadMatrix(int Size)
        {
            double[,] Matrix = new double[Size,Size];

            for (int i=0;i<Size;i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.WriteLine("Введите элемент матрицы с координатами {0} и {1}",i+1, j+1);
                    Matrix[i,j] = ReadDouble(-999999999, 999999999, "Введенное вами число не является действительным. Пожалуйста, введите другое");
                }
            }

            return Matrix;
        }

        static double[,] RandomMatrix(int Size)
        {
            double[,] Matrix = new double[Size, Size];

            Random rnd = new Random();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {                    
                    Matrix[i, j] = rnd.Next(200) - 100;
                }
            }

            return Matrix;
        }

        static void ShowMatrix(double[,] Matrix, int Size)
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

        static double MaxElement(double[,] Matrix, int Size)
        {
            double MaxElement = Matrix[1,1];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if ((j<=i)&&(Matrix[i,j]>MaxElement))
                    {
                        MaxElement = Matrix[i, j];
                    }
                }
            }

            return MaxElement;
        }

        static void Main(string[] args)
        {
            int MatrixSize, SwitchNumber;
            double Max;            
            
            Console.WriteLine("Вас приветствует программа по поиску наибольшего элемента в левой нижней половине квадратной матрицы. Для начала, введите значение порядка матрицы");

            MatrixSize = ReadInteger(1, 99999, "Введенное вами число не является натуральным. Пожалуйста, введите другое");
            double[,] Matrix = new double[MatrixSize, MatrixSize];

            Console.WriteLine("Каким способом вы хотите заполнить матрицу?");
            Console.WriteLine("1 - Ввести все элементы матрицы вручную");
            Console.WriteLine("2 - Заполнить матрицу случайными элементами со значениями от -100 до 100");

            SwitchNumber = ReadInteger(1, 2, "Введенное вами число не соответствует ни одному из предложенных вариантов. Пожалуйста, введите другое");
                        
            switch (SwitchNumber)
            {
                case 1:
                    {
                        Matrix = ReadMatrix(MatrixSize);
                        ShowMatrix(Matrix, MatrixSize);
                        break;
                    }

                case 2:
                    {
                        Matrix = RandomMatrix(MatrixSize);
                        ShowMatrix(Matrix, MatrixSize);
                        break;
                    }
            }

            Max = MaxElement(Matrix, MatrixSize);
            Console.WriteLine("Наибольший элемент в левой нижней половине матрицы имеет значение, равное {0}",Max);

        }
    }
}
