using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundLib
{
    public class Sibling
    {
        public string Name;

        public Sibling() { }

        public Sibling(string name)
        {
            Name = name;
        }

        public List<Sibling> DwarfSiblings()
        {
            return new List<Sibling>
            {
                new Sibling("1d4 biological siblings"),
                new Sibling("1d4+1 biological siblings"),
                new Sibling("1d3–1 biological siblings and 1d3–1 adopted siblings"),
                new Sibling("No siblings")
            };
        }

        public List<Sibling> ElfSiblings()
        {
            return new List<Sibling>
            {
                new Sibling("1d2 biological siblings"),
                new Sibling("1d4+1 biological siblings"),
                new Sibling("1d4+1 biological siblings. 1d3–1 of these siblings are half-elves, adopted, or a mix of the two"),
                new Sibling("No siblings")
            };
        }

        public List<Sibling> GnomeSiblings()
        {
            return new List<Sibling>
            {
                new Sibling("1d4 biological siblings"),
                new Sibling("1d4-1 biological siblings and one adopted sibling"),
                new Sibling("No siblings")
            };
        }

        public List<Sibling> HalfElfSiblings()
        {
            return new List<Sibling>
            {
                new Sibling("1d2 half-siblings, either elf or human"),
                new Sibling("One half-elf sibling"),
                new Sibling("No siblings")
            };
        }

        public List<Sibling> HalfOrcSiblings()
        {
            return new List<Sibling>
            {
                new Sibling("1d6+1 orc siblings"),
                new Sibling("1d4 human siblings"),
                new Sibling("One half-orc sibling"),
                new Sibling("No siblings")
            };
        }

        public List<Sibling> HalflingSiblings()
        {
            return new List<Sibling>
            {
                new Sibling("1d2 siblings"),
                new Sibling("1d4+1 siblings"),
                new Sibling("No siblings")
            };
        }

        public List<Sibling> HumanSiblings()
        {
            return new List<Sibling>
            {
                new Sibling("1d2 siblings"),
                new Sibling("1d2 siblings and 1d2 half-siblings"),
                new Sibling("2d4 siblings"),
                new Sibling("No siblings")
            };
        }

        public List<Sibling> AdoptedSiblings()
        {
            return new List<Sibling>
            {
                new Sibling("Aasimar"),
                new Sibling("Catfolk"),
                new Sibling("Changeling"),
                new Sibling("Dhampir"),
                new Sibling("Duergar"),
                new Sibling("Dwarf"),
                new Sibling("Elf"),
                new Sibling("Fetchling"),
                new Sibling("Gillman"),
                new Sibling("Gnome"),
                new Sibling("Goblin"),
                new Sibling("Grippli"),
                new Sibling("Half-Elf"),
                new Sibling("Half-Orc"),
                new Sibling("Halfling"),
                new Sibling("Hobgoblin"),
                new Sibling("Human"),
                new Sibling("Ifrit"),
                new Sibling("Kitsune"),
                new Sibling("Kobold"),
                new Sibling("Merfolk"),
                new Sibling("Nagaji"),
                new Sibling("Orc"),
                new Sibling("Oread"),
                new Sibling("Ratfolk"),
                new Sibling("Samsaran"),
                new Sibling("Strix"),
                new Sibling("Suli"),
                new Sibling("Svirneblin"),
                new Sibling("Sylph"),
                new Sibling("Tengu"),
                new Sibling("Tiefling"),
                new Sibling("Undine"),
                new Sibling("Vanara"),
                new Sibling("Vishkanya"),
                new Sibling("Wayang")
            };
        }
    }
}
