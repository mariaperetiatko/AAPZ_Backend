using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AAPZ_Backend.Models;

namespace AAPZ_Backend.Repositories
{
    public class BuildingRepository : IDBActions<Building>
    {
        private SheringDBContext sheringDBContext;

        public BuildingRepository()
        {
            this.sheringDBContext = new SheringDBContext();
        }

        public IEnumerable<Building> GetEntityList()
        {
            return sheringDBContext.Building;
        }

        public Building GetEntity(object id)
        {
            return sheringDBContext.Building.SingleOrDefault(x => x.Id == (int)id);
        }

        public void Create(Building building)
        {
            sheringDBContext.Building.Add(building);
        }

        //public Client GetClient(string tokenId)
        //{
        //    Client client = sheringDBContext.Client.Where(x => x.IdentityId == tokenId).FirstOrDefault();
        //    return client;
        //}

        public void Update(Building building)
        {
            sheringDBContext.Entry(building).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            Building building = sheringDBContext.Building.Find(id);
            if (building != null)
                sheringDBContext.Building.Remove(building);
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
