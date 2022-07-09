
using System;

namespace Hasti.Framework.Domain.Audit
{
    public interface IAuditUpdate
    {
         string ModifiedBy { get; set; }

         DateTimeOffset ModifiedOn { get; set; }
    }
}