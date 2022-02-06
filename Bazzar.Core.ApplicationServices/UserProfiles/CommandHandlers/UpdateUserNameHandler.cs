using Bazzar.Domain.UserProfiles.Commands;
using Bazzar.Domain.UserProfiles.Data;
using Bazzar.Domain.UserProfiles.ValueObjects;
using Framework.Domain.ApplicationService;
using Framework.Domain.Data;
using System;

namespace Bazzar.Core.ApplicationServices.UserProfiles.CommandHandlers
{
    public class UpdateUserNameHandler : ICommandHandler<UpdateUserName>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserProfileRepository _userProfileRepository;
        public UpdateUserNameHandler(IUnitOfWork unitOfWork, IUserProfileRepository userProfileRepository)
        {
            this.unitOfWork = unitOfWork;
            _userProfileRepository = userProfileRepository;
        }
        public void Handle(UpdateUserName command)
        {
            var user = _userProfileRepository.Load(command.UserId);
            if (user == null)
                throw new InvalidOperationException($"کاربری با شناسه {command.UserId} یافت نشد.");
            user.UpdateName(FirstName.FromString(command.FirstName), LastName.FromString(command.LastName));
            unitOfWork.Commit();
        }
    }
}
