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
        private Tree tree = new Tree(GetData.Scrape.GetSpecificFeats(7));
        private static FeatTreeModel featTreeModel = null;
        public IActionResult Index()
        {
            if (featTreeModel == null)
            {
                featTreeModel = new FeatTreeModel();
                featTreeModel.RootNodes = tree.GetTreeNodes().Where(n => n.Parents.Count() == 0);
            }
            
            return View(featTreeModel);
        }

        public void SetName(string divId)
        {
            featTreeModel.Name = divId;
        }

        public IActionResult Tree(string divId)
        {
            return View("Index", featTreeModel);
        }
    }
}