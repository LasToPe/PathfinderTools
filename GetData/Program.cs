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
            var prg = new Program();
            Console.WriteLine("Getting Feats from Archives of Nethys...");

            var generalFeats = prg.GetFeats(new Uri("https://www.aonprd.com/Feats.aspx?Category="));
            var combatFeats = prg.GetFeats(new Uri("https://www.aonprd.com/Feats.aspx?Category=Combat"), FeatType.Combat);
            var combinedFeats = generalFeats.ToList();
            combinedFeats.AddRange(combatFeats.Where(f1 => generalFeats.All(f2 => f2.Name != f1.Name)));

            Console.WriteLine("Ensuring Prerequisites...");
            foreach(var feat in combinedFeats)
            {
                feat.SetPrerequisites(combinedFeats);
            }
            Console.WriteLine("Done setting prerequisites.");

            Console.WriteLine("Saving to Json...");
            using (var writer = new StreamWriter(@"..\WebApplication\wwwroot\content\AllFeats.json"))
            {
                using (var json = new JsonTextWriter(writer))
                {
                    json.Formatting = Formatting.Indented;
                    var serializer = new JsonSerializer();
                    serializer.NullValueHandling = NullValueHandling.Ignore;
                    serializer.Serialize(json, combinedFeats);
                    
                }
            }
            Console.WriteLine("Done!");
            Console.ReadLine();
        }

        public IEnumerable<Feat> GetAllFeats()
        {
            var generalFeats = GetFeats(new Uri("https://www.aonprd.com/Feats.aspx?Category="));
            var combatFeats = GetFeats(new Uri("https://www.aonprd.com/Feats.aspx?Category=Combat"), FeatType.Combat);
            var combinedFeats = generalFeats.ToList();
            combinedFeats.AddRange(combatFeats.Where(f1 => generalFeats.All(f2 => f2.Name != f1.Name)));

            foreach (var feat in combinedFeats)
            {
                feat.SetPrerequisites(combinedFeats);
            }

            return combatFeats;
        }

        public IEnumerable<Feat> GetFeats(Uri uri, FeatType featType = FeatType.General)
        {
            ScrapingBrowser browser = new ScrapingBrowser
            {
                AllowAutoRedirect = true,
                AllowMetaRedirect = true
            };

            WebPage page = browser.NavigateToPage(uri);
            HtmlNode node = page.Html.CssSelect("#ctl00_MainContent_GridView6").First();

            var feats = new List<Feat>();

            foreach (var c in node.SelectNodes("tr"))
            {
                var values = new List<string>();
                foreach (var cn in c.ChildNodes)
                {
                    if (cn.Name == "td")
                        values.Add(cn.InnerText);
                }

                if (values.Count == 0) continue;

                var name = values[0].Trim().Replace("???", "");

                if (name.Contains("*"))
                {
                    featType = FeatType.Combat;
                    name = name.Replace("*", "");
                }

                var prereqs = values[1].Trim().Replace("???", "'");
                var description = values[2].Trim().Replace("???", "'");
                if(RegexTransform(description, @"(\')\d", out var regexOut)) {
                    description = regexOut;
                }

                feats.Add(new Feat(name, prereqs, description, featType));
            }

            return feats;
        }

        private bool RegexTransform(string input, string pattern, out string value)
        {
            value = null;
            var match = Regex.Match(input, pattern);
            if (match.Success)
            {
                var sb = new StringBuilder(input);
                
                foreach (var g in match.Groups)
                {
                    if (g is Match m)
                    {
                        //if (m.Value != "'") continue;

                        sb.Replace("'", "-", m.Index, 1);
                    }
                }
                value = sb.ToString();
                return true;
            }
            return false;
        }
    }

    //public static class StringExtension
    //{
    //    public static bool Contains(this string source, string value, StringComparison comparisonType)
    //    {
    //        return source?.IndexOf(value, comparisonType) >= 0;
    //    }
    //}
}
