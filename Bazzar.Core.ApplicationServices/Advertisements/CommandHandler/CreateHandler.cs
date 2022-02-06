using Bazzar.Domain.Advertisements.Commands;
using Bazzar.Domain.Advertisements.Data;
using Bazzar.Domain.Advertisements.Entities;
using Bazzar.Domain.Advertisements.ValueObjects;
using Framework.Domain.ApplicationService;
using Framework.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Core.ApplicationServices.Advertisements.CommandHandler
{
    public class CreateHandler : ICommandHandler<Create>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IAdvertisementRepository _advertisementRepository;
        public CreateHandler(IUnitOfWork unitOfWork ,IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
            _unitOfWork = unitOfWork;
        }
        public void Handle(Create command)
        {
            if (_advertisementRepository.Exists(command.Id))
            {
                throw new InvalidOperationException($"قبلا آگهی با شناسه {command.Id} ثبت شده است");
            }
            var advertisement = new Advertisement(command.Id, new UserId(command.OwnerId));
            _advertisementRepository.Add(advertisement);
            _unitOfWork.Commit();
        }
    }
}
