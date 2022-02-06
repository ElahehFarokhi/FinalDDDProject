using Bazzar.Domain.UserProfiles.Commands;
using Bazzar.Domain.UserProfiles.Data;
using Bazzar.Domain.UserProfiles.ValueObjects;
using Framework.Domain.ApplicationService;
using Framework.Domain.Data;
using System;

namespace Bazzar.Core.ApplicationServices.UserProfiles.CommandHandlers
{
    public class UpdateUserDisplayNameHandler : ICommandHandler<UpdateUserDisplayName>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserProfileRepository _userProfileRepository;
        public UpdateUserDisplayNameHandler(IUnitOfWork unitOfWork, IUserProfileRepository userProfileRepository)
        {
            this.unitOfWork = unitOfWork;
            _userProfileRepository = userProfileRepository;
        }
        public void Handle(UpdateUserDisplayName command)
        {
            var user = _userProfileRepository.Load(command.UserId);
            if(user == null)
                throw new InvalidOperationException($"کاربری با شناسه {command.UserId} یافت نشد.");
            user.UpdateDisplayName(DisplayName.FromString(command.DisplayName));
            unitOfWork.Commit();
        }
    }
}
