using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataTypes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TreeStructure;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class FeatTreeController : Controller
    {
        private static readonly FeatTreeModel featTreeModel = new FeatTreeModel();

        public FeatTreeController()
        {
            //featTreeModel.FeatTree = new FeatTree(GetData.ScrapeFeats.GetSpecificFeats(7));
            IEnumerable<Feat> data;
            using (var sr = new StreamReader("wwwroot/data/CombatFeats.json"))
            {
                var json = sr.ReadToEnd();
                data = JsonConvert.DeserializeObject<IEnumerable<Feat>>(json);
            }
            featTreeModel.FeatTree = new FeatTree(data);
            featTreeModel.RootFeats = featTreeModel.FeatTree.GetTreeNodes().Where(n => n.Parents.Count() == 0).Select(f => f.Value);
        }

        public IActionResult Index(string id)
        {            
            return View(featTreeModel);
        }

        public JsonResult GetChildren(string parent)
        {
            var parentNode = featTreeModel.FeatTree.GetTreeNodes().Where(n => n.Value.Name == parent).FirstOrDefault();
            var childFeats = parentNode.Children.Select(f => f.Value);

            return Json(childFeats);
        }

        public JsonResult TreeSearch(string input)
        {
            var allResults = featTreeModel.FeatTree.GetTreeNodes().Where(n => n.Value.Name.Contains(input, StringComparison.InvariantCultureIgnoreCase));
            var results = allResults.Select(f => new { f.Value.Name, req = f.Parents.Count() != 0 ? f.Parents.FirstOrDefault().Value : null }); // .Where(n => n.Parents.Count() == 0)

            return Json(results);
        }
    }
}