using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAPZ_Backend.BusinessLogic.Recomendations
{
    public static class HealthCareRecomendations
    {
        public static double CalculateRecommendedTableHeight(double height)
        {
            return height * 75 / 175; 
        }

        public static double CalculateRecommendedChairHeight(double height)
        {
            return height * 45 / 168;
        }

        public static double GetRecommendedTemperature(int month)
        {
            if (month >= 5 && month <= 10) return 24;
            else return 23;
        }


    }
}
