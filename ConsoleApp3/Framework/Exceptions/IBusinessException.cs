
namespace Hasti.Framework.Domain.Exceptions
{
    public interface IBusinessException
    {
        string GetCode();
        string GetMessage();
    }
}