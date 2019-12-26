using System.Threading.Tasks;

namespace Musical_WebStore_BlazorApp.Client
{
    public interface ITestingStateService
    {
        Task ChangeState(int id);
    }
}