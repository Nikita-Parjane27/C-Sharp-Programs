using System;
namespace Matrix_Addition
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrixA = new int[2][]
            {
                new int[] {1, 2},
                new int[] {3, 4}
            };

            int[][] matrixB = new int[2][]
            {
                new int[] {5, 6},
                new int[] {7, 8}
            };

            int[][] resultMatrix = new int[2][]
            {
                new int[2],
                new int[2]
            };

            for (int i = 0; i < matrixA.Length; i++)
            {
                for (int j = 0; j < matrixA[i].Length; j++)
                {
                    resultMatrix[i][j] = matrixA[i][j] + matrixB[i][j];
                }
            }

            Console.WriteLine("Result of Matrix Addition:");
            for (int i = 0; i < resultMatrix.Length; i++)
            {
                for (int j = 0; j < resultMatrix[i].Length; j++)
                {
                    Console.Write(resultMatrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}