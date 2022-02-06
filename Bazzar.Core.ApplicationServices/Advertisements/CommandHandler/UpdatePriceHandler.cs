using Bazzar.Domain.Advertisements.Commands;
using Bazzar.Domain.Advertisements.Data;
using Bazzar.Domain.Advertisements.ValueObjects;
using Framework.Domain.ApplicationService;
using Framework.Domain.Data;
using System;

namespace Bazzar.Core.ApplicationServices.Advertisements.CommandHandler
{
    public class UpdatePriceHandler : ICommandHandler<UpdatePrice>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IAdvertisementRepository _advertisementRepository;
        public UpdatePriceHandler(IUnitOfWork unitOfWork,IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
            _unitOfWork = unitOfWork;
        }

        public void Handle(UpdatePrice command)
        {
            var advertisment = _advertisementRepository.Load(command.Id);
            if (advertisment == null)
            {
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد");
            }
            advertisment.UpdatePrice(Price.FromLong(command.Price));
            _advertisementRepository.Update(advertisment);
            _unitOfWork.Commit();
        }
    }
}
