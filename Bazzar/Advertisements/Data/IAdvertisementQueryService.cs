using Bazzar.Domain.Advertisements.Dtoes;
using Bazzar.Domain.Advertisements.Queries;

namespace Bazzar.Domain.Advertisements.Data
{
    public interface IAdvertisementQueryService
    {
        AdvertisementDetail Query(GetActiveAdvertisement query);
        AdvertisementSummary Query(GetActiveAdvertisementList query);
        AdvertisementSummary Query(GetAdvertisementForSpecificSeller query);
    }
}
