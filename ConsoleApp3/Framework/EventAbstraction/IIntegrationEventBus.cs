using System.Threading.Tasks;

namespace Hasti.Framework.Events
{
    public interface IIntegrationEventBus
    {
         Task PublishAsync<TEvent>(TEvent eventObject)
            where TEvent : IIntegrationEvent;
    }
}