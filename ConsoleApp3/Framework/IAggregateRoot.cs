using Hasti.Framework.Events;
using System.Collections.Generic;

namespace Hasti.Framework.Domain
{
    public interface IAggregateRoot
    {
        IList<IEvent> Events { get; }

        void ClearEvents();
    }
}