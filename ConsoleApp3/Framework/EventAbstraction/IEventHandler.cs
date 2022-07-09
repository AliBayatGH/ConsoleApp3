using System.Threading.Tasks;

namespace Hasti.Framework.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent eventToHandle);
    }
}