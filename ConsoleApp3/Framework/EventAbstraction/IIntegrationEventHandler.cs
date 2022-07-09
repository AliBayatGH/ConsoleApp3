using System.Threading.Tasks;

namespace Hasti.Framework.Events
{
    public interface IIntegrationEventHandler<in TEvent> where TEvent : IIntegrationEvent
    {
        Task HandleAsync(TEvent eventToHandle);
    }
}