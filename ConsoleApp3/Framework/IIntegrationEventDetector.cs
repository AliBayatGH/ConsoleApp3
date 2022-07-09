
using Hasti.Framework.Events;
using System.Collections.Generic;

namespace Hasti.Framework.Domain
{
    public interface IIntegrationEventDetector
    {
        List<IIntegrationEvent> GetIntegrationEvents();
    }
}