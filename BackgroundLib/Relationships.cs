using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundLib
{
    public class Relationship
    {
        public string Name;
        public string Description;

        public Relationship(string name, string description = null)
        {
            Name = name;
            Description = description;
        }

        public static List<Relationship> RomanticRelationships()
        {
            return new List<Relationship>
            {
                new Relationship("One Significant Relationship", "You had a true love once, but that time has passed."),
                new Relationship("A Few Significant Relationships", "You’ve tried to make deep connections with individuals on several occasions, but it’s never worked out."),
                new Relationship("Several Significant Relationships", "You’ve engaged in a number of partnerships, but for some reason or another your relationships always fail."),
                new Relationship("Current Lover", "You are currently involved in a romantic relationship. You gain access to the True Love story feat."),
                new Relationship("Several Inconsequential Relationships", "You have had many lovers but no long-lasting, meaningful relationships."),
                new Relationship("Experience but No Substantial Relationships", "You’ve had a fling or two, but have so far shied away from any ties or commitments."),
                new Relationship("No Experience", "You have never experienced any kind of romantic connection whatsoever."),
            };
        }

        public static List<Relationship> RelationshipsWithFellowAdventurers()
        {
            return new List<Relationship>
            {
                new Relationship("Family or close as family—close friends, close/distant relatives, relatives by marriage/adoption"),
                new Relationship("Friend of a friend"),
                new Relationship("Tavern buddies"),
                new Relationship("Hunting companions"),
                new Relationship("Business associates, current or former"),
                new Relationship("Contractor and employer"),
                new Relationship("Former allies"),
                new Relationship("Former enemies"),
                new Relationship("Friendly competitors"),
                new Relationship("Romantic competitors, current or former"),
                new Relationship("Know each other by reputation only"),
                new Relationship("Former inmates (prison, asylum, or captivity) or former inmate and captor"),
                new Relationship("Criminal connections"),
                new Relationship("Servants or apprentices to the same master"),
                new Relationship("Met on a pilgrimage, caravan, or journey"),
                new Relationship("Veterans of a skirmish or war"),
                new Relationship("Follow (or followed) the same faith or cult"),
                new Relationship("Best friends"),
                new Relationship("Gaming or gambling associates"),
                new Relationship("From the same hometown or region"),
            };
        }
    }
}
