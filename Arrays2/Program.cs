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
                //if (i == 5) { array[i] = 0; }
                //if (i == 7) { array[i] = 0; }
                //if (i == 9) { array[i] = 0; }
                Console.WriteLine($"array[{i}] = {array[i]};");
            }

            //добуток елементів масиву, що розташовані після мінімального елемента;
            double min = randomRange;
            int minInd = 0;
            double mult = 1;
            for (int i = 0; i < array.Length; i++)
            {
                if (min > array[i]) { min = array[i]; minInd = i; }
            }
            for (int i = minInd; i < array.Length; i++)
            {
                if (i == minInd) continue;
                mult *= array[i];
            }

            Console.WriteLine($"\nmult = {mult};");

            //сума елементів масиву, що розташовані між першим від'ємним та другим додатним елементами;
            double firstS = randomRange;
            double secondU = -randomRange;
            int firstSInd = -1;
            int secondUInd = -1;
            bool k = false;
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0) { firstS = array[i]; firstSInd = i; break; }
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0 && k) { secondU = array[i]; secondUInd = i; break; }
                if (array[i] >= 0 && !k) { k = true; }
            }
            int begin = Math.Min(firstSInd, secondUInd);
            int end = Math.Max(firstSInd, secondUInd);
            if (begin == -1 || end == -1)
            {
                Console.WriteLine($"\nsum = none;");
            }
            else
            {
                for (int i = begin; i < end; i++)
                {
                    if (i == begin) continue;
                    sum += array[i];
                }
                Console.WriteLine($"\nsum = {sum};");
            }

            //сума елементів масиву, які розташовані між першим і останнім нульовими елементами;
            begin = -1;
            end = -1;
            sum = 0;
            k = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0 && k) { end = i; };
                if (array[i] == 0 && !k) { k = true; begin = i; };
            }
            if (begin == -1 || end == -1)
            {
                Console.WriteLine($"\nsum = none;");
            }
            else
            {
                for (int i = begin; i < end; i++)
                {
                    if (i == begin) continue;
                    sum += array[i];
                }
                Console.WriteLine($"\nsum = {sum};");
            }

            //добуток елементів масиву, що розташовані між максимальним за модулем і мінімальним за модулем елементами;
            double minAbs = 100;
            double maxAbs = 0;
            int minAbsInd = -1;
            int maxAbsInd = -1;
            mult = 1;
            for (int i = 0; i < array.Length; i++)
            {
                if (minAbs > Math.Abs(array[i])) { minAbs = Math.Abs(array[i]); minAbsInd = i; }
                if (maxAbs < Math.Abs(array[i])) { maxAbs = Math.Abs(array[i]); maxAbsInd = i; }
            }
            begin = Math.Min(minAbsInd, maxAbsInd);
            end = Math.Max(minAbsInd, maxAbsInd);
            if (begin == -1 || end == -1)
            {
                Console.WriteLine($"\nmult = none;");
            }
            else
            {
                for (int i = begin; i < end; i++)
                {
                    if (i == begin) continue;
                    mult *= array[i];
                }
                Console.WriteLine($"\nmult = {mult};");
            }


        }
    }
}
