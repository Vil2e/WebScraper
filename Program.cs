using System;
using HtmlAgilityPack;
using System.Net.Http;

namespace WebScrapper //網路爬蟲練習
{
    class Program
    {
        // 先建立httpClient用GetStringAsync抓資料
        // 再用htmlDocument來載資料
        static void Main(String[] args)
        {   // request data for website
            string url  = "https://weather.com/zh-TW/weather/today/l/TWXX0021:1:TW?Goto=Redirected";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result; // 從網站抓取資料
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html); //把抓到的資料載進來

            // 找出溫度資料
            var temperatureElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class = 'CurrentConditions--tempValue--MHmYY']");
            var temperature = temperatureElement.InnerText.Trim();
            Console.WriteLine("Temperature : " + temperature);

            // 找出天氣狀態
            var conditionElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class = 'CurrentConditions--phraseValue--mZC_p']");
            var condition = conditionElement.InnerText.Trim();
            Console.WriteLine("Conditions : " + condition);

            // 找出位置
            var locationElement = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class = 'CurrentConditions--location--1YWj_']");
            var location = locationElement.InnerText.Trim();
            Console.WriteLine("Location : " + location);

        }
    }
}
