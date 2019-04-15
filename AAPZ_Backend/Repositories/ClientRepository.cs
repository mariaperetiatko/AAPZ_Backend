using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using AAPZ_Backend.Models;


namespace AAPZ_Backend.Repositories
{
    public class ClientRepository : IDBActions<Client>
    {
        private SheringDBContext sheringDBContext;
        private IMemoryCache cache;

        public ClientRepository(IMemoryCache memoryCache)
        {
            this.sheringDBContext = new SheringDBContext();
            cache = memoryCache;
        }

        public IEnumerable<Client> GetEntityList()
        {
            return sheringDBContext.Client;
        }

        public Client GetEntity(object id)
        {

            Client client = null;
            if (!cache.TryGetValue(id, out client))
            {
                client = sheringDBContext.Client.SingleOrDefault(x => x.Id == (int)id);
                if (client != null)
                {
                    cache.Set(client.Id, client,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                }
            }
            return client;

        }

        public void Create(Client client)
        {
            sheringDBContext.Client.Add(client);
            
            int n = sheringDBContext.SaveChanges();
            if (n > 0)
            {
                cache.Set(client.Id, client, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });
            }
        }

        //public Client GetClient(string tokenId)
        //{
        //    Client client = sheringDBContext.Client.Where(x => x.IdentityId == tokenId).FirstOrDefault();
        //    return client;
        //}

        public void Update(Client client)
        {
            sheringDBContext.Entry(client).State = EntityState.Modified;
            sheringDBContext.SaveChanges();
            cache.Remove(client.Id);
            cache.Set(client.Id, client, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });
        }

        public void Delete(object id)
        {
            Client client = sheringDBContext.Client.Find(id);
            if (client != null)
            {
                sheringDBContext.Client.Remove(client);
                sheringDBContext.SaveChanges();
                cache.Remove(id);
            }
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
