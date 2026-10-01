using System;
using System.IO;

namespace LabWork2_Variant7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int n = 5;
            int[,] A = new int[n, n];

            Console.WriteLine("Оберіть спосіб введення даних:");
            Console.WriteLine("1 — Введення з клавіатури");
            Console.WriteLine("2 — Автоматична генерація випадковими числами");
            Console.WriteLine("3 — Зчитування з файлу (input.txt)");
            Console.Write("Ваш вибір (1-3): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    InputFromConsole(A, n);
                    break;
                case "2":
                    GenerateRandomArray(A, n);
                    break;
                case "3":
                    InputFromFile(A, n, "input.txt");
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Використовуємо генерацію випадкових чисел.");
                    GenerateRandomArray(A, n);
                    break;
            }

            Console.WriteLine("\nВхідний масив A(5,5):");
            PrintArray(A, n);

            Console.Write("\nВведіть граничне число: ");
            int threshold = Convert.ToInt32(Console.ReadLine());

            int count = CountElementsAboveDiagonal(A, n, threshold);

            Console.WriteLine($"\nКількість елементів на головній діагоналі та вище неї, які більші за {threshold}: {count}");

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
        static int CountElementsAboveDiagonal(int[,] array, int size, int threshold)
        {
            int count = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = i; j < size; j++)
                {
                    if (array[i, j] > threshold)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        static void PrintArray(int[,] array, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0,6}", array[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void InputFromConsole(int[,] array, int size)
        {
            Console.WriteLine($"Введіть елементи масиву {size}x{size}:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"A[{i},{j}] = ");
                    array[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        static void GenerateRandomArray(int[,] array, int size)
        {
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = rnd.Next(1, 51);
                }
            }
        }
        static void InputFromFile(int[,] array, int size, string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            array[i, j] = Convert.ToInt32(sr.ReadLine());
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"Файл {fileName} не знайдено! Згенеровано випадковий масив.");
                GenerateRandomArray(array, size);
            }
        }
    }
}