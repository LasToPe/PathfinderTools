using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundLib
{
    public class ParentsProfession
    {
        public string Name;

        public ParentsProfession(string name)
        {
            Name = name;
        }

        public static List<ParentsProfession> ParentsProfessions()
        {
            return new List<ParentsProfession>
            {
                new ParentsProfession("Slaves"),
                new ParentsProfession("Serfs/Peasants"),
                new ParentsProfession("Entertainers"),
                new ParentsProfession("Soldiers"),
                new ParentsProfession("Sailors"),
                new ParentsProfession("Thieves"),
                new ParentsProfession("Yeomen"),
                new ParentsProfession("Tradespeople"),
                new ParentsProfession("Artisans"),
                new ParentsProfession("Merchants"),
                new ParentsProfession("Clergy or Cultists")
            };
        }
    }
}
