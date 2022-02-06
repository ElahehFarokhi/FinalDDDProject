using Framework.Domain.Events;
using System;

namespace Bazzar.Domain.UserProfiles.Events
{
    public class UserNameUpdated : IEvents
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
