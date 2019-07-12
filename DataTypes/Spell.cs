using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypes
{
    public class Spell
    {
        public string Name { get; set; }
        public Dictionary<string, int> Level { get; set; }
        public string Description { get; set; }
        public School School { get; set; }
        public string SchoolString { get; set; }
        public Subschool Subschool { get; set; }
        public string SubschoolString { get; set; }
        public IEnumerable<string> Components { get; set; }
        public string CastingTime { get; set; }
        public string Range { get; set; }
        public string Duration { get; set; }
        public string SavingThrow { get; set; }
        public bool SpellResistance { get; set; }
        public string SrString { get; set; }
        public string Link { get; set; }

        public Spell(string name, Dictionary<string, int> level, string description, School school, Subschool subschool, IEnumerable<string> components, CastingTime castingTime, Range range, Duration duration, SavingThrow save, bool spellResistance)
        {
            Name = name;
            Level = level;
            Description = description;
            School = school;
            SchoolString = school.ToString();
            Subschool = subschool;
            SubschoolString = subschool.ToString();
            Components = components;
            CastingTime = GetCastingTimeString(castingTime);
            Range = GetRangeString(range);
            Duration = GetDurationString(duration);
            SavingThrow = GetSavingThrowString(save);
            SpellResistance = spellResistance;
            SrString = GetSrString(spellResistance);

            Link = "https://aonprd.com/SpellDisplay.aspx?ItemName=" + Name;
        }

        private string GetCastingTimeString(CastingTime castingTime)
        {
            switch(castingTime)
            {
                case DataTypes.CastingTime.FullRound: return "Full-round action";
                case DataTypes.CastingTime.Minute: return "1 minute";
                case DataTypes.CastingTime.Standard: return "1 standard action";
                case DataTypes.CastingTime.Swift: return "1 swift action";
                default: return null;
            }
        }

        private string GetRangeString(Range range)
        {
            switch(range)
            {
                case DataTypes.Range.Personal: return range.ToString();
                case DataTypes.Range.Touch: return range.ToString();
                case DataTypes.Range.Close: return range.ToString() + " (25 ft. + 5 ft./2 levels)";
                case DataTypes.Range.Medium: return range.ToString() + " (100 ft. + 10 ft./level)";
                case DataTypes.Range.Long: return range.ToString() + " (400 ft. + 40 ft./level)";
                case DataTypes.Range.Unlimited: return range.ToString();
                default: return null;
            }
        }

        private string GetDurationString(Duration duration)
        {
            switch(duration)
            {
                case DataTypes.Duration.Instantaneous: return duration.ToString();
                case DataTypes.Duration.Permanent: return duration.ToString();
                case DataTypes.Duration.Concentration: return duration.ToString();
                case DataTypes.Duration.Dismissable: return "(D)";
                default: return null;
            }
        }

        private string GetSavingThrowString(SavingThrow save)
        {
            switch(save)
            {
                case DataTypes.SavingThrow.FortitudeHalves: return "Fortitude Half";
                case DataTypes.SavingThrow.FortitudeNegates: return "Fortitude Negates";
                case DataTypes.SavingThrow.FortitudePartial: return "Fortitude Partial";
                case DataTypes.SavingThrow.ReflaxHalves: return "Reflex Half";
                case DataTypes.SavingThrow.ReflexNegates: return "Reflex Negates";
                case DataTypes.SavingThrow.ReflexPartial: return "Reflex Partial";
                case DataTypes.SavingThrow.WillHalves: return "Will Half";
                case DataTypes.SavingThrow.WillNegates: return "Will Negates";
                case DataTypes.SavingThrow.WillPartial: return "Will Partial";
                default: return null;
            }
        }

        private string GetSrString(bool spellResistance)
        {
            if(spellResistance)
            {
                return "Yes";
            }
            return "No";
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public enum School
    { 
        Abjuration,
        Conjuration,
        Divination,
        Enchantment,
        Evocation,
        Illusion,
        Necromancy,
        Transmutation
    }

    public enum Subschool
    {
        //Abjuration
            //none...
        //Conjuration
        Calling,
        Healing,
        Summoning,
        Teleportation,
        //Divination
        Scrying,
        //Enchantment
        Charm,
        Compulsion,
        //Evocation
            //none...
        //Illusion
        Figment,
        Glamer,
        Phantasm,
        Shadow,
        //Necromancy
            //none...
        //Transmutation
        Polymorph
    }

    public enum CastingTime
    {
        FullRound,
        Minute,
        Standard,
        Swift
    }

    public enum Range
    {
        Personal,
        Touch,
        Close,
        Medium,
        Long,
        Unlimited,
        Feet
    }

    public enum Duration
    {
        Timed,
        Instantaneous,
        Permanent,
        Concentration,
        Dismissable
    }

    public enum SavingThrow
    {
        FortitudeNegates,
        FortitudePartial,
        FortitudeHalves,
        ReflexNegates,
        ReflexPartial,
        ReflaxHalves,
        WillNegates,
        WillPartial,
        WillHalves,
        None
    }
}
