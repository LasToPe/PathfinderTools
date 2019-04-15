using DataTypes;
using GetData;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class SearchModel
    {
        public SearchModel()
        {
            ResultModel = new FeatResultModel();
        }

        public string List { get; set; }

        public string Query { get; set; }

        public FeatResultModel ResultModel { get; set; }
    }
}
