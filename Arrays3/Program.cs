using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            int randomRange = 100;
            bool f;

            do
            {
                Console.WriteLine("Input n size of matrix : ");
                f = int.TryParse(Console.ReadLine(), out n);
            } while (!f);

            do
            {
                Console.WriteLine("Input m size of matrix : ");
                f = int.TryParse(Console.ReadLine(), out m);
            } while (!f);

            int[,] matrix = new int[n,m];
            Random rnd = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i,j] = rnd.Next(-randomRange, randomRange+1);
                    //if (i == 5) { array[i] = 0; }
                    Console.Write($"{matrix[i, j], 5}");
                }
                Console.WriteLine();
            }

            //кількість додатних елементів;
            int count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0) count++;
                }
            }
            Console.WriteLine($"\ncount = {count};");

            //максимальне із чисел, що зустрічається в заданій матриці більше одного разу;
            int max = -1;
            int[] arr1 = new int[2 * randomRange + 1];
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = 0;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    arr1[ matrix[i, j] + randomRange]++;
                }
            }

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] >= 2) { max = Math.Max(i,max); }
            }
            
            if (max == -1)
                Console.WriteLine($"\nmax = none;");
            else{
                max -= randomRange;
                Console.WriteLine($"\nmax = {max};");
            }

            //кількість рядків, які не містять жодного нульового елемента;
            int countRows = 0;
            bool k = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0) { k = true; }
                }
                if (!k) { countRows++; }
                k = false;
            }
            Console.WriteLine($"\ncountRows = {countRows};");

            //кількість стовпців, які містять хоча б один нульовий елемент;
            int countCols = 0;
            k = false;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] == 0) { k = true; }
                }
                if (k) { countCols++; }
                k = false;
            }
            Console.WriteLine($"\ncountCols = {countCols};");


            //номер рядка, в якому знаходиться найдовша серія однакових елементів;
            int maxSerRow = -1;
            int maxSer = 0;
            int Ser = 0;
            int SerNum = -randomRange - 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == SerNum) { Ser++; }
                    else
                    {
                        if (maxSer <= Ser) { maxSer = Ser; maxSerRow = i; }
                        Ser = 1;
                        SerNum = matrix[i, j];
                    }
                }
                SerNum = -randomRange - 1;
                if (maxSer <= Ser) { maxSer = Ser; maxSerRow = i; }
                Ser = 0;
            }
            if (maxSer == 0 || maxSer == 1) Console.WriteLine($"\nmaxSerRow = none;");
            else Console.WriteLine($"\nmaxSerRow = {maxSerRow};");


            //добуток елементів в тих рядках, які не містять від’ємних елементів;
            int mult = 1;
            bool[] arr2 = new bool[n];
            k = false;

            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = false;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0) { arr2[i] = true; continue; }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (arr2[i]) { continue; }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    k = true;
                    mult *= matrix[i, j];
                }
            }
            if (k) { Console.WriteLine($"\nmult = {mult};"); }
            else { Console.WriteLine($"\nmult = none;"); }


            //максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці;
            int sum = 0;
            int maxSum = -2147483648;
            for (int l = 1; l < matrix.GetLength(0); l++)
            {
                for (int i = l, j = 0; (i < matrix.GetLength(0)) && (j < matrix.GetLength(1)); i++, j++)
                {
                    sum += matrix[i, j];
                }
                maxSum = Math.Max(sum, maxSum);
                sum = 0;
            }
            for (int l = 1; l < matrix.GetLength(1); l++)
            {
                for (int i = 0, j = l; (i < matrix.GetLength(0)) && (j < matrix.GetLength(1)); i++, j++)
                {
                    sum += matrix[i, j];
                }
                maxSum = Math.Max(sum, maxSum);
                sum = 0;
            }
            Console.WriteLine($"\nmaxSum = {maxSum};");

            //суму елементів в тих стовпцях, які не містять від’ємних елементів;
            sum = 0;
            bool[] arr3 = new bool[m];
            k = false;

            for (int i = 0; i < arr3.Length; i++)
            {
                arr3[i] = false;
            }
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0) { arr3[j] = true; continue; }
                }
            }
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (arr3[j]) { continue; }
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    k = true;
                    sum += matrix[i, j];
                }
            }

            if (k) { Console.WriteLine($"\nsum = {sum};"); }
            else { Console.WriteLine($"\nsum = none;"); }

            //мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці;
            int sumAbs = 0;
            int minSumAbs = 2147483647;
            for (int l = 0; l < matrix.GetLength(0)-1; l++)
            {
                for (int i = l, j = 0; (i >= 0) && (j < matrix.GetLength(1)); i--, j++)
                {
                    sumAbs += Math.Abs( matrix[i, j] );
                }
                minSumAbs = Math.Min(sumAbs, minSumAbs);
                sumAbs = 0;
            }
            for (int l = 1; l < matrix.GetLength(1); l++)
            {
                for (int i = matrix.GetLength(0)-1, j = l; (i >= 0) && (j < matrix.GetLength(1)); i--, j++)
                {
                    sumAbs += Math.Abs(matrix[i, j]);
                }
                minSumAbs = Math.Min(sumAbs, minSumAbs);
                sumAbs = 0;
            }
            Console.WriteLine($"\nminSumAbs = {minSumAbs};");

            //сума елементів в тих стовпцях, які  містять хоча б один від’ємний елемент;
            sum = 0;
            bool[] arr4 = new bool[m];
            k = false;

            for (int i = 0; i < arr4.Length; i++)
            {
                arr4[i] = false;
            }
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0) { arr4[j] = true; continue; }
                }
            }
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (!arr4[j]) { continue; }
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    k = true;
                    sum += matrix[i, j];
                }
            }

            if (k) { Console.WriteLine($"\nsum = {sum};"); }
            else { Console.WriteLine($"\nsum = none;"); }

            //транспонована матриця;
            int[,] newMatrix = new int[m, n];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrix[i,j] = matrix[j,i];
                }
            }

            Console.WriteLine();
            for (int i = 0; i < newMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < newMatrix.GetLength(1); j++)
                {
                    Console.Write($"{newMatrix[i, j],5}");
                }
                Console.WriteLine();
            }

        }
    }
}
