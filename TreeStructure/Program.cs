﻿using System;
using GetData;
using System.Linq;

namespace TreeStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var featName = "Dodge";
            var feats = Scrape.GetSpecificFeats(7);
            var tree = new Tree(feats);

            var node = tree.GetTreeNodes().Where(n => n.Value.Name == featName).FirstOrDefault();

            Console.WriteLine($"Node: {node.Value.ToString()}");
            Console.Write("Parents: ");
            node.Parents.ForEach(p => Console.Write(p.Value.ToString() + ", "));
            Console.WriteLine();
            Console.Write("Children: ");
            node.Children.ForEach(c => Console.Write(c.Value.ToString() + ", "));
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}