using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            int size;
            int randomRange = 100;
            bool f;

            do
            {
                Console.WriteLine("Input size of array : ");
                f = int.TryParse(Console.ReadLine(), out size);
            } while (!f);

            double[] array = new double[size];
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (rnd.NextDouble() - 0.5) * 2 * randomRange;
                //if (i == 5) { array[i] = Math.Floor(array[i]); }
                Console.WriteLine($"array[{i}] = {array[i]};");
            }

            //сума від’ємних елементів масиву;
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0) { sum += array[i]; }
            }
            Console.WriteLine($"\nsum = {sum};");

            //максимальний елемент масиву;
            double max = -randomRange;
            for (int i = 0; i < array.Length; i++)
            {
                max = Math.Max(array[i], max);
            }
            Console.WriteLine($"\nmax = {max};");

            //номер(індекс) максимального елемента масиву;
            int maxInd = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == max) { maxInd = i; break; }
            }
            Console.WriteLine($"\nmaxInd = {maxInd};");

            //максимальний елемент масиву;
            double maxAbs = 0;
            for (int i = 0; i < array.Length; i++)
            {
                maxAbs = Math.Max(Math.Abs(array[i]), maxAbs);
            }
            Console.WriteLine($"\nmaxAbs = {maxAbs};");

            //сума індексів додатних елементів;
            int sumInd = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0) { sumInd += i; }
            }
            Console.WriteLine($"\nsumInd = {sumInd};");

            //кількість цілих чисел у масиві;
            int amount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (Math.Floor(array[i]) == array[i]) { amount++; }
            }
            Console.WriteLine($"\namount = {amount};");
        }
    }
}
