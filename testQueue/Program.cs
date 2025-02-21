using QueueRealization;
using System.Diagnostics;

namespace testQueue
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = 100000;

            #region MyQueue Time Test

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("MyQueue time test");
            Console.ForegroundColor = ConsoleColor.White;
            var myQueue = new MyQueue<int>();

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < n; i++)
            {
                myQueue.Enqueue(i);
            }
            stopwatch.Stop();

            Console.Write($"Добавление {n} элементов заняло");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {stopwatch.ElapsedMilliseconds} мс");
            Console.ForegroundColor = ConsoleColor.White;

            stopwatch.Restart();
            for (int i = 0; i < n / 2; i++)
            {
                myQueue.Dequeue();
            }
            stopwatch.Stop();

            Console.Write($"Извлечение {n / 2} элементов заняло");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {stopwatch.ElapsedMilliseconds} мс");
            Console.ForegroundColor = ConsoleColor.White;

            stopwatch.Restart();
            for (int i = n / 2; i < n; i++)
            {
                if (!myQueue.Contains(i))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка! Элемент {i} не найден.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
            }
            stopwatch.Stop();

            Console.Write($"Проверка наличия {n / 2} элементов заняла");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {stopwatch.ElapsedMilliseconds} мс");
            Console.ForegroundColor = ConsoleColor.White;
            #endregion

            Console.WriteLine();

            #region Microsoft Queue Time Test

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Microsoft Queue time test");
            Console.ForegroundColor = ConsoleColor.White;

            var msQueue = new MyQueue<int>();

            stopwatch.Restart();
            for (int i = 0; i < n; i++)
            {
                msQueue.Enqueue(i);
            }
            stopwatch.Stop();
            Console.Write($"Добавление {n} элементов заняло");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {stopwatch.ElapsedMilliseconds} мс");
            Console.ForegroundColor = ConsoleColor.White;

            stopwatch.Restart();
            for (int i = 0; i < n / 2; i++)
            {
                msQueue.Dequeue();
            }
            stopwatch.Stop();
            Console.Write($"Извлечение {n / 2} элементов заняло");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {stopwatch.ElapsedMilliseconds} мс");
            Console.ForegroundColor = ConsoleColor.White;

            stopwatch.Restart();
            for (int i = n / 2; i < n; i++)
            {
                if (!msQueue.Contains(i))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка! Элемент {i} не найден.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
            }
            stopwatch.Stop();

            Console.Write($"Проверка наличия {n / 2} элементов заняла");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {stopwatch.ElapsedMilliseconds} мс");
            Console.ForegroundColor = ConsoleColor.White;

            #endregion
        }

    }
}
