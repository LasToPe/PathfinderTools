using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundLib
{
    public class AdoptedOutsideYourRace
    {
        public string Name;
        public string Description;

        public AdoptedOutsideYourRace(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static List<AdoptedOutsideYourRace> AdoptedRace()
        {
            return new List<AdoptedOutsideYourRace>
            {
                new AdoptedOutsideYourRace("Adopted by Dragons", "For its own purposes, a dragon raised you as its own. You have learned the language and history, wisdom, power, and might of dragonkind."),
                new AdoptedOutsideYourRace("Adopted by the Fey", "Your adoptive parents were fey creatures such as korreds, pixies, or a dryad."),
                new AdoptedOutsideYourRace("Raised Among the Dead", "Your adoptive parent is a nonliving creature, such as a spectre, ghost, lich, or vampire. You were likely raised in empty ruined halls, among tombs and crypts, by a creature that feeds on life. What its purpose was for raising you, none can say."),
                new AdoptedOutsideYourRace("Raised by Angels", "Angels attended your birth and took you to live with them in the heavens. These cosmic beings expanded your view to encompass not just the world but the larger universe. You know that wherever you go, your angelic parents watch over you."),
                new AdoptedOutsideYourRace("Raised by Beasts", "When you were separated from your biological parents, you were found and raised by wild beasts. Your ways are the ways of the wild, and along with your advanced survival instincts you’ve adopted the natural habits of a specific beast."),
                new AdoptedOutsideYourRace("Raised by Civilized Humanoids", "You were raised by a community of civilized humanoids of a race different from your own (chosen by your GM). Your attitudes, beliefs, and values reflect that race, although characteristics of your true nature frequently emerge."),
                new AdoptedOutsideYourRace("Raised by Savage Humanoids", "You were raised by savage humanoids such as orcs, kobolds, gnolls, troglodytes, or lizardfolk. As a result, your values, customs, and traditions are those of your adoptive parents, though characteristics of your true nature frequently emerge."),
                new AdoptedOutsideYourRace("Fiend Raised", "You were separated from your natural parents and raised by a fiend who taught you the cruelty and malice of the gods and worked to fashion you into its own mortal instrument to corrupt innocent souls.")
            };
        }
    }
}
