using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataTypes;
using GetData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class SearchController : Controller
    {
        private static Dictionary<int, List<Feat>> Lists = new Dictionary<int, List<Feat>>();
        public SearchController()
        {
        }

        public IActionResult Index(SearchModel searchModel)
        {
            if (searchModel == null)
                searchModel = new SearchModel();

            return View(searchModel);
        }

        [ResponseCache(Duration = 300)]
        public async Task<IActionResult> Search(SearchModel searchModel, string List, string Query)
        {
            SearchModel model = await UpdateModel(searchModel, new FeatResultModel());

            if (!string.IsNullOrEmpty(List))
                model.List = List;

            if (!string.IsNullOrEmpty(Query))
                model.Query = Query;

            return View("Index", searchModel);
        }

        private async Task<SearchModel> UpdateModel(SearchModel searchModel, FeatResultModel featResultModel)
        {
            var feats = new List<Feat>();
            int key;
            if (Enum.TryParse(typeof(FeatType), searchModel.List, out var parse))
                key = (int)parse;
            else key = -1;

            if (!Lists.ContainsKey(key))
            {
                feats = await GetFeatsFromAoNAsync(searchModel.List);
            } else
            {
                feats = Lists[key];
            }


            List<Feat> featsOut;
            if (searchModel.Query != null)
            {
                featsOut = feats.Where(f => f.Name.Contains(searchModel.Query, StringComparison.InvariantCultureIgnoreCase)).ToList();
                featsOut.AddRange(feats.Where(f => f.PrerequisitesString.Contains(searchModel.Query, StringComparison.InvariantCultureIgnoreCase)));
                featsOut.AddRange(feats.Where(f => f.Description.Contains(searchModel.Query, StringComparison.InvariantCultureIgnoreCase)));
            }
            else
            {
                featsOut = feats.ToList();
            }

            featsOut = featsOut.Distinct().ToList();
            featsOut.Sort();

            featResultModel.Feats = featsOut;
            searchModel.ResultModel = featResultModel;

            return searchModel;
        }

        private async Task<List<Feat>> GetFeatsFromAoNAsync(string list)
        {
            var feats = new List<Feat>();

            if (Enum.TryParse(typeof(FeatType), list, out var i))
            {
                var key = (int)i;
                feats = await Task.Run(() => ScrapeFeats.GetSpecificFeats(key).ToList());
                UpdateLists(key, feats);
            }
            else
            {
                feats = await Task.Run(() => ScrapeFeats.GetAllFeats().ToList());
                UpdateLists(-1, feats);
            }

            return feats;
        }

        private void UpdateLists(int key, List<Feat> feats)
        {
            if (!Lists.ContainsKey(key))
            {
                Lists.Add(key, feats);
                Lists[key].Sort();
            }
        }
    }
}