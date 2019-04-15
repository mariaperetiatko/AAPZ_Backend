using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAPZ_Backend.Repositories;
using AAPZ_Backend.Models;

namespace AAPZ_Backend.BusinessLogic.Ordering
{
    public class OrderWorkplace
    {
        IDBActions<Client> clientDB;
        IDBActions<Workplace> workplaceDB;
        IDBActions<WorkplaceOrder> workplaceOrderDB;

        public OrderWorkplace(ClientRepository clientRepository)
        {
            clientDB = clientRepository;
            workplaceDB = new WorkplaceRepository();
            workplaceOrderDB = new WorkplaceOrderRepository();
        }


        public bool isFree(int clientId, int workplaceId, DateTime startTime, DateTime finishTime)
        {
            if (IsWorkplaceFree(workplaceId, startTime, finishTime)
                && IsClientFree(clientId, startTime, finishTime))
                return true;
            return false;
        }


        public bool IsWorkplaceFree(int workplaceId, DateTime startTime, DateTime finishTime)
        {
            List<WorkplaceOrder> workplaceOrders = workplaceOrderDB.GetEntityList()
                 .Where(t => t.WorkplaceId == workplaceId).ToList();
            var dict = workplaceOrders.Select(t => new { t.StartTime, t.FinishTime })
                   .ToDictionary(t => t.StartTime, t => t.FinishTime)
                   .OrderBy(t => t.Key);

            foreach (var item in dict)
            {
                bool isStartTimeBusy = startTime >= item.Key && startTime <= item.Value;
                bool isFinishTimeBusy = finishTime >= item.Key && finishTime <= item.Value;
                bool isMiddletimeBusy = (startTime <= item.Key && finishTime >= item.Value);

                if (isStartTimeBusy || isFinishTimeBusy || isMiddletimeBusy)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsClientFree(int clientId, DateTime startTime, DateTime finishTime)
        {
            List<WorkplaceOrder> workplaceOrders = workplaceOrderDB.GetEntityList()
                 .Where(t => t.ClientId == clientId).ToList();
            var dict = workplaceOrders.Select(t => new { t.StartTime, t.FinishTime })
                   .ToDictionary(t => t.StartTime, t => t.FinishTime)
                   .OrderBy(t => t.Key);

            foreach (var item in dict)
            {
                bool isStartTimeBusy = startTime >= item.Key && startTime <= item.Value;
                bool isFinishTimeBusy = finishTime >= item.Key && finishTime <= item.Value;
                bool isMiddletimeBusy = (startTime <= item.Key && finishTime >= item.Value);

                if (isStartTimeBusy || isFinishTimeBusy || isMiddletimeBusy)
                {
                    return false;
                }
            }
            return true;
        }

        public double CreateOrder(int clientId, int workplaceId, DateTime startTime, DateTime finishTime)
        {
            
                double hourCost = (double)workplaceDB.GetEntity(workplaceId).Cost;
                double totalCost = ((finishTime.Hour - startTime.Hour)
                    + ((finishTime.Minute - startTime.Minute) / 60)) * hourCost;
                return totalCost;
        }


    }
}
