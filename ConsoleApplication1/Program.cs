using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MatrixKvadrat
    {
        int n; double Ch;
        double[,] matrix;
        double sl = 0;
        

        public double this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }
        public MatrixKvadrat(int n)
        {
            this.n = n;
            this.matrix = new double[n, n];
        }
                 
        public void CreateMatrix()
        {           
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mitka1:
                    try
                    {
                        Console.Write("Введiть елемент [" + i.ToString() + ";" + j.ToString() + "]" + "\t");
                        matrix[i, j] = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Ви ввели некоректне значення елементу матриці(букву або інший символ замість цифри(+,-,*,/))! Повторіть введення!");
                        goto mitka1;
                    }                    
                }
            }
            
        }
         
        public void PrintMatrix()
        {            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        } 
        
        public void SlidMatrix()
        {                      
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        sl += matrix[i, j];
                    
                }                
            }
            Console.Write(sl + "\t");              
            Console.WriteLine();
        }        

        public static MatrixKvadrat operator +(MatrixKvadrat A, MatrixKvadrat B)
        {
            Console.WriteLine("A+B=");
            A.PrintMatrix();
            Console.WriteLine("\t+");
            B.PrintMatrix();
            Console.WriteLine("\nРезультат додавання матриць=");
            MatrixKvadrat C = new MatrixKvadrat(A.n);
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.n; j++)
                {
                    C[i, j] = A[i, j] + B[i, j];
                }
            }
            return C;
        }
               
        public static MatrixKvadrat operator -(MatrixKvadrat A, MatrixKvadrat B)
        {
            Console.WriteLine("A-B=");
            A.PrintMatrix();
            Console.WriteLine("\t-");
            B.PrintMatrix();
            Console.WriteLine("\nРезультат віднімання матриць=");
            MatrixKvadrat R = new MatrixKvadrat(A.n);
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.n; j++)
                {
                    R[i, j] = A[i, j] - B[i, j];
                }
            }
            return R;
        }

        public static MatrixKvadrat operator *(MatrixKvadrat A, MatrixKvadrat B)
        {
            Console.WriteLine("A*B=");
            A.PrintMatrix();
            Console.WriteLine("\t*");
            B.PrintMatrix();
            Console.WriteLine("\nРезультат множення матриць=");
            MatrixKvadrat r = new MatrixKvadrat(A.n);
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.n; j++)
                {
                    for (int k = 0; k < B.n; k++)
                    {
                        r[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return r;
        }

        public static MatrixKvadrat operator /(MatrixKvadrat A, double Ch)
        {
            Console.WriteLine("A*с=");
            A.PrintMatrix();
            Console.WriteLine("\t*");
            Console.WriteLine(Ch);
            Console.WriteLine("\nРезультат множення матриці на число=");
            MatrixKvadrat q = new MatrixKvadrat(A.n);
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.n; j++)
                {
                    q[i, j] = A[i, j] + Ch;
                }
            }
            return q;
        }
    }

    class Program
    { 
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Програма для розв'язку квадратних матриць!\n");
            double ch = 0;
            int m = 0;
            mitka0:
            mitka1:
            try
            {
                Console.WriteLine("Введіть розмір матриці:");
                m = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ви ввели некоректний розмір матриці(букву або інший символ замість цифри)! Повторіть введення!");
                goto mitka1;
            }
            if(m<=0)
            {
                Console.WriteLine("Ви ввели некоректний розмір матриці(нульовий або від'ємний)! Повторіть введення!");
                goto mitka1;
            }
            Console.WriteLine("\n===================================");
            mitka2:
            try
            {
                Console.WriteLine("Введіть число на яке домножити матрицю:");
                ch = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ви ввели некоректний розмір матриці! Повторіть введення!");
                goto mitka2;
            }
            Console.WriteLine("\n===================================");
            MatrixKvadrat a = new MatrixKvadrat(m);
            Console.WriteLine("Введіть матрицю А:");
            a.CreateMatrix();
            Console.WriteLine();
            Console.WriteLine("A=");
            a.PrintMatrix();
            Console.WriteLine("\n===================================");            
            MatrixKvadrat b = new MatrixKvadrat(m);
            Console.WriteLine("Введіть матрицю В:");
            b.CreateMatrix();
            Console.WriteLine();
            Console.WriteLine("B=");
            b.PrintMatrix();
            Console.WriteLine("\n===================================");
                        
            Console.WriteLine("Результати всіх обрахунків:\n");
            Console.WriteLine("\n===================================");
            MatrixKvadrat c0 = a + b;            
            Console.WriteLine("C=");
            c0.PrintMatrix();
            Console.WriteLine("\n===================================");            
            MatrixKvadrat c1 = a - b;
            Console.WriteLine("C=");
            c1.PrintMatrix();
            Console.WriteLine("\n===================================");            
            Console.WriteLine("Слід матриць:\n");            
            Console.WriteLine("Слід матриці A=");
            a.SlidMatrix();
            Console.WriteLine();
            Console.WriteLine("Слід матриці B=");
            b.SlidMatrix();
            Console.WriteLine("\n===================================");
            Console.WriteLine("Множення матриці на число:\n");
            Console.WriteLine("Множення матриці A на число:");
            MatrixKvadrat c3 = a / ch;
            c3.PrintMatrix();
            Console.WriteLine("\nМноження матриці B на число:");
            MatrixKvadrat c4 = b / ch;
            c4.PrintMatrix();
            Console.WriteLine("\n===================================");            
            MatrixKvadrat c2 = a * b;
            Console.WriteLine("C=");
            c2.PrintMatrix();
            Console.WriteLine("\n===================================");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Бажаєте здiйснити новi обрахування? (yes-1/no-2)");
                ConsoleKeyInfo c = Console.ReadKey();
                if (c.KeyChar == '1')
                    goto mitka0;
                else if (c.KeyChar == '2') break;
            }            
            Console.ReadKey();
        }
    }
}