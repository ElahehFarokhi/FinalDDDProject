using Bazzar.Domain.Advertisements.Data;
using Bazzar.Domain.Advertisements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Infrastructures.Data.SQLServer.Advertisements
{
    public class EFAdvertisementRepository : IAdvertisementRepository,IDisposable
    {
        private readonly AdvertisementDBContext _ctx;

        public EFAdvertisementRepository(AdvertisementDBContext ctx)
        {
            _ctx = ctx;
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public bool Exists(Guid id)
        {
            return _ctx.Advertisements.Any(a=>a.Id == id);
        }

        public Advertisement Load(Guid id)
        {
            return _ctx.Advertisements.Find(id);
        }

        public void Add(Advertisement entity)
        {
            _ctx.Advertisements.Add(entity);
            //_ctx.SaveChanges();
        }

        public void Update(Advertisement entity)
        {
            _ctx.Advertisements.Update(entity);
        }
    }
}
