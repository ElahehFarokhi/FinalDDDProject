using Bazzar.Domain.UserProfiles.Data;
using Bazzar.Domain.UserProfiles.Entities;
using Bazzar.Infrastructures.Data.SQLServer;
using System;
using System.Linq;

namespace Bazzar.Infrastructures.Data.SqlServer.UserProfiles
{
    public class EFUserProfileRepository : IUserProfileRepository, IDisposable
    {
        private readonly AdvertisementDBContext advertismentDbContext;

        public EFUserProfileRepository(AdvertisementDBContext advertismentDbContext)
        {
            this.advertismentDbContext = advertismentDbContext;
        }
        public void Add(UserProfile entity)
        {
            advertismentDbContext.UserProfiles.Add(entity);
        }

        public void Dispose()
        {
            advertismentDbContext.Dispose();
        }

        public bool Exists(Guid id)
        {
            return advertismentDbContext.UserProfiles.Any(c => c.Id == id);
        }

        public UserProfile Load(Guid id)
        {
            return advertismentDbContext.UserProfiles.Find(id);
        }
    }
}
