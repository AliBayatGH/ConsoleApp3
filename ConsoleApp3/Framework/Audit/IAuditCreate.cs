
using System;

namespace Hasti.Framework.Domain.Audit
{
    public interface IAuditCreate
    {
        string CreatedBy { get; set; }

        DateTimeOffset CreatedOn { get; set; }
    }
}