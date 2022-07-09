using System.Threading.Tasks;

namespace Hasti.Framework.Domain
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}