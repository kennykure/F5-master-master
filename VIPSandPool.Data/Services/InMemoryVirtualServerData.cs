using System;
using System.Collections.Generic;
using System.Linq;
using VIPSandPool.Data.Models;

namespace VIPSandPool.Data.Services
{
    public class InMemoryVirtualServerData : IVirtualServerData
    {
        List<VirtualServer> virtualservers;
       
        public InMemoryVirtualServerData()
        {
            virtualservers = new List<VirtualServer>();
        }

        public void Add(VirtualServer virtualserver)
        {
            virtualservers.Add(virtualserver);
            virtualserver.Id = virtualservers.Max(r => r.Id) + 1;
        }

        public void Update(VirtualServer virtualserver)
        {
            var existing = Get(virtualserver.Id);
            if(existing != null)
            {
                existing.Name = virtualserver.Name;
                existing.Pool = virtualserver.Pool;
            }
        }
        public VirtualServer Get(int id)
        {
            return virtualservers.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<VirtualServer> GetAll()
        {
            return virtualservers.OrderBy(v => v.Name);
        }

        public void Delete(int id)
        {
            var virtualserver = Get(id);
            if(virtualserver != null)
            {
                virtualservers.Remove(virtualserver);
            }
        }
    }
}
