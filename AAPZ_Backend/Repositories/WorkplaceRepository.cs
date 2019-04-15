using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AAPZ_Backend.Models;


namespace AAPZ_Backend.Repositories
{
    public class WorkplaceRepository : IDBActions<Workplace>
    {
        private SheringDBContext sheringDBContext;

        public WorkplaceRepository()
        {
            this.sheringDBContext = new SheringDBContext();
        }

        public IEnumerable<Workplace> GetEntityList()
        {
            return sheringDBContext.Workplace;
        }

        public Workplace GetEntity(object id)
        {
            return sheringDBContext.Workplace.SingleOrDefault(x => x.Id == (int)id);
        }

        public void Create(Workplace workplace)
        {
            sheringDBContext.Workplace.Add(workplace);
        }

        //public Client GetClient(string tokenId)
        //{
        //    Client client = sheringDBContext.Client.Where(x => x.IdentityId == tokenId).FirstOrDefault();
        //    return client;
        //}

        public void Update(Workplace workplace)
        {
            sheringDBContext.Entry(workplace).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            Workplace workplace = sheringDBContext.Workplace.Find(id);
            if (workplace != null)
                sheringDBContext.Workplace.Remove(workplace);
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
