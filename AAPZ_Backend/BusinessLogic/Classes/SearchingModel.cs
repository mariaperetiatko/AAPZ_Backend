using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAPZ_Backend.Models;

namespace AAPZ_Backend.BusinessLogic.Classes
{
    public class SearchingModel
    {
        public int EquipmentId { get; set; }
        public double Importancy { get; set; }

        public SearchingModel(int equipment, double importancy)
        {
            EquipmentId = equipment;
            Importancy = importancy;
        }
    }
}
