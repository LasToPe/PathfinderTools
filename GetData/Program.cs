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
            GetData.ScrapeSpells.GetSpells();
            Console.ReadLine();
        }
    }
}
