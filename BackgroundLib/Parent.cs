using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundLib
{
    public class Parent
    {
        public string Name;

        public Parent(string name)
        {
            Name = name;
        }

        public static List<Parent> GetParents()
        {
            return new List<Parent>
            {
                new Parent("Both of your parents are alive"),
                new Parent("Only your father is alive"),
                new Parent("Only your mother is alive"),
                new Parent("Both of your parents are dead")
            };
        }

        //public static List<Parent> DwarfParents()
        //{
        //    return new List<Parent>
        //    {
        //        new Parent("Both of your parents are alive"),
        //        new Parent("Only your father is alive"),
        //        new Parent("Only your mother is alive"),
        //        new Parent("Both of your parents are dead")
        //    };
        //}

        //public static List<Parent> ElfParents()
        //{
        //    return new List<Parent>
        //    {
        //        new Parent("Both of your parents are alive"),
        //        new Parent("Only your father is alive"),
        //        new Parent("Only your mother is alive"),
        //        new Parent("Both of your parents are dead")
        //    };
        //}

        //public static List<Parent> GnomeParents()
        //{
        //    return new List<Parent>
        //    {
        //        new Parent("Both of your parents are alive"),
        //        new Parent("Only your father is alive"),
        //        new Parent("Only your mother is alive"),
        //        new Parent("Both of your parents are dead")
        //    };
        //}
    }
}
