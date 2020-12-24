using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace weather
{
    class Program
    {
        static void Main(string[] args)
        {

            string key = "a17817e220cd6c70ea3dbb0a584db3e7";
            string city = "";

            Console.WriteLine("Введите название города. \n");
            city = Console.ReadLine();
            Console.WriteLine();

            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&units=metric&appid=" + key;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                weatherMain weatherMain = JsonConvert.DeserializeObject<weatherMain>(result);

                Console.WriteLine("В городе " + weatherMain.Name + " сейчас температура = " + weatherMain.Main.Temp + "градусов по °C \n");

            }
            Console.ReadLine();
        }
    }
}
