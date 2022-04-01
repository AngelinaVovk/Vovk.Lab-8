using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
namespace Vovk.Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string n = @"C:\Users\667\source\repos\Lab8\Vovk.Lab-8.Zadanie1\Vovk.Lab-8.Zadanie1\bin\Debug\net6.0\text (2).txt";
                string o = "..\\..\\..\\Text.txt";
                //Предоставляет свойства и методы экземпляра для создания, копирования, удаления, перемещения и открытия файлов
                FileInfo f = new FileInfo(n);
                var result = "Result.txt";
                using (StreamWriter streamWriter = new StreamWriter(result))
                {
                    streamWriter.WriteLine("Название файла: {0}", f.Name);
                    streamWriter.WriteLine("Абсолютный путь к файлу: {0}", n);
                    streamWriter.WriteLine("Относительный путь к файлу: {0}" + o);
                    streamWriter.WriteLine("Время создания файла: {0}", f.CreationTime);
                    streamWriter.WriteLine("Размер файла: {0}", f.Length);
                    //Открывает текстовый файл, считывает весь текст файла в строку и затем закрывает файл.
                    string T = File.ReadAllText(n);
                    string[] textMass;
                    //Указывает параметры для применимых перегрузок метода Split
                    textMass = T.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    streamWriter.WriteLine("Общее количество строк: {0}", File.ReadAllLines(n).Count());
                    streamWriter.WriteLine("Общее количество слов: {0}", textMass.Length);
                    //Представляет постоянное регулярное выражение.
                    //Указывает на то, обнаруживает ли регулярное выражение соответствие во входной строке.
                    streamWriter.WriteLine("Присутствуют ли в тексте цифры: {0}", Regex.IsMatch(T, @"[0-9]"));
                    streamWriter.WriteLine("Присутствует ли в тексте кириллица: {0}", Regex.IsMatch(T, @"[А-яёЁ]"));
                    streamWriter.WriteLine("Присутствует ли в тексте латиница: {0}", Regex.IsMatch(T, @"[A-z]"));
                    streamWriter.Close();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}

            
            

            


                


