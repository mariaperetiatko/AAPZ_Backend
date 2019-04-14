using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AAPZ_Backend.Repositories
{
    public class ClientRepository : IDBActions<Client>
    {
        private SheringDBContext sheringDBContext;

        public ClientRepository()
        {
            this.sheringDBContext = new SheringDBContext();
        }

        public IEnumerable<Client> GetEntityList()
        {
            return sheringDBContext.Client;
        }
        public Client GetEntity(object id)
        {
            return sheringDBContext.Client.SingleOrDefault(x => x.Id == (int)id);
        }

        public void Create(Client client)
        {
            sheringDBContext.Client.Add(client);
        }

        //public Client GetClient(string tokenId)
        //{
        //    Client client = sheringDBContext.Client.Where(x => x.IdentityId == tokenId).FirstOrDefault();
        //    return client;
        //}

        public void Update(Client client)
        {
            sheringDBContext.Entry(client).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            Client client = sheringDBContext.Client.Find(id);
            if (client != null)
                sheringDBContext.Client.Remove(client);
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
