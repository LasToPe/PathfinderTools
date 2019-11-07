using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class BackgroundCreatorController : Controller
    {
        private BackgroundModel Model = new BackgroundModel();
        public IActionResult Index()
        {
            return View(Model);
        }

        public IActionResult GetHomelandOptions(string race)
        {
            IEnumerable<string> homelandOptions = null;
            switch (race)
            {
                case "Dwarf":
                    homelandOptions = Model.Homeland.DwarfHomeland().Select(h => h.Name);
                    break;
                case "Elf":
                    homelandOptions = Model.Homeland.ElfHomeland().Select(h => h.Name);
                    break;
                case "Gnome":
                    homelandOptions = Model.Homeland.GnomeHomeland().Select(h => h.Name);
                    break;
                case "Half-elf":
                    homelandOptions = Model.Homeland.HalfElfHomeland().Select(h => h.Name);
                    break;
                case "Half-orc":
                    homelandOptions = Model.Homeland.HalfOrcHomeland().Select(h => h.Name);
                    break;
                case "Halfling":
                    homelandOptions = Model.Homeland.HalflingHomeland().Select(h => h.Name);
                    break;
                case "Human":
                    homelandOptions = Model.Homeland.HumanHomeland().Select(h => h.Name);
                    break;
            }
            return new JsonResult(homelandOptions);
        }

        public IActionResult GetSiblingsOptions(string race)
        {
            IEnumerable<string> siblingsOptions = null;
            switch (race)
            {
                case "Dwarf":
                    siblingsOptions = Model.Sibling.DwarfSiblings().Select(h => h.Name);
                    break;
                case "Elf":
                    siblingsOptions = Model.Sibling.ElfSiblings().Select(h => h.Name);
                    break;
                case "Gnome":
                    siblingsOptions = Model.Sibling.GnomeSiblings().Select(h => h.Name);
                    break;
                case "Half-elf":
                    siblingsOptions = Model.Sibling.HalfElfSiblings().Select(h => h.Name);
                    break;
                case "Half-orc":
                    siblingsOptions = Model.Sibling.HalfOrcSiblings().Select(h => h.Name);
                    break;
                case "Halfling":
                    siblingsOptions = Model.Sibling.HalflingSiblings().Select(h => h.Name);
                    break;
                case "Human":
                    siblingsOptions = Model.Sibling.HumanSiblings().Select(h => h.Name);
                    break;
            }
            return new JsonResult(siblingsOptions);
        }

        public IActionResult GetClassBackgrounds(string characterClass)
        {
            IEnumerable<string> classBackgrounds = null;
            switch (characterClass)
            {
                case "Alchemist":
                    classBackgrounds = Model.ClassBackground.AlchemistBackgrounds().Select(c => c.Name);
                    break;
                case "Barbarian":
                    classBackgrounds = Model.ClassBackground.BarbarianBackgrounds().Select(c => c.Name);
                    break;
                case "Bard":
                    classBackgrounds = Model.ClassBackground.BardBackgrounds().Select(c => c.Name);
                    break;
                case "Cavalier":
                    classBackgrounds = Model.ClassBackground.CavalierBackgrounds().Select(c => c.Name);
                    break;
                case "Cleric":
                    classBackgrounds = Model.ClassBackground.ClericBackgrounds().Select(c => c.Name);
                    break;
                case "Druid":
                    classBackgrounds = Model.ClassBackground.DruidBackgrounds().Select(c => c.Name);
                    break;
                case "Fighter":
                    classBackgrounds = Model.ClassBackground.FighterBackgrounds().Select(c => c.Name);
                    break;
                case "Gunslinger":
                    classBackgrounds = Model.ClassBackground.GunslingerBackgrounds().Select(c => c.Name);
                    break;
                case "Inquisitor":
                    classBackgrounds = Model.ClassBackground.InquisitorBackgrounds().Select(c => c.Name);
                    break;
                case "Magus":
                    classBackgrounds = Model.ClassBackground.MagusBackgrounds().Select(c => c.Name);
                    break;
                case "Monk":
                    classBackgrounds = Model.ClassBackground.MonkBackgrounds().Select(c => c.Name);
                    break;
                case "Oracle":
                    classBackgrounds = Model.ClassBackground.OracleBackgrounds().Select(c => c.Name);
                    break;
                case "Paladin":
                    classBackgrounds = Model.ClassBackground.PaladinBackgrounds().Select(c => c.Name);
                    break;
                case "Ranger":
                    classBackgrounds = Model.ClassBackground.RangerBackgrounds().Select(c => c.Name);
                    break;
                case "Rogue":
                    classBackgrounds = Model.ClassBackground.RogueBackgrounds().Select(c => c.Name);
                    break;
                case "Sorcerer":
                    classBackgrounds = Model.ClassBackground.SorcererBackgrounds().Select(c => c.Name);
                    break;
                case "Summoner":
                    classBackgrounds = Model.ClassBackground.SummonerBackgrounds().Select(c => c.Name);
                    break;
                case "Witch":
                    classBackgrounds = Model.ClassBackground.WitchBackgrounds().Select(c => c.Name);
                    break;
                case "Wizard":
                    classBackgrounds = Model.ClassBackground.WizardBackgrounds().Select(c => c.Name);
                    break;
            }
            return new JsonResult(classBackgrounds);
        }

        public IActionResult GetBackstory(string homeland, string parents, string siblings, string circumstanceOfBirth, string nobility, 
            string majorChildhoodEvent, string training, string influencialAssociate, string conflict, string conflictSubject, 
            string conflictMotivation, string conflictResolution, string romanticRelationships, string relationshipWithFellowAdventurers)
        {
            var combinedHomelandList = GetHomelands();
            var combinedClassBackgroundList = GetClassBackgrounds();

            List<string> paragraphs = new List<string>();
            paragraphs.Add(combinedHomelandList.FirstOrDefault(h => h.Name == homeland).Description);
            paragraphs.Add(parents);
            paragraphs.Add("You have " + siblings);
            paragraphs.Add(Model.CircumstancesOfBirth.FirstOrDefault(c => c.Name == circumstanceOfBirth).Description);
            if(nobility != null) { paragraphs.Add(Model.Nobilities.FirstOrDefault(n => n.Name == nobility).Description); }
            paragraphs.Add(Model.MajorChildhoodEvents.FirstOrDefault(m => m.Name == majorChildhoodEvent).Description);
            paragraphs.Add(combinedClassBackgroundList.FirstOrDefault(b => b.Name == training).Description);
            paragraphs.Add(Model.InfluentialAssociates.FirstOrDefault(a => a.Name == influencialAssociate).Description);
            paragraphs.Add(Model.Conflicts.FirstOrDefault(c => c.Name == conflict).Description);
            paragraphs.Add("The subject of the conflict was a " + conflictSubject);
            paragraphs.Add("Your motivation for starting the conflict was " + conflictMotivation);
            paragraphs.Add(Model.ConflictResolutions.FirstOrDefault(r => r.Name == conflictResolution).Description);
            paragraphs.Add(Model.RomanticRelationships.FirstOrDefault(r => r.Name == romanticRelationships).Description);
            paragraphs.Add(Model.RelationshipsWithFellowAdventurers.FirstOrDefault(r => r.Name == relationshipWithFellowAdventurers).Description);

            return new JsonResult(paragraphs);
        }

        private IEnumerable<BackgroundLib.Homeland> GetHomelands()
        {
            return Model.Homeland.DwarfHomeland()
                .Concat(Model.Homeland.ElfHomeland())
                .Concat(Model.Homeland.GnomeHomeland())
                .Concat(Model.Homeland.HalfElfHomeland())
                .Concat(Model.Homeland.HalfOrcHomeland())
                .Concat(Model.Homeland.HalflingHomeland())
                .Concat(Model.Homeland.HumanHomeland());
        }

        private IEnumerable<BackgroundLib.ClassBackground> GetClassBackgrounds()
        {
            return Model.ClassBackground.AlchemistBackgrounds()
                .Concat(Model.ClassBackground.BarbarianBackgrounds())
                .Concat(Model.ClassBackground.BardBackgrounds())
                .Concat(Model.ClassBackground.CavalierBackgrounds())
                .Concat(Model.ClassBackground.ClericBackgrounds())
                .Concat(Model.ClassBackground.DruidBackgrounds())
                .Concat(Model.ClassBackground.FighterBackgrounds())
                .Concat(Model.ClassBackground.GunslingerBackgrounds())
                .Concat(Model.ClassBackground.InquisitorBackgrounds())
                .Concat(Model.ClassBackground.MagusBackgrounds())
                .Concat(Model.ClassBackground.MonkBackgrounds())
                .Concat(Model.ClassBackground.OracleBackgrounds())
                .Concat(Model.ClassBackground.PaladinBackgrounds())
                .Concat(Model.ClassBackground.RangerBackgrounds())
                .Concat(Model.ClassBackground.RogueBackgrounds())
                .Concat(Model.ClassBackground.SorcererBackgrounds())
                .Concat(Model.ClassBackground.SummonerBackgrounds())
                .Concat(Model.ClassBackground.WitchBackgrounds())
                .Concat(Model.ClassBackground.WizardBackgrounds());
        }
    }
}