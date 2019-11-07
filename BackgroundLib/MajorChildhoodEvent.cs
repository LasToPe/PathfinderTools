using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundLib
{
    public class MajorChildhoodEvent
    {
        public string Name;
        public string Description;

        public MajorChildhoodEvent(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static List<MajorChildhoodEvent> MajorChildhoodEvents()
        {
            return new List<MajorChildhoodEvent>
            {
                new MajorChildhoodEvent("Academy Training", "You attended a private academy where you studied a number of skills and gained training in your current profession. Whether you were a brilliant student or a dropout, the university environment was your home for a good portion of your formative years."),
                new MajorChildhoodEvent("Betrayal", "A friend or family member whom you trusted more than anyone else betrayed you. You have never fully trusted anyone since and prefer to rely on your own abilities rather than place your trust in others."),
                new MajorChildhoodEvent("Bullied", "In your early life, you were a victim — easy prey for those stronger or cleverer than yourself.They beat you when they could, using you for their sport. This abuse nursed a powerful flame of vengeance."),
                new MajorChildhoodEvent("Competition Champion", "You distinguished yourself at an early age when you won a competition. This might have been a martial contest of arms, a showing of apprentice magicians, high stakes gambling, or something mundane like an eating championship."),
                new MajorChildhoodEvent("Death in the Family", "You were profoundly affected by the death of the relative closest to you — a parent, grandparent, favorite sibling, aunt, uncle, or cousin. This death affected you profoundly, and you’ve never been able to let go of it."),
                new MajorChildhoodEvent("Died", "You died, or came so close to death that you walked the boundary between the realms of the living and the dead. Having passed from life’s domain once, you have a unique perspective on life, perhaps even a greater appreciation for it — or maybe your experience caused you to reject all trivial things, focusing only on matters of true import."),
                new MajorChildhoodEvent("Fall of a Major Power", "In your early years, an old power with far-reaching influence fell into decline. This could have been an empire, a major organization or gang, or a person such as a benevolent king or evil dictator. Your early memories were founded in a world where this great power affected your region for good or ill."),
                new MajorChildhoodEvent("Fell in with a Bad Crowd", "In your youth, you ran with a brutal, evil, or sadistic crowd. You might have belonged to a gang, a thieves’ guild, or some other nefarious organization. It was easy to cave in to pressure and do whatever they told you to do, and your outlook is colored by moral ambiguity."),
                new MajorChildhoodEvent("First Kill", "You’ve had blood on your hands since your youth, when you first took the life of another creature. Whether this act repulsed you or gave you pleasure, it was a formative experience."),
                new MajorChildhoodEvent("Troubled First Love", "Your first love was everything you imagined it would be. That is, until you were separated from your beloved. This may have been the result of distance, changing perspectives, death, or differences in class or family. Some have said this made you jaded — you think it has granted you insight on how the world really works."),
                new MajorChildhoodEvent("Imprisoned", "Your criminal record began when you were young. You were imprisoned, punished, and possibly displayed in public as a criminal. Whether or not you committed the crime, the experience has stayed with you."),
                new MajorChildhoodEvent("Inheritance", "A great sum of wealth or property was bequeathed to you at an early age, providing you with extraordinary means. Daily costs of living have ceased to concern you, and you’ve learned that there is little that money cannot buy."),
                new MajorChildhoodEvent("Kidnapped", "You were kidnapped at some point in your childhood. The kidnappers might have been pirates, slavers, thieves looking for ransom, a powerful guild seeking to blackmail your parents, a cult, and so on else.Before you were released, were ransomed, or escaped, you picked up on various aspects of the criminal underworld."),
                new MajorChildhoodEvent("Magical Gift", "When you were a child, you found, stole, or were given a magic item that gave you an extraordinary ability. You may have used this item for mischief, crime, or good.Since that time, magic items have always held a special fascination for you."),
                new MajorChildhoodEvent("Major Disaster", "You witnessed — and survived — a major disaster in your childhood years, such as a great fire, flood, earthquake, volcano, or storm. It obliterated the settlement where you lived, whether a small village, large city, or entire island."),
                new MajorChildhoodEvent("Mentorship/Patronage", "A mentor or patron took an interest in your development and volunteered to train or sponsor you. This creature’s motives might not be entirely clear, but without its influence you would not be who you are."),
                new MajorChildhoodEvent("Met a Fantastic Creature", "When you were only a child, you made contact with a magical creature, such as a dragon, unicorn, genie, pixie, or similar creature. You learned a powerful lesson or a magic trick from that creature. This meeting changed your life and made you different from the other children."),
                new MajorChildhoodEvent("Ordinary Childhood", "Your childhood was fairly ordinary, with no major blessing or catastrophe — a stark contrast to an adventuring life. You lived your life in anticipation of growing up so you could affect the dull backdrop upon which your mundane life was painted. Now that you’ve grown, it’s easy to miss those tranquil days where nothing ever seemed to happen."),
                new MajorChildhoodEvent("Raiders", "A horde of raiders attacked your settlement and killed several of your people. This could have been a tribe of brutal humanoids or the conquering army of a civilized nation. As a result, you harbor deep resentment toward a particular faction, race, or country."),
                new MajorChildhoodEvent("The War", "You grew up against the backdrop of a major military conflict that affected much of your childhood world. You became accustomed to a short food supply, living in occupied territory, and moving from place to place. Several of the people you knew in your childhood were lost in the war, including members of your family."),
            };
        }
    }
}
