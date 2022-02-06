using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Domain.Advertisements.Commands
{
    public class SetTitle
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
