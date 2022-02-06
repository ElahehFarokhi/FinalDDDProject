using Bazzar.Domain.Advertisements.Commands;
using Bazzar.Domain.Advertisements.Data;
using Bazzar.Domain.Advertisements.ValueObjects;
using Framework.Domain.ApplicationService;
using Framework.Domain.Data;
using System;

namespace Bazzar.Core.ApplicationServices.Advertisements.CommandHandler
{
    public class SetTitleHandler : ICommandHandler<SetTitle>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IAdvertisementRepository _advertisementRepository;
        public SetTitleHandler(IUnitOfWork unitOfWork, IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
            _unitOfWork = unitOfWork;
        }

        public void Handle(SetTitle command)
        {
            var advertisment = _advertisementRepository.Load(command.Id);
            if (advertisment == null)
            {
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد");
            }
            advertisment.SetTitle(AdvertisementTitle.FromString(command.Title));
            _advertisementRepository.Update(advertisment);
            _unitOfWork.Commit();
        }
    }
}
