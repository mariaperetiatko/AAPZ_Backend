using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAPZ_Backend.Repositories;
using AAPZ_Backend.Models;
using AAPZ_Backend.BusinessLogic.Classes;


namespace AAPZ_Backend.BusinessLogic.Searching
{
    public class SearchWorkplaces
    {
        IDBActions<Workplace> workplaceDB;
        IDBActions<Building> buildingDB;
        IDBActions<WorkplaceEquipment> workplaceEquipmentDB;
        IDBActions<Equipment> equipmentDB;

        public SearchWorkplaces()
        {
            workplaceDB = new WorkplaceRepository();
            buildingDB = new BuildingRepository();
            workplaceEquipmentDB = new WorkplaceEquipmentRepository();
            equipmentDB = new EquipmentRepository();
        }

        public List<int> SearchInRadius(int radius, double x, double y)
        {          
            List<Building> buildingList = buildingDB.GetEntityList().ToList();
            List<int> resultBuildingList = new List<int>();

            foreach(Building building in buildingList)
            {
                bool isInDistance = Math.Sqrt(Math.Pow(x - (double)building.X, 2)
                    + Math.Pow(y - (double)building.Y, 2)) <= (radius / 111);
                if(isInDistance)
                {
                    resultBuildingList.Add(building.Id);
                }
            }
            return resultBuildingList;               
        }

        public FindedWorkplace GetAppropriationPercentage(List<SearchingModel> searchingModel,
            Workplace workplaceInRadius, int wantedCost)
        {
            List<int> workplaceEquipmentIds = workplaceEquipmentDB.GetEntityList()
                .Where(e => e.WorkplaceId == workplaceInRadius.Id).Select(e => e.EquipmentId)
                .ToList();

            double oneImportancePart = 100 / searchingModel.Count();

            double resultingPercentage = 0;

            foreach(var searchInstance in searchingModel)
            {
                if(workplaceEquipmentIds.Contains(searchInstance.EquipmentId))
                {
                    resultingPercentage += oneImportancePart;
                }
                else
                {
                    resultingPercentage += (oneImportancePart * (1 - searchInstance.Importancy));
                }
            }

            double costPercantage = (workplaceInRadius.Cost * 100 / wantedCost) - 100;

            FindedWorkplace findedWorkplace = new FindedWorkplace(workplaceInRadius.Id, resultingPercentage, costPercantage);

            return findedWorkplace;

        }

        public List<FindedWorkplace> GetAllEstimatedWorkspacecInRadius(List<SearchingModel> searchingModel,
            List<Workplace> workplaceInRadius, int wantedCost)
        {
            List<FindedWorkplace> findedWorkplaces = new List<FindedWorkplace>();
            
            foreach(Workplace workplace in workplaceInRadius)
            {
                findedWorkplaces.Add(GetAppropriationPercentage(searchingModel, workplace, wantedCost));
            }

            return findedWorkplaces;
        }

        public List<FindedWorkplace> PerformSearching(SearchingViewModel searchingViewModel)
        {
            List<int> buildingInRadius = SearchInRadius(searchingViewModel.Radius, searchingViewModel.X, 
                searchingViewModel.Y);

            List<Workplace> workplaceInRadius = workplaceDB.GetEntityList()
                .Where(e => buildingInRadius.Contains(e.BuildingId)).ToList();

            return GetAllEstimatedWorkspacecInRadius(searchingViewModel.SearchingModel, workplaceInRadius,
                searchingViewModel.WantedCost);
        }

    }
}
