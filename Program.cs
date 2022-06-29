using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace pract16
{
    class Program
    {
        public static void Zadanie1()
        {
            StreamReader sr = File.OpenText("f1.txt");
            string str = sr.ReadToEnd();
            Console.WriteLine("Введите слово: ");
            string word = Console.ReadLine().ToLower();
            string word2 = char.ToUpper(word.First()) + word.Remove(0, 1);

            string[] array = str.Split(new string[] { " ", ".", ",", "?", "!", "|", ":" }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(str);
            var value = array.Where(x => x == word.ToLower() || x == word.ToUpper() || x == word2);
            Console.WriteLine($"Были найдены {value.Count()} вхождения (ий) поискового запроса {word}");

            sr.Close();
        }
        public static void Zadanie2()
        {
            Console.WriteLine("Введите строку: ");
            string str = Console.ReadLine();
            Console.WriteLine("Выберите: \n1-Определения количество содержащихся в ней цифр и вывода их на экран и их количества\n" +
                "2 - Вывода на экран всех элементов массива, пока не встретится символ “/”" +
                "\n3 - Вывода на экран всех элементов массива, которые содержатся после символа “/” и с заменой у всех этих элементов букв на верхний регистр (если они в нижнем регистре и в нижний регистр (если они в верхнем регистре). ");
            string x = Console.ReadLine();
            if (x == "1")
            {
                var value = str.Where(x => char.IsNumber(x)).ToArray();
                Console.WriteLine("кол-во цифр: " + value.Count());
                Console.ReadKey();
            }
            if (x == "2")
            {
                var value = string.Join("", str.TakeWhile(x => x != '/'));
                Console.WriteLine(value);
            }
            if (x == "3")
            {
                var value = string.Join("", str.SkipWhile(x => x != '/')).Remove(0, 1);
                bool n1 = value.Any(i => char.IsUpper(i));
                if (n1) { value = value.ToLower(); }
                else { value = value.ToUpper(); }
                Console.WriteLine(value);
                StreamWriter sw = File.CreateText("f1.txt");
                sw.WriteLine(value);
                sw.Close();
            }
        }
        public static void Zadanie3()
        {
            double[] Arr1 = { 5.1, 1, 3, 9.2, 2, 3, 5.1, 3 };
            Array.Sort(Arr1);
            List<string> list1 = new List<string>();
            List<double> list2 = new List<double>();
            int count = 0;
            for (int i = 1; i < Arr1.Length; i++)
            {
                if (Arr1[i] == Arr1[i - 1]) count++;
                if (Arr1[i] != Arr1[i - 1])
                {
                    list1.Add($"{Arr1[i - 1]} - {count + 1}");
                    count = 0;
                    if (i == Arr1.Length - 1) list1.Add($"{Arr1[i]} - {count + 1}");
                }
            }
            Console.WriteLine(string.Join("\n", list1));
            Console.WriteLine();
            foreach (var value in list1)
            {
                string[] array = value.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                double x = double.Parse(array[0]) * double.Parse(array[1]);
                list2.Add(x);
                Console.WriteLine($"{x} - {array[1]}");
            }
        }
        public static void Zadanie4()
        {
            Dictionary<string, string> country = new Dictionary<string, string>();
            Console.WriteLine("Введите число: ");
            int number = int.Parse(Console.ReadLine());
            StreamReader sr = File.OpenText("file4.txt");
            while (!sr.EndOfStream)
            {
                string[] array = sr.ReadLine().Split(new string[] { "  " }, StringSplitOptions.RemoveEmptyEntries);
                array[1] = array[1].Replace(" ", "");
                country.Add(array[0], array[1]);
            }
            sr.Close();
            foreach (var s in country) Console.WriteLine($"{s.Key}, {s.Value}");
            Console.WriteLine();
            foreach (var s in country.Where(x => int.Parse(x.Value) > number).OrderBy(x => x.Value)) Console.WriteLine($"{s.Key}, {s.Value}");
        }
        static void Main(string[] args)
        {
            Zadanie4();
        }
    }
}
