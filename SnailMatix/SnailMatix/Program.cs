using System;
using System.Linq;
using System.Text;

namespace SnailMatix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] test = ReadMatrix();
            WriteMatrix(test);
            Console.WriteLine("Snail matrix");
            var snail = SnailTrasform(test);
            WriteMatrix(snail);
            Console.ReadKey();
        }
        static int [,] SnailTrasform(int[,] m)
        {
            int[,] newMatrix = new int[m.GetLength(0),m.GetLength(1)];
            var iStep = -1;
            var jStep = 1;
            var goI = true;
            var oi = 0;
            var oj = 0;
            var toi = m.GetLength(0) - 1;
            var toj = m.GetLength(1) - 1;
            var fromi = 0;
            var fromj = 0;
            for (int i = 0; i < newMatrix.GetLength(0); i ++)
            {
                for (int j = 0; j < newMatrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = m[oi, oj];
                    if (goI && (iStep > 0 && oi == toi || iStep < 0 && oi == fromi))
                    {
                        if(iStep > 0)
                        {
                            toi--;
                        }
                        else
                        {
                            fromi++;
                        }
                        goI = false;
                        iStep *= -1;                       
                    }
                    if (!goI && (jStep > 0 && oj == toj || jStep < 0 && oj == fromj))
                    {
                        if (jStep > 0)
                        {
                            toj--;
                        }
                        else
                        {
                            fromj++;
                        }
                        goI = true;
                        jStep *= -1;
                    }
                    if (goI)
                    {
                        oi += iStep;
                    }
                    else
                    {
                        oj += jStep;
                    }
                }
            }
            return newMatrix;
        }
        static void WriteMatrix(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for(int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write($"{mat[i,j]}\t");
                }
                Console.WriteLine();
            }
        }
        static int[,] ReadMatrix()
        {
            var (n,m) = GetMatixSize();
            Console.WriteLine("Write matrix");
            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = ReadIntUntil(' ', '\t');
                }
                Console.WriteLine();
            }
            return matrix;
        }
        static int ReadIntUntil(params char[] untilSymbols)
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                var key = Console.ReadKey();
                if (untilSymbols.Contains(key.KeyChar))
                {
                    return int.Parse(sb.ToString());
                }
                else
                {
                    sb.Append(key.KeyChar);
                }
            }
        }
        static (int n, int m) GetMatixSize()
        {
            Console.WriteLine("Enter matix size m:n");
            Console.Write("m=");
            var m = ReadInt();
            Console.Write("n=");
            var n = ReadInt();
            return (m, n);
        }
        static int ReadInt()
        {
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                throw new OperationCanceledException();
            }
            var line = Console.ReadLine();
            var keyLine = $"{key.KeyChar}{line}";
            return Int32.Parse(keyLine);
        }
    }
}
