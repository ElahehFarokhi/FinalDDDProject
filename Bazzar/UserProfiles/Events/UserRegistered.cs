﻿using Framework.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Domain.UserProfiles.Events
{
    public class UserRegistered : IEvents
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
    }
}
