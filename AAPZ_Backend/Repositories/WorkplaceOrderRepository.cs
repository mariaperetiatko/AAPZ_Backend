using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AAPZ_Backend.Repositories
{
    public class WorkplaceOrderRepository : IDBActions<WorkplaceOrder>
    {
        private SheringDBContext sheringDBContext;

        public WorkplaceOrderRepository()
        {
            this.sheringDBContext = new SheringDBContext();
        }

        public IEnumerable<WorkplaceOrder> GetEntityList()
        {
            return sheringDBContext.WorkplaceOrder;
        }

        public WorkplaceOrder GetEntity(object id)
        {
            return sheringDBContext.WorkplaceOrder.SingleOrDefault(x => x.Id == (int)id);
        }

        public void Create(WorkplaceOrder workplaceOrder)
        {
            sheringDBContext.WorkplaceOrder.Add(workplaceOrder);
        }

        //public Client GetClient(string tokenId)
        //{
        //    Client client = sheringDBContext.Client.Where(x => x.IdentityId == tokenId).FirstOrDefault();
        //    return client;
        //}

        public void Update(WorkplaceOrder workplaceOrder)
        {
            sheringDBContext.Entry(workplaceOrder).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            WorkplaceOrder workplaceOrder = sheringDBContext.WorkplaceOrder.Find(id);
            if (workplaceOrder != null)
                sheringDBContext.WorkplaceOrder.Remove(workplaceOrder);
        }

        public void Save()
        {
            sheringDBContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    sheringDBContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
