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
            var toI = m.GetLength(0) - 1;
            var toJ = m.GetLength(1) - 1;
            int[,] newMatrix = new int[m.GetLength(0), m.GetLength(1)];
            var fromI = 0;
            var fromJ = 0;
            var oI = 0;
            var oJ = 0;
            var goI = true;
            var iStep = -1;
            var jStep = 1;
            for (int i = 0; i < newMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < newMatrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = m[oI, oJ];
                    if (goI && iStep > 0 && oI == toI)
                    {
                        toI--;
                        goI = false;
                        iStep *= -1;
                    }
                    if (goI && iStep < 0 && oI == fromI)
                    {
                        fromI++;
                        goI = false;
                        iStep *= -1;
                    }
                    if (!goI && jStep > 0 && oJ == toJ)
                    {
                        toJ--;
                        goI = true;
                        jStep *= -1;
                    }
                    if (!goI && jStep < 0 && oJ == fromJ)
                    {
                        fromJ++;
                        goI = true;
                        jStep *= -1;
                    }
                    if (goI)
                    {
                        oI += iStep;
                    }
                    else
                    {
                        oJ += jStep;
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
