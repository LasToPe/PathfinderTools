using DataTypes;
using HtmlAgilityPack;
using Newtonsoft.Json;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GetData
{
    public class ScrapeFunctions
    {
        public static void SaveToJson(object o, string path)
        {
            var dirPath = @"Scrape";
            System.IO.Directory.CreateDirectory(dirPath);

            var json = JsonConvert.SerializeObject(o);
            Console.Write(json);
            System.IO.File.WriteAllTextAsync(string.Concat(dirPath, path), json);
        }
    }

    public class ScrapeFeats
    {
        private static readonly string baseuri = "https://aonprd.com/Feats.aspx?Category=";

        private static readonly Dictionary<string, Uri> Links = new Dictionary<string, Uri>
        {
            { "general", new Uri(baseuri) },
            { "achievement", new Uri(baseuri + "Achievement") },
            { "alignment", new Uri(baseuri + "Alignment") },
            { "armorMastery", new Uri(baseuri + "Armor Mastery") },
            { "betrayal", new Uri(baseuri + "Betrayal") },
            { "bloodHex", new Uri(baseuri + "Blood Hex") },
            { "calledShot", new Uri(baseuri + "Called Shot") },
            { "combat", new Uri(baseuri + "Combat") },
            { "combination", new Uri(baseuri + "Combination") },
            { "conduit", new Uri(baseuri + "Conduit") },
            { "coven", new Uri(baseuri + "Coven") },
            { "critical", new Uri(baseuri + "Critical") },
            { "damnation", new Uri(baseuri + "Damnation") },
            { "esoteric", new Uri(baseuri + "Esoteric") },
            { "faction", new Uri(baseuri + "Faction") },
            { "familiar", new Uri(baseuri + "Familiar") },
            { "gathlainCourtTitle", new Uri(baseuri + "Gathlain Court Title") },
            { "grit", new Uri(baseuri + "Grit") },
            { "heroPoint", new Uri(baseuri + "Hero Point") },
            { "itemCreation", new Uri(baseuri + "Item Creation") },
            { "itemMastery", new Uri(baseuri + "Item Mastery") },
            { "meditation", new Uri(baseuri + "Meditation") },
            { "metamagic", new Uri(baseuri + "Metamagic") },
            { "origin", new Uri(baseuri + "Origin") },
            { "panache", new Uri(baseuri + "Panache") },
            { "performance", new Uri(baseuri + "Performance") },
            { "shieldMastery", new Uri(baseuri + "Shield Mastery") },
            { "stare", new Uri(baseuri + "Stare") },
            { "story", new Uri(baseuri + "Story") },
            { "style", new Uri(baseuri + "Style") },
            { "targeting", new Uri(baseuri + "Targeting") },
            { "teamwork", new Uri(baseuri + "Teamwork") },
            { "trick", new Uri(baseuri + "Trick") },
            { "weaponMastery", new Uri(baseuri + "Weapon Mastery") },
            { "wordsOfPower", new Uri(baseuri + "Words of Power") }
        };

        public static IEnumerable<Feat> GetAllFeats()
        {
            var scrape = new ScrapeFeats();

            IEnumerable<Feat>[] featsArray = new IEnumerable<Feat>[Links.Count];
            var enumerator = 0;
            foreach (var link in Links.Values)
            {
                featsArray[enumerator] = scrape.GetFeats(link, (FeatType)enumerator);
                enumerator++;
            }

            var allFeats = new List<Feat>();
            foreach (var List in featsArray)
            {
                allFeats.AddRange(List.Where(fn => allFeats.All(fe => fe.Name != fn.Name)));
            }

            foreach (var feat in allFeats)
            {
                feat.SetPrerequisites(allFeats);
            }

            return allFeats;
        }

        public static IEnumerable<Feat> GetSpecificFeats(int? list)
        {
            if (list == null)
                return GetAllFeats();

            var scrape = new ScrapeFeats();
            var feats = scrape.GetFeats(Links.ElementAt((int)list).Value);
            foreach (var feat in feats)
                feat.SetPrerequisites(feats);

            return feats;
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
                    name = name.Replace("*", "");

                    if(featType == FeatType.General)
                        featType = FeatType.Combat;
                }

                var prereqs = values[1].Trim().Replace("???", "'");
                prereqs = Regex.Replace(prereqs, @"(\&.*)", "-");

                var description = values[2].Trim().Replace("???", "'");
                description = Regex.Replace(description, @"(?<=)(\')(?=\d)", "-");
                description = Regex.Replace(description, @"(?<=\/)(\')(?=)", "-");

                feats.Add(new Feat(name, prereqs, description, featType));
            }

            return feats;
        }
    }

    public class ScrapeSpells
    {
        private static readonly Uri allSpellsUrl = new Uri("https://aonprd.com/Spells.aspx?Class=All");
        private static readonly Uri baseSpellUrl = new Uri("https://aonprd.com/SpellDisplay.aspx?ItemName=");

        public static IEnumerable<Spell> GetSpells()
        {
            ScrapingBrowser browser = new ScrapingBrowser
            {
                AllowAutoRedirect = true,
                AllowMetaRedirect = true
            };

            WebPage page = browser.NavigateToPage(allSpellsUrl);
            HtmlNode node = page.Html.CssSelect("#ctl00_MainContent_DataListTypes").First();

            var names = new List<string>();

            foreach(var n in node.SelectNodes(@"//a"))
            {
                var name = n.InnerText;
                var url = new Uri(string.Concat(baseSpellUrl, name));

                var spellPage = browser.NavigateToPage(url);
                var spellNode = spellPage.Html.CssSelect("#ctl00_MainContent_DataListTypes_ctl00_LabelName").First();
                var text = spellNode.InnerHtml;
                //Regex find headings: (?<=<b>)(.+?)(?=[\<])
                //Regex find values: (?<=<\/b>)(.+?)(?=[\<])
            }

            return null;
        }

        private School GetSchool(string schoolstring)
        {
            Enum.TryParse(schoolstring, out School school);
            return school;
        }
    }
}
