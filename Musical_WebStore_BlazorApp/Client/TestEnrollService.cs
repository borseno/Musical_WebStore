using Microsoft.AspNetCore.Components;
using Musical_WebStore_BlazorApp.Shared;
using System.Net.Http;
using System.Threading.Tasks;

namespace Musical_WebStore_BlazorApp.Client
{
    public class TestEnrollService : ITestEnrollService
    {
        private readonly HttpClient client;

        public TestEnrollService(HttpClient client)
        {
            this.client = client;
        }

        public Task<TestEnrollingResult> Enroll(TestEnrollingModel model) =>
            client.PostJsonAsync<TestEnrollingResult>("api/testEnrolling", model);
    }
}
