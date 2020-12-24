using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;


namespace news
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "f429c8329e0d46c4b309e26a040e906f";

            string url = "http://newsapi.org/v2/top-headlines?country=ru&apiKey=" + key;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();


            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                Root root = JsonConvert.DeserializeObject<Root>(result);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Свежие новости:\n");
                Console.ResetColor();
                foreach (Article article in root.Articles)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Источник: " + article.Source.Name);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("\nЗаголовок: " + article.Title);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nОписание: " + article.Description + "\nСсылка на новость в источнике: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(article.Url);
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
    }
}



