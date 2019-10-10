using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataTypes
{
    public class Feat : IComparable
    {
        public string Name { get; set; }
        public string PrerequisitesString { get; set; }
        public string Description { get; set; }
        public FeatType FeatType { get; set; }
        public List<object> Prerequisites { get; set; } = new List<object>();
        public int BabRequirement { get; set; } = 0;
        public string Link { get; set; }

        public Feat(string name, string prereqs, string description, FeatType featType)
        {
            Name = name;
            PrerequisitesString = prereqs;
            Description = description;
            FeatType = featType;
            Link = "https://aonprd.com/FeatDisplay.aspx?ItemName=" + Name;
        }

        public void SetPrerequisites(IEnumerable<Feat> feats)
        {
            string[] delimiters = new string[] { "," };
            var splitPrereqs = PrerequisitesString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var trimmedPrereqs = new List<string>();
            foreach (var str in splitPrereqs)
                trimmedPrereqs.Add(str.Trim());

            var List = feats.ToList();
            foreach (var prereq in trimmedPrereqs)
            {
                //if (List.Exists(f => f.Name == prereq))
                //{
                //    Prerequisites.Add(List.Where(f => f.Name == prereq).FirstOrDefault());
                //    continue;
                //}
                Prerequisites.Add(prereq);
            }

            if (int.TryParse(Regex.Match(PrerequisitesString, @"(?<=base attack bonus )(\+\d*)").Value, out int number))
                BabRequirement = number;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            try
            {
                var feat = (Feat)obj;
                return Name == feat.Name;
            }
            catch
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var feat = obj as Feat;
            if (feat != null)
                return Name.CompareTo(feat.Name);
            else
                return 1;
        }
    }
    public enum FeatType
    {
        General,
        Achievement,
        Alignment,
        Armor_Mastery,
        Betrayal,
        Blood_Hex,
        Called_Shot,
        Combat,
        Combination,
        Conduit,
        Coven,
        Critical,
        Damnation,
        Esoteric,
        Faction,
        Familiar,
        Gathlain_Court_Title,
        Grit,
        Hero_Point,
        Item_Creation,
        Item_Mastery,
        Meditation,
        Metamagic,
        Origin,
        Panache,
        Performance,
        Shield_Mastery,
        Stare,
        Story,
        Style,
        Targeting,
        Teamwork,
        Trick,
        Weapon_Mastery,
        Words_of_Power
    }
}
