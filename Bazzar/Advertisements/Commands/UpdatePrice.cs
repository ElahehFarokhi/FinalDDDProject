using System;

namespace Bazzar.Domain.Advertisements.Commands
{
    public class UpdatePrice
    {
        public Guid Id { get; set; }
        public long Price { get; set; }
    }
}
