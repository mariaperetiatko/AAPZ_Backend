using System;
using System.Collections.Generic;
using System.Linq;
using AAPZ_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AAPZ_Backend.Repositories
{
    public class EquipmentRepository : IDBActions<Equipment>
    {
        private SheringDBContext sheringDBContext;

        public EquipmentRepository()
        {
            this.sheringDBContext = new SheringDBContext();
        }

        public IEnumerable<Equipment> GetEntityList()
        {
            return sheringDBContext.Equipment;
        }

        public Equipment GetEntity(object id)
        {
            return sheringDBContext.Equipment.SingleOrDefault(x => x.Id == (int)id);
        }

        public void Create(Equipment equipment)
        {
            sheringDBContext.Equipment.Add(equipment);
        }

        //public Client GetClient(string tokenId)
        //{
        //    Client client = sheringDBContext.Client.Where(x => x.IdentityId == tokenId).FirstOrDefault();
        //    return client;
        //}

        public void Update(Equipment equipment)
        {
            sheringDBContext.Entry(equipment).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            Equipment equipment = sheringDBContext.Equipment.Find(id);
            if (equipment != null)
                sheringDBContext.Equipment.Remove(equipment);
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

