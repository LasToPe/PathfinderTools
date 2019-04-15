using DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class FeatResultModel
    {
        public IEnumerable<Feat> Feats { get; set; } = new List<Feat>();
    }
}
