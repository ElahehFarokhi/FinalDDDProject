using Bazzar.Domain.Advertisements.Commands;
using Bazzar.Domain.Advertisements.Data;
using Bazzar.Domain.Advertisements.ValueObjects;
using Framework.Domain.ApplicationService;
using Framework.Domain.Data;
using System;

namespace Bazzar.Core.ApplicationServices.Advertisements.CommandHandler
{
    public class UpdateTextHandler : ICommandHandler<UpdateText>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdvertisementRepository _advertisementRepository;
        public UpdateTextHandler(IUnitOfWork unitOfWork, IAdvertisementRepository advertisementRepository)
        {
            _unitOfWork = unitOfWork;
            _advertisementRepository = advertisementRepository;
        }

        public void Handle(UpdateText command)
        {
            var advertisment = _advertisementRepository.Load(command.Id);
            if (advertisment == null)
            {
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد");
            }
            advertisment.UpdateText(AdvertisementText.FromString(command.Text));
            _advertisementRepository.Update(advertisment);
            _unitOfWork.Commit();
        }
    }
}
