using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
namespace Vovk.Lab8
{
    class Class1
    {
        static void Main(string[] args)
        {
            try
            {
                string n = "C:\\Users\\667\\Desktop\\Text.txt";
                //Предоставляет свойства и методы экземпляра для создания, копирования, удаления, перемещения и открытия файлов
                FileInfo f = new FileInfo(n);
                StreamWriter p = new StreamWriter("C:\\Users\\667\\Desktop\\Result.txt");
                //Exists oпределяет, существует ли заданный файл
                if (f.Exists)
                {
                    p.WriteLine("Название файла: {0}", f.Name);
                    p.WriteLine("Абсолютный путь к файлу: {0}", n);
                    p.WriteLine("Относительный путь к файлу: {0}", "..\\..\\..\\Text.txt");
                    p.WriteLine("Время создания файла: {0}", f.CreationTime);
                    p.WriteLine("Размер файла: {0}", f.Length);
                    //Открывает текстовый файл, считывает весь текст файла в строку и затем закрывает файл.
                    string T = File.ReadAllText(n);
                    string[] textMass;
                    //Указывает параметры для применимых перегрузок метода Split
                    textMass = T.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    p.WriteLine("Общее количество строк: {0}", File.ReadAllLines(n).Count());
                    p.WriteLine("Общее количество слов: {0}", textMass.Length);
                    //Представляет постоянное регулярное выражение.
                    p.WriteLine("Присутствуют ли в тексте цифры: {0}", Regex.IsMatch(T, @"[0-9]"));
                    p.WriteLine("Присутствует ли в тексте кириллица: {0}", Regex.IsMatch(T, @"[А-яёЁ]"));
                    p.WriteLine("Присутствует ли в тексте латиница: {0}", Regex.IsMatch(T, @"[A-z]"));
                    p.Close();
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

            
            

            


                


