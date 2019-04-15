using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAPZ_Backend.Models;
using AAPZ_Backend.Repositories;

namespace AAPZ_Backend.BusinessLogic.Statistics
{
    public class WorkplaceStatistics
    {
        IDBActions<WorkplaceOrder> workplaceOrderDB;
        IDBActions<Workplace> workplaceDB;

        public WorkplaceStatistics()
        {
            workplaceOrderDB = new WorkplaceOrderRepository();
            workplaceDB = new WorkplaceRepository();
        }

        public Dictionary<int, double> GetStatisticsByYear(int year, int buildingId)
        {
            List<int> workplaces = workplaceDB.GetEntityList()
                .Where(e => e.BuildingId == buildingId).Select(e => e.Id).ToList();

            List<WorkplaceOrder> workplaceOrders = workplaceOrderDB.GetEntityList()
                .Where(e => workplaces.Contains(e.WorkplaceId) && e.StartTime.Year == year).ToList();

            Dictionary<int, double> yearStatistics = new Dictionary<int, double>();

            for(int i = 1; i <= 12; i++)
                yearStatistics[i] = 0;

            foreach (WorkplaceOrder workplaceOrder in workplaceOrders)
            {
                double hours = workplaceOrder.FinishTime.Hour - workplaceOrder.StartTime.Hour;
                double minutes = workplaceOrder.FinishTime.Minute - workplaceOrder.StartTime.Minute;
                hours += (minutes / 60);

                yearStatistics[workplaceOrder.FinishTime.Month] += hours;
            }

            for (int i = 1; i <= 12; i++)
            {
                double maximumTime = DateTime.DaysInMonth(year, i) * 12;
                double realTime = (workplaces.Count() == 0) ? 0 : yearStatistics[i] / workplaces.Count();
                yearStatistics[i] = realTime / maximumTime;
            }

            return yearStatistics;
        }

        public Dictionary<int, double> GetStatisticsByMonth(int year, int month, int buildingId)
        {
            List<int> workplaces = workplaceDB.GetEntityList()
                .Where(e => e.BuildingId == buildingId).Select(e => e.Id).ToList();

            List<WorkplaceOrder> workplaceOrders = workplaceOrderDB.GetEntityList()
                .Where(e => workplaces.Contains(e.WorkplaceId) && e.StartTime.Year == year
                && e.StartTime.Month == month).ToList();

            Dictionary<int, double> monthStatistics = new Dictionary<int, double>();

            int dayInMonth = DateTime.DaysInMonth(year, month);

            for (int i = 1; i <= dayInMonth; i++)
                monthStatistics[i] = 0;

            foreach (WorkplaceOrder workplaceOrder in workplaceOrders)
            {
                double hours = workplaceOrder.FinishTime.Hour - workplaceOrder.StartTime.Hour;
                double minutes = workplaceOrder.FinishTime.Minute - workplaceOrder.StartTime.Minute;
                hours += (minutes / 60);

                monthStatistics[workplaceOrder.FinishTime.Day] += hours;
            }


            for (int i = 1; i <= dayInMonth; i++)
            {
                double realTime = (workplaces.Count() == 0) ? 0 : monthStatistics[i] / workplaces.Count();
                monthStatistics[i] = realTime / 12;
            }

            return monthStatistics;
        }

        public Dictionary<int, double> GetAverageStatisticsByWeek(int buildingId)
        {
            List<int> workplaces = workplaceDB.GetEntityList()
                .Where(e => e.BuildingId == buildingId).Select(e => e.Id).ToList();

            List<WorkplaceOrder> workplaceOrders = workplaceOrderDB.GetEntityList()
                .Where(e => workplaces.Contains(e.WorkplaceId)).ToList();

            Dictionary<int, double> weekStatistics = new Dictionary<int, double>();

            for (int i = 0; i < 7; i++)
                weekStatistics[i] = 0;

            foreach (WorkplaceOrder workplaceOrder in workplaceOrders)
            {
                double hours = workplaceOrder.FinishTime.Hour - workplaceOrder.StartTime.Hour;
                double minutes = workplaceOrder.FinishTime.Minute - workplaceOrder.StartTime.Minute;
                hours += (minutes / 60);

                weekStatistics[(int)workplaceOrder.FinishTime.DayOfWeek] += hours;
            }

            for (int i = 0; i < 7; i++)
            {
                double realTime = (workplaces.Count() == 0)? 0 : weekStatistics[i] / workplaces.Count();
                weekStatistics[i] = realTime / 12;
            }

            return weekStatistics;
        }


    }
}
