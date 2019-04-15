using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAPZ_Backend.BusinessLogic.Classes
{
    public class SearchingViewModel
    {
        public int Radius { get; set; }
        public int WantedCost { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public List<SearchingModel> SearchingModel { get; set; }
    }
}
