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
        public FeatTree FeatTree { get; set; } = new FeatTree();
        public IEnumerable<Feat> RootFeats { get; set; } = new List<Feat>();
    }
}
