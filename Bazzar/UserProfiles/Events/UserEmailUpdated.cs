using Framework.Domain.Events;
using System;

namespace Bazzar.Domain.UserProfiles.Events
{
    public class UserEmailUpdated : IEvents
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
    }
}
