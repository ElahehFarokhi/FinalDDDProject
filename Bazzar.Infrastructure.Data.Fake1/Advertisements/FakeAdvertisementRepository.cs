using Bazzar.Domain.Advertisements.Data;
using Bazzar.Domain.Advertisements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Infrastructure.Data.Fake1.Advertisements
{
    public class FakeAdvertisementRepository : IAdvertisementRepository
    {
        public readonly Dictionary<Guid, Advertisement> db = new Dictionary<Guid, Advertisement>();
        public bool Exists(Guid id)
        {
            return db.ContainsKey(id);
        }

        public Advertisement Load(Guid id)
        {
            return db[id];
        }

        public void Add(Advertisement entity)
        {
            db[entity.Id] = entity;
        }

        public void Update(Advertisement entity)
        {
            throw new NotImplementedException();
        }
    }
}
