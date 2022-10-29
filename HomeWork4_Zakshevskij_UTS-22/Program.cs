using System;
using System.Globalization;

namespace hw4
{
    class Programm
    {
        public static int CorrectInt(string b)
        {
            
            int a;
            do
            {
                if (int.TryParse(b, out a))
                {
                    break;
                }
                Console.WriteLine("Число должно быть целым и положительным");
                b = Console.ReadLine();
            } while (true);
            if (a < 0)
            {
                a = a * -1;
            }
            return a;
        }
        public static void InitArray(int[] X)
        {

            Random r = new Random();
            for (int i = 0; i < X.Length; i++)
            {
                X[i] = r.Next(-50, 50);
            }
        }
        public static void PrintArray(int[] X)
        {
            string str = string.Join(" ", X);
            Console.WriteLine(str);
        }
        public static int Main()
        {
            int f = 1;
            do
            {
                Console.Write("Введите длину одномерного массива: ");
                string R = Console.ReadLine();
                int a = CorrectInt(R);
                int[] X = new int[a];
                InitArray(X);
                Console.WriteLine("Исходный массив:");
                PrintArray(X);
                Console.WriteLine($"Максимальный элемент данного массива: {X.Max()}");
                int IndexMax = Array.IndexOf(X, X.Max());
                int LastPIndex = 0;
                Array.Reverse(X);
                for (int i = 0; i < X.Length; i++)
                {
                    if (X[i] > 0)
                    {
                        LastPIndex = i;
                        break;
                    }
                }
                Array.Reverse(X);
                LastPIndex = X.Length - LastPIndex - 1;
                int SumToLast = 0;
                for (int i = 0; i < LastPIndex; i++)
                {
                    SumToLast += X[i];
                }
                Console.WriteLine($"Сумма до последнего положительного элемента: {SumToLast}");
                if (X.Max() > SumToLast)
                {
                    for (int i = 0; i < X.Length; i++)
                    {
                        if ((Math.Abs(X[i]) <= X.Max()) && (Math.Abs(X[i]) >= SumToLast))
                        {
                            X[i] = 0;
                        }
                    }
                }
                else if (X.Max() < SumToLast)
                {
                    for (int i = 0; i < X.Length; i++)
                    {
                        if ((Math.Abs(X[i]) >= X.Max()) && (Math.Abs(X[i]) <= SumToLast))
                        {
                            X[i] = 0;
                        }
                    }
                }
                Console.WriteLine("Сжатый массив:");
                var str2 = string.Join(" ", X);
                Console.WriteLine(str2);
                Console.WriteLine("Введите размер квадратной матрицы:");
                int A;
                R = Console.ReadLine();
                A = CorrectInt(R);
                int B = A;
                int[,] matr = new int[A,B];
                Random ran = new Random();
                Console.WriteLine("Исходная матрица:");
                for (int i = 0; i < A; i++)
                {
                    for (int j = 0; j < B; j++)
                    {
                        matr[i, j] = ran.Next(-10, 50);
                        Console.Write("{0}\t", matr[i, j]);
                    }
                    Console.WriteLine();
                }
                int count = 0;
                int[] sum = new int[B];
                int sum1 = 0;
                int[] P = new int[A];
                for (int i = 0; i < B; i++)
                {
                    for (int j = 0; j < A; j++)
                    {
                        sum1 += matr[j, i];
                    }
                    sum[i] = sum1;
                    sum1 = 0;
                }
                for (int i = 0; i < B; i++)
                {
                    for (int j = 0; j < A; j++)
                    {
                        P[j] = matr[j, i];
                    }

                    for (int k = 0; k<P.Length; k++)
                    {
                        if (P[k] < 0)
                        {
                            sum[i] = 0;
                            break;
                        }
                    }
                }
                Console.WriteLine($"Сумма элементов среди столбцов, не имеющих отрицательных элементов: {sum.Sum()}");
                int[] t1 = new int[100];
                int[] t2 = new int[100];    
                for (int i = 0; i<A; i++)
                {
                    for (int j=0; j<B-i;j++)
                    {
                        t1[i]=Math.Abs(matr[i+j, j]);
                        t2[i]=Math.Abs(matr[j,i+j]);
                    }
                }
                int Min = 9999;
                for (int i = 1; i < A-1; i++)
                {
                    if ((t1[i] < Min)&&(t1[i] != 0))
                    {
                        Min = t1[i];
                    }
                }
                for (int i = 1; i < A - 1; i++)
                {
                    if ((t2[i] < Min) && (t2[i] != 0))
                    {
                        Min = t2[i];
                    }
                }
                Console.WriteLine($"Минимум среди сумм модулей элементов на диагоналях, параллельных главной: {Min}");
                Console.WriteLine("Повторить выполнение (1 - да, 0 - нет)");
                f = Convert.ToInt32(Console.ReadLine());
            } while (f == 1);
            return 0;
        }
    }
}
