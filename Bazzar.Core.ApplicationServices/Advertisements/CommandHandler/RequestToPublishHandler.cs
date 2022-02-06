using Bazzar.Domain.Advertisements.Commands;
using Bazzar.Domain.Advertisements.Data;
using Framework.Domain.ApplicationService;
using Framework.Domain.Data;
using System;

namespace Bazzar.Core.ApplicationServices.Advertisements.CommandHandler
{
    public class RequestToPublishHandler : ICommandHandler<RequestToPublish>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdvertisementRepository _advertisementRepository;
        public RequestToPublishHandler(IUnitOfWork unitOfWork, IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
            _unitOfWork = unitOfWork;
        }

        public void Handle(RequestToPublish command)
        {
            var advertisment = _advertisementRepository.Load(command.Id);
            if (advertisment == null)
            {
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد");
            }
            advertisment.RequestToPublish();
            _advertisementRepository.Update(advertisment);
            _unitOfWork.Commit();
        }
    }


}
