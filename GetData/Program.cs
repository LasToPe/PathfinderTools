using System;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using DataTypes;

namespace WebScrapeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var data = GetData.ScrapeFeats.GetAllFeats();
            var data = GetData.ScrapeFeats.GetSpecificFeats(7);
            GetData.ScrapeFunctions.SaveToJson(data, "CombatFeats.json");
            //Console.ReadLine();

            //var read = "";
            //using (var sr = new StreamReader("Scrape/Feats.json"))
            //{
            //    read = sr.ReadToEnd();
            //}
            //var asFeatList = JsonConvert.DeserializeObject<IEnumerable<Feat>>(read);
        }
    }
}
