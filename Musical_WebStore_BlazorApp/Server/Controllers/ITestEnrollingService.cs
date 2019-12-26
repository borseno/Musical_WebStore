using Musical_WebStore_BlazorApp.Server.Data.Models;
using Musical_WebStore_BlazorApp.Shared;
using System.Threading.Tasks;

namespace Musical_WebStore_BlazorApp.Server.Controllers
{
    public interface ITestEnrollingService
    {
        Task<TestEnrollingResult> EnrollToTest(TestEnrollingModel model, User user);
    }
}