using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.IO;

namespace Lab_16_JSON
{
    class Program
    {
        static void Main(string[] args)
        {

            Product[] MyProducts = new Product[5];

            for (int i = 0; i < 5; i++)
            {
                MyProducts[i] = new Product();

                Console.WriteLine("Введите название товара № " + i);
                MyProducts[i].Name = Console.ReadLine();

                Console.WriteLine("Введите код товара № " + i);
                MyProducts[i].Code = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите цену товара № " + i);
                MyProducts[i].Price = Convert.ToDouble(Console.ReadLine());
            }

            string Path = "Выгрузка" + ".txt";
            
            for (int i = 0; i < 5; i++)
            {
                using (StreamWriter sw = new StreamWriter(Path, true))
                {
                    sw.WriteLine(MyProducts[i].ToJSONString());
                }
            }

        }

        class Product
        {
            public string Name { get; set; }
            public int Code { get; set; }
            public double Price { get; set; }
            public string ToJSONString()
            {
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
                };

                return JsonSerializer.Serialize(this, options);
            }
        }
    }
}
