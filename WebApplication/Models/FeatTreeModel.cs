using DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStructure;
using Newtonsoft.Json;

namespace WebApplication.Models
{
    public class FeatTreeModel
    {
        public FeatTreeModel()
        {
        }

        public IEnumerable<TreeNode<Feat>> RootNodes { get; set; } = new List<TreeNode<Feat>>();

        public IEnumerable<Feat> Children
        {
            get
            {
                if (string.IsNullOrEmpty(Name)) return RootNodes.Select(f => f.Value);
                return RootNodes.Where(f => f.Value.Name == Name).FirstOrDefault().Flatten();
            }
        }

        public string Name { get; set; } = "";
    }
}
