using Bazzar.Domain.UserProfiles.Commands;
using Bazzar.Domain.UserProfiles.Data;
using Bazzar.Domain.UserProfiles.Entities;
using Bazzar.Domain.UserProfiles.ValueObjects;
using Framework.Domain.ApplicationService;
using Framework.Domain.Data;
using System;

namespace Bazzar.Core.ApplicationServices.UserProfiles.CommandHandlers
{
    public class RegisterUserHandler : ICommandHandler<RegisterUser>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserProfileRepository _userProfileRepository;
        public RegisterUserHandler(IUnitOfWork unitOfWork, IUserProfileRepository userProfileRepository)
        {
            this.unitOfWork = unitOfWork;
            _userProfileRepository = userProfileRepository;
        }
        public void Handle(RegisterUser command)
        {
            if (_userProfileRepository.Exists(command.UserId))
                throw new InvalidOperationException($"قبلا کاربری با شناسه {command.UserId} ثبت شده است.");

            UserProfile userProfile = new UserProfile(command.UserId,
                FirstName.FromString(command.FirstName),
                LastName.FromString(command.LastName),
                DisplayName.FromString(command.DisplayName));
            _userProfileRepository.Add(userProfile);
            unitOfWork.Commit();
        }
    }
}
