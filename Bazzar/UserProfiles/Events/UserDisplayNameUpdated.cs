using Framework.Domain.Events;
using System;

namespace Bazzar.Domain.UserProfiles.Events
{
    public class UserDisplayNameUpdated : IEvents
    {
        public Guid UserId { get; set; }
        public string DisplayName { get; set; }
    }
}
