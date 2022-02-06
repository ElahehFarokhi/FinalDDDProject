using Framework.Domain.Data;

namespace Bazzar.Infrastructures.Data.SQLServer
{
    public class AdvertisementUnitOfWork : IUnitOfWork
    {
        private readonly AdvertisementDBContext _advertisementDBContext;
        public AdvertisementUnitOfWork(AdvertisementDBContext advertisementDBContext)
        {
            _advertisementDBContext = advertisementDBContext;
        }

        public int Commit()
        {
            return _advertisementDBContext.SaveChanges();
        }
    }
}
