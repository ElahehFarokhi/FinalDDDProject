using System;

namespace Bazzar.Domain.UserProfiles.Commands
{
    public class UpdateUserDisplayName
    {
        public Guid UserId { get; set; }
        public string DisplayName { get; set; }
    }
}
