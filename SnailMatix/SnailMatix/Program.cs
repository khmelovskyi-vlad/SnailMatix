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
            Console.ReadKey();
        }
        static int [,] SnailTrasform(int[,] m)
        {
            int[,] newMatrix = new int[m.GetLength(0),m.GetLength(1)];

            for (int i = 0, new_i = 0; i < newMatrix.GetLength(0); i++, new_i++)
            {
                for (int j = 0; ;)
                {

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
