using System;
using System.Threading.Tasks;

namespace Hasti.Framework.Events
{
    public interface IEventBus
    {
        Task PublishAsync<TEvent>(TEvent eventToPublish)
            where TEvent : IEvent;

        void On<TEvent>(Action<TEvent> action) where TEvent : IEvent;
    }
}