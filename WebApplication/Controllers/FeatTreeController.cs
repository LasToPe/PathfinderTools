using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TreeStructure;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class FeatTreeController : Controller
    {
        private static readonly FeatTreeModel featTreeModel = new FeatTreeModel();

        public FeatTreeController()
        {
            featTreeModel.FeatTree = new FeatTree(GetData.Scrape.GetSpecificFeats(7));
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
            var results = allResults.Where(n => n.Parents.Count() == 0).Select(f => f.Value.Name);

            return Json(results);
        }
    }
}