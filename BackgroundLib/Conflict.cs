using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundLib
{
    public class Conflict
    {
        public string Name;
        public string Description;
        public int CP;

        public Conflict(string name, string description, int cp)
        {
            Name = name;
            Description = description;
            CP = cp;
        }

        public static List<Conflict> Conflicts()
        {
            return new List<Conflict>
            {
                new Conflict("Minor Failure", "You failed a friend, family member, or loved one who depended on you to fulfill an important task.", 1),
                new Conflict("Petty Crime", "You committed a minor crime, like vandalism, trespassing, or mischief.", 1),
                new Conflict("Told a Lie", "You deliberately made someone believe something that was not true to further your own goals.", 1),
                new Conflict("Broke a Promise", "You swore an oath or vow that was important to someone else, but you did not keep your promise.", 1),
                new Conflict("Humiliation", "You publicly humiliated or scandalized someone with either true or slanderous information.", 2),
                new Conflict("Negligence", "You caused someone else to suffer by your own inaction, disregard, or excessive recklessness.", 2),
                new Conflict("Minor Theft", "You stole several small or inexpensive items that belonged to someone else.", 2),
                new Conflict("Seducer", "You tempted or manipulated someone to act in accordance with your whim, careless of whether it was in their own best interests.", 3),
                new Conflict("Cheater", "You broke a rule, law, contract, or agreement for your own gain.", 3),
                new Conflict("Betrayal", "You betrayed someone who trusted you.", 4),
                new Conflict("Malign Associates", "You allied with a destructive creature, organization, or individual.", 4),
                new Conflict("Destroyed a Reputation", "You deliberately ruined the honor, reputation, or fortunes of another individual or group.", 5),
                new Conflict("Major Theft", "You stole expensive items.", 5),
                new Conflict("Corrupted an Innocent", "You counseled an otherwise innocent person who trusted you, toward adverse choices.", 6),
                new Conflict("Blackmailed", "You used sensitive knowledge or threats to force someone’s cooperation.", 6),
                new Conflict("Destruction", "You destroyed someone else’s property.", 6),
                new Conflict("Armed Robbery", "You robbed someone with the threat of violence.", 6),
                new Conflict("Violent Crime", "You beat, assaulted, or mutilated someone.", 7),
                new Conflict("Murder", "You killed someone", 8),
                new Conflict("Mass Murder", "You killed several sentient beings.", 12),
            };
        }
    }

    public class ConflictSubject
    {
        public string Name;
        public int CP;

        public ConflictSubject(string name, int cp = 0)
        {
            Name = name;
            CP = cp;
        }

        public static List<ConflictSubject> ConflictSubjects()
        {
            return new List<ConflictSubject>
            {
                new ConflictSubject("Commoner"),
                new ConflictSubject("Merchant"),
                new ConflictSubject("Tradesperson"),
                new ConflictSubject("Artisan"),
                new ConflictSubject("Civic or military official"),
                new ConflictSubject("Noble"),
                new ConflictSubject("Leader"),
                new ConflictSubject("Clergy"),
                new ConflictSubject("Soldier or warrior"),
                new ConflictSubject("Spellcaster"),
                new ConflictSubject("Scoundrel"),
                new ConflictSubject("Child or young person", 1),
                new ConflictSubject("Family member"),
                new ConflictSubject("Close friend"),
                new ConflictSubject("Lover or former lover"),
                new ConflictSubject("Enemy or rival"),
                new ConflictSubject("Gangster or underworld figure"),
                new ConflictSubject("Adventurer"),
                new ConflictSubject("Humanoid monster"),
                new ConflictSubject("Non-humanoid monster"),
            };
        }
    }

    public class ConflictMotivation
    {
        public string Name;
        public int CP;

        public ConflictMotivation(string name, int cp)
        {
            Name = name;
            CP = cp;
        }

        public static List<ConflictMotivation> ConflictMotivations()
        {
            return new List<ConflictMotivation>
            {
                new ConflictMotivation("Justice", 1),
                new ConflictMotivation("Love", 1),
                new ConflictMotivation("Pressured or Manipulated", 2),
                new ConflictMotivation("Religion", 2),
                new ConflictMotivation("Family", 3),
                new ConflictMotivation("Money", 3),
                new ConflictMotivation("Jealousy", 4),
                new ConflictMotivation("Hatred or Malice", 4),
                new ConflictMotivation("Pleasure", 5),
                new ConflictMotivation("Amusement or Entertainment", 5),
            };
        }
    }

    public class ConflictResolution
    {
        public string Name;
        public string Description;
        public int CP;

        public ConflictResolution(string name, string description, int cp)
        {
            Name = name;
            Description = description;
            CP = cp;
        }

        public static List<ConflictResolution> ConflictResolutions()
        {
            return new List<ConflictResolution>
            {
                new ConflictResolution("Regret and Penance", "Not only do you regret your action, but you have publicly admitted to it and did your best to make amends for the wrongdoing. Most know of the conf lict’s details and those who don’t can easily find them out if they know where to look or whom to ask.", -3),
                new ConflictResolution("Sincere Regret", "Though you feel sincere regret for the event and its memory affects your behavior, it’s still a secret.Only your trusted companions know of the conflict, and they have promised a degree of discretion.", -2),
                new ConflictResolution("Secret Regret", "You regret the conf lict, but go to great lengths to keep it secret and try desperately to forget it ever happened. Only you and maybe a select few people know of your involvement in the conf lict.", -1),
                new ConflictResolution("Mixed Feelings", "Sometimes you regret the conf lict, but other times you feel as if you didn’t have a choice in the matter or that you made the right decision. Most of the time, you just avoid thinking about the conf lict.Only you and maybe a select few people know of your involvement.", 0),
                new ConflictResolution("Denial", "You feel little if any regret, and deny the event mostly so others won’t judge you.Few if any know of your part in the conf lict, and your constant denials are meant to keep it that way.", 1),
                new ConflictResolution("No Guilt", "Either guilt is for the weak, or you know you made the right decision. You might not openly brag about your part in the conf lict, but you don’t deny it when confronted either.", 2),
                new ConflictResolution("You Enjoyed It", "Those who cling to petty morals have no understanding of what true freedom and power is. The fact is, you enjoyed your part in the conf lict and would do it all over again if the opportunity presented itself.Many people know of your misdeed, and they also realize your complete lack of remorse.", 3)
            };
        }
    }
}
