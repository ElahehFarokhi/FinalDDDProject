using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazzar.Domain.Advertisements.Entities;

namespace Bazzar.Domain.Advertisements.Data
{
    public interface IAdvertisementRepository
    {
        bool Exists(Guid id);
        Advertisement Load(Guid id);
        void Add(Advertisement entity);
        void Update(Advertisement entity);
    }
}
