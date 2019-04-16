using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TreeStructure;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class FeatTreeController : Controller
    {
        private static FeatTreeModel featTreeModel;

        public FeatTreeController()
        {
            featTreeModel = new FeatTreeModel();
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
    }
}