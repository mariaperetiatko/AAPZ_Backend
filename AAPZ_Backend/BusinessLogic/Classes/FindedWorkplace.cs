using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAPZ_Backend.BusinessLogic.Classes
{
    public class FindedWorkplace
    {
        public int WorkplaceId { get; set; }
        public double AppropriationPercentage { get; set; }
        public string AppropriationColor { get; }
        public string CostColor { get; set; }

        public FindedWorkplace(int workplaceId, double appropriationPercentage, double moreExpensive)
        {
            WorkplaceId = workplaceId;
            AppropriationPercentage = appropriationPercentage;

            if (appropriationPercentage >= 75)
                AppropriationColor = "green";
            else if (appropriationPercentage >= 50)
                AppropriationColor = "yellow";
            else if (appropriationPercentage >= 50)
                AppropriationColor = "orange";
            else
                AppropriationColor = "red";        
            
            if(moreExpensive <= 5)
                CostColor = "green";
            else if(moreExpensive <= 25)
                CostColor = "yellow";
            else if (moreExpensive <= 50)
                CostColor = "orange";
            else
                CostColor = "red";


        }
    }
}
