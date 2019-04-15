using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AAPZ_Backend.Models;


namespace AAPZ_Backend.Repositories
{
    public class LandlordRepository : IDBActions<Landlord>
    {
        private SheringDBContext sheringDBContext;

        public LandlordRepository()
        {
            this.sheringDBContext = new SheringDBContext();
        }

        public IEnumerable<Landlord> GetEntityList()
        {
            return sheringDBContext.Landlord;
        }

        public Landlord GetEntity(object id)
        {
            return sheringDBContext.Landlord.SingleOrDefault(x => x.Id == (int)id);
        }

        public void Create(Landlord landlord)
        {
            sheringDBContext.Landlord.Add(landlord);
        }

        //public Client GetClient(string tokenId)
        //{
        //    Client client = sheringDBContext.Client.Where(x => x.IdentityId == tokenId).FirstOrDefault();
        //    return client;
        //}

        public void Update(Landlord landlord)
        {
            sheringDBContext.Entry(landlord).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            Landlord landlord = sheringDBContext.Landlord.Find(id);
            if (landlord != null)
                sheringDBContext.Landlord.Remove(landlord);
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
