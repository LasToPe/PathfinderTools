using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundLib
{
    public class CircumstanceOfBirth
    {
        public string Name;
        public string Description;

        public CircumstanceOfBirth(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static List<CircumstanceOfBirth> CircumstancesOfBirth()
        {
            return new List<CircumstanceOfBirth>
            {
                new CircumstanceOfBirth("Lower-Class Birth", "You were born among peasants or slum denizens. You grew up working the land around a village or manor, practicing a rudimentary trade, or begging in a settlement."),
                new CircumstanceOfBirth("Middle-Class Birth", "You were born to the middle class, which includes merchants, artisans, and tradespeople.You likely grew up in a good-sized settlement, and one of your parents is likely associated with a guild or other trade organization. As a free person, you don’t experience the bondage of serfdom or peasantry, but you also lack the privilege of the nobility."),
                new CircumstanceOfBirth("Noble Birth", "You were born to privilege among the nobility. Unless one of your parents is the regent, your family serves a higher-ranked noble but lesser nobles serve your family in turn."),
                new CircumstanceOfBirth("Adopted Outside Your Race", "You were not raised by your birth family and grew up in a family of a different race than your own."),
                new CircumstanceOfBirth("Adopted", "You were not raised by your birth family, but taken in by another family within your race or culture."),
                new CircumstanceOfBirth("Bastard Born", "Your parents had a tryst that resulted in your birth out of wedlock. You know one of your parents, but the other remains unknown or a distant presence at best."),
                new CircumstanceOfBirth("Blessed Birth", "When you were born, you were blessed by a being of great power such as an angel, azata, or genie. This blessing has protected you from certain peril or marked you as special to some deity."),
                new CircumstanceOfBirth("Born of Violence", "Your birth was caused by violent, unwilling means. You have one parent, and the other likely remains unknown."),
                new CircumstanceOfBirth("Born out of Time", "You were born in a different era, either the distant past or the far future. Some event has displaced you from your time, and the ways and customs of the present seem strange and alien to you."),
                new CircumstanceOfBirth("Born into Bondage", "You were born into slavery or servitude. Your parents are likely slaves or servants, or you were sold into slavery as an infant."),
                new CircumstanceOfBirth("Cursed Birth", "When you were born, a powerful fiendish entity tainted your blood in some way and cursed you as an agent of dark prophecy."),
                new CircumstanceOfBirth("Dishonered Family", "You were born into a family that once was honored among your society but has since fallen into disgrace. Now your family name is loathed and maligned by those who know it, putting you on your guard."),
                new CircumstanceOfBirth("Heir to a Legacy", "You are the heir to a family with an old name and a distinguished past. Your family might be wealthy or middle class, but your name itself is worth twice your fortunes."),
                new CircumstanceOfBirth("Left to Die", "When you were born you were left to die, but by some twist of circumstance you survived."),
                new CircumstanceOfBirth("Marked by the Gods", "A deity has marked you. That mark can be on your body or your soul."),
                new CircumstanceOfBirth("Energy Infused", "During your birth you were exposed to potent source of divine energy."),
                new CircumstanceOfBirth("Progeny of Power","You were born during a particularly powerful conjunction or in some other time of power."),
                new CircumstanceOfBirth("Prophesied", "Your birth was foretold, as recently as during the last generation to as far back as thousands of years ago."),
                new CircumstanceOfBirth("Reincarnated", "You have been reborn in many cycles, and may be reborn in many more until you accomplish the ultimate task for which you are destined."),
                new CircumstanceOfBirth("The Omen", "The sages, priests, or wizards of your society decreed your birth an omen of a coming age or event—perhaps you are an omen of promise, perhaps one of dark times ahead.")
            };
        }
    }
}
