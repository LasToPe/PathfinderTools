using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundLib
{
    public class Nobility
    {
        public string Name;
        public string Description;

        public Nobility(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static List<Nobility> Nobilities()
        {
            return new List<Nobility>
            {
                new Nobility("Gentry", "You are the child of a minor lord, lady, or noble with an income, hereditary land such as a manor, and titles. You likely grew up in a manor and your parents were paid tribute by peasants. Your parents serve a higher baron, count, or duke."),
                new Nobility("Knight", "You are the child of a knight, a noble with estates, titles, and lands who serves a lord. Your family has sworn an oath of fealty to a liege—such as a baron, count, or duke—and commits to military service in his or her name. As the child of a knight, you may serve as a squire to another knight while pursuing your own path to knighthood."),
                new Nobility("Baron", "You are the child of a baron or baroness, a noble responsible for a land encompassing several smaller manors that pay tribute. Your parents receive orders directly from the monarch, and you’re expected to attend the royal court.You are entitled to hereditary estates, titles, and land."),
                new Nobility("Count", "You are the noble child of a count or countess. Your family members receive hereditary titles, land, and estates, and are among the most wealthy nobles in your domain. Knights and minor lords pay tribute to your family, and your parents attend directly to the monarch. You’re expected to attend the royal court."),
                new Nobility("Duke", "You are the child of a duke or duchess, the most powerful noble in the realm apart from the royal family. Your parents attend directly to the monarch and have the highest place at court. Your lands, titles, and estates are significant, and many lords and knights serve under your parents’ command."),
                new Nobility("Minor Prince", "You are the child of a prince or princess, and part of the royal family. You aren’t the next in succession, but your power and wealth are grand indeed."),
                new Nobility("Regent", "You are a prince or princess, the son or daughter of the monarch. You owe fealty directly to your parents, and to no one else.Few command the power and wealth you do, and your presence inspires great respect, if not total awe, among those who kneel before the crown.")
            };
        }
    }
}
