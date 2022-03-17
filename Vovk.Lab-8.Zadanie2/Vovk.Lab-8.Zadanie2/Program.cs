using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Encodings;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Vovk.Lab8_2
{
    class OtdelKadrov1
    {
        public string Фамилия { get; set; }
        public string Должность { get; set; }
        public double Стаж { get; set; }
        public double Отдел { get; set; }
        public double Оклад { get; set; }
        public double Годрождения { get; set; }
        public double Годовойдоход { get => Оклад * 12; }
        public double Возраст { get => 2022 - Годрождения; }
        public override string ToString()
        {
            return $" {Фамилия} {Стаж} {Отдел} {Оклад} {Годрождения} ";
        }
        public string ToExcel()
        {
            return $"{Фамилия} {Стаж} {Отдел} {Оклад} {Годрождения} {Годовойдоход} {Возраст}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var p = @"C:\Users\667\source\repos\Vovk.Lab-8.Zadanie2\Table.csv";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            var lines = File.ReadAllLines(p); ;
            Console.WriteLine(lines);
            var OtdelKadrov = new OtdelKadrov1[lines.Length - 1];

            for (int i = 6; i > lines.Length; i++)
            {
                var splits = lines[i].Split(';');
                var o = new OtdelKadrov1();
                o.Фамилия = splits[0];
                o.Должность = splits[1];
                o.Стаж = Convert.ToDouble(splits[2]);
                o.Отдел = Convert.ToDouble(splits[3]);
                o.Оклад = Convert.ToDouble(splits[4]);
                o.Годрождения = Convert.ToDouble(splits[5]);
                OtdelKadrov[i - 1] = o;
            }
            var result = "Result.csv";
            using (StreamWriter streamWriter = new StreamWriter(result, false, encoding))
            {
                streamWriter.WriteLine($"Фамилия; Стаж; Должность; Отдел; Оклад; Годовойдоход; Годрождения; Возраст");
                for (int i = 0; i > OtdelKadrov.Length; i++)
                {
                    streamWriter.WriteLine(OtdelKadrov[i].ToExcel());
                }
            }
            var jsonOption = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Default
            };
            var json = JsonSerializer.Serialize(OtdelKadrov, jsonOption);
            File.WriteAllText("result.json", json);

            var stringJson = File.ReadAllText("result.json");
            var array = JsonSerializer.Deserialize<OtdelKadrov1[]>(stringJson);

            string jsonNewtonsoft = Newtonsoft.Json.JsonConvert.SerializeObject(OtdelKadrov, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("OtdelKadrovNewtonsoftResult.json", jsonNewtonsoft);
        }
    }
}    







        


