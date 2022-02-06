using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Exceptions
{
    public class InvalidEntityStateException:Exception
    {
        public InvalidEntityStateException(object entity, string message)
            : base($"امکان تغییر وضعیت {entity.GetType().Name} وجود ندارد. {message}")
        {

        }
    }
}
