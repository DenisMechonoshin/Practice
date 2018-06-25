using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Учебная_практика_11
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

        static void Main(string[] args)
        {
            int SwitchNumber = 0;

            do
            {
                Console.WriteLine("Вас приветствует программа по работе с шифрованным текстом. Что бы вы хотели сделать?");
                Console.WriteLine("1 - Расшифровать текст в файле C:\\TEST\\DECYPHERINPUT");
                Console.WriteLine("2 - Зашифровать текст в файле C:\\TEST\\CYPHERINPUT");
                Console.WriteLine("3 - Завершить работу с программой");

                SwitchNumber = ReadInteger(1, 3, "Введенное вами число не соответствует ни одному из предложенных вариантов. Пожалуйста, введите другое");

                switch (SwitchNumber)
                {
                    case 1:
                        {
                            string Text = System.IO.File.ReadAllText(@"C:\TEST\DECYPHERINPUT.txt");
                            char[,] Letter = new char[11,11];
                            int PosX = 5, PosY = 5, Direction = 0, Step = 0, StepCurrent = 0; //1 - вправо, 2 - вниз, 3 - влево, 4 - вверх;

                            for (int i=0;i<121;i++)
                            {
                                Letter[PosX, PosY] = Text[i];

                                if (PosX == PosY)
                                {
                                    Step++;
                                }

                                StepCurrent++;

                                if ((StepCurrent == Step)||((PosX==PosY)&&(PosX!=5)))
                                {
                                    Direction++;
                                    if (Direction==5)
                                    {
                                        Direction = 1;
                                    }
                                    StepCurrent = 0;

                                }

                                switch (Direction)
                                {
                                    case 1:
                                        {
                                            PosX++;
                                            break;
                                        }
                                    case 2:
                                        {
                                            PosY++;
                                            break;
                                        }
                                    case 3:
                                        {
                                            PosX--;
                                            break;
                                        }
                                    case 4:
                                        {
                                            PosY--;
                                            break;
                                        }
                                }


                                

                            }
                            Text = "";

                            for (int i=0;i<11;i++)
                            {
                                for (int j = 0; j < 11; j++)
                                {
                                    Text = Text + Letter[i,j].ToString();
                                }
                            }

                            System.IO.File.WriteAllText(@"c:\TEST\DECYPHEROUTPUT.txt", Text);

                            Console.WriteLine("Текст успешно расшифрован");
                            break;
                        }

                    case 2:
                        {
                            string Text = System.IO.File.ReadAllText(@"C:\TEST\CYPHERINPUT.txt");
                            char[,] Letter = new char[11, 11];
                            int PosX = 5, PosY = 5, Direction = 0, Step = 0, StepCurrent = 0; //1 - вправо, 2 - вниз, 3 - влево, 4 - вверх;
                            int Position = 0;

                            for (int i = 0; i < 11; i++)
                            {
                                for (int j = 0; j < 11; j++)
                                {
                                    Letter[i, j] = Text[Position];
                                    Position++;
                                }
                            }

                            Text = "";

                            for (int i = 0; i < 121; i++)
                            {                               
                                Text = Text + Letter[PosX, PosY].ToString();


                                if (PosX == PosY)
                                {
                                    Step++;
                                                                        
                                }

                                StepCurrent++;
                                
                                if ((StepCurrent == Step) || ((PosX == PosY) && (PosX != 5)))
                                {
                                    Direction++;
                                    if (Direction == 5)
                                    {
                                        Direction = 1;
                                    }
                                    StepCurrent = 0;
                                    
                                }

                                switch (Direction)
                                {
                                    case 1:
                                        {
                                            PosX++;
                                            break;
                                        }
                                    case 2:
                                        {
                                            PosY++;
                                            break;
                                        }
                                    case 3:
                                        {
                                            PosX--;
                                            break;
                                        }
                                    case 4:
                                        {
                                            PosY--;
                                            break;
                                        }
                                }       

                            }                   
                           

                            System.IO.File.WriteAllText(@"c:\TEST\CYPHEROUTPUT.txt", Text);

                            Console.WriteLine("Текст успешно зашифрован");
                            break;
                        }
                    case 3:
                        {
                            break;
                        }




                }
            } while (SwitchNumber != 3);
            
            
            

        }
    }
}
