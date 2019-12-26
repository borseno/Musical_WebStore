using Musical_WebStore_BlazorApp.Shared;
using System.Threading.Tasks;

namespace Musical_WebStore_BlazorApp.Client
{
    public interface ITestEnrollService
    {
        Task<TestEnrollingResult> Enroll(TestEnrollingModel model);
    }
}