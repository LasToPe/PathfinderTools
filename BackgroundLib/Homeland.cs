using System;
using System.Collections.Generic;

namespace BackgroundLib
{
    public class Homeland
    {
        public string Name;
        public string Description;

        public Homeland() { }

        public Homeland(string name, string description = null)
        {
            Name = name;
            Description = description;
        }

        private static readonly Homeland Unusual = new Homeland("Unusual Homeland");

        public List<Homeland> DwarfHomeland()
        {
            return new List<Homeland>
            {
                new Homeland("Hills or Mountain", "You were born and grew up in the hills or on a mountain."),
                new Homeland("Underground", "You were born and grew up underground."),
                new Homeland("Non-Dwarven Town or Village", "You were born and grew up in non-dwarven town or village."),
                new Homeland("Non-Dwarven City or Metropolis", "You were born and grew up in non-dwarven city or metropolis."),
                Unusual
            };
        }

        public List<Homeland> ElfHomeland()
        {
            return new List<Homeland>
            {
                new Homeland("Forest", "You were born and grew up in a forest."),
                new Homeland("Non-Elven City or Metropolis", "You were born and grew up in non-elven city or metropolis."),
                new Homeland("Non-Elven Town or Village", "You were born and grew up in non-elven town or village."),
                Unusual
            };
        }

        public List<Homeland> GnomeHomeland()
        {
            return new List<Homeland>
            {
                new Homeland("Forest", "You were born and grew up in a forest."),
                new Homeland("Non-Gnome Town or Village", "You were born and grew up in non-gnome town or village."),
                new Homeland("Non-Gnome City or Metropolis", "You were born and grew up in non-gnome city or metropolis."),
                Unusual
            };
        }

        public List<Homeland> HalfElfHomeland()
        {
            return new List<Homeland>
            {
                new Homeland("Raised in an Elven Homeland", "You were born and raised in an elven homeland."),
                new Homeland("Raised in a Human Homeland", "You were born and raised in a human homeland."),
                new Homeland("Forest", "You were born and raised in a forest."),
                Unusual
            };
        }

        public List<Homeland> HalfOrcHomeland()
        {
            return new List<Homeland>
            {
                new Homeland("Subterranean", "You were born and raised in a subterranean environment."),
                new Homeland("Orc Settlement", "You were born and raised in an orc settlement."),
                new Homeland("Raised in a Human Homeland", "You were born and raised in a human homeland."),
                new Homeland("No True Homeland", "You have no true homeland. You might be a wanderer or just an outcast no matter where you go."),
                Unusual
            };
        }

        public List<Homeland> HalflingHomeland()
        {
            return new List<Homeland>
            {
                new Homeland("Halfling Settlement", "You were born and grew up in a halfling settlement."),
                new Homeland("Human Settlement", "You were born and grew up in a human settlement."),
                new Homeland("Traveling Band or Caravan", "You were born and grew up as part of a travelling band or caravan."),
                Unusual
            };
        }

        public List<Homeland> HumanHomeland()
        {
            return new List<Homeland>
            {
                new Homeland("Town or Village", "You were born and grew up in a smaller town or village."),
                new Homeland("City or Metropolis", "You were born and grew up in a city or metropolis."),
                new Homeland("Frontier", "You were born and grew up on the frontier."),
                Unusual
            };
        }

        public List<Homeland> UnusualHomeland()
        {
            return new List<Homeland>
            {
                new Homeland("Subterranean", "You were born and raised in a subterranean environment."),
                new Homeland("Mountains", "You were born and raised in the mountains."),
                new Homeland("Plains", "You were born and raised on the plains."),
                new Homeland("Town or Village", "You were born and grew up in a smaller town or village."),
                new Homeland("City or Metropolis", "You were born and grew up in a city or metropolis."),
                new Homeland("Forest", "You were born and raised in a forest."),
                new Homeland("River, Swamp, or Wetlands", "You were born and raised in by a river, swamp or wetlands."),
                new Homeland("Desert", "You were born and raised in the desert."),
                new Homeland("Sea", "You were born and raised at sea."),
                new Homeland("Tundra", "You were born and raised in the tundra."),
                new Homeland("Another Plane", "You were born and raised on another plane."),
            };
        }
    }
}
