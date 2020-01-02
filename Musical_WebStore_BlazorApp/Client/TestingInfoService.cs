using Microsoft.AspNetCore.Components;
using Musical_WebStore_BlazorApp.Shared.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Musical_WebStore_BlazorApp.Client
{
    public class TestingInfoService : ITestingInfoService
    {
        private readonly HttpClient client;

        public TestingInfoService(HttpClient client)
        {
            this.client = client;
        }

        public Task<TestingDTO> GetTestingInfo(int id) =>
            client.GetJsonAsync<TestingDTO>($"api/testing/{id}");

        public Task ChangeState(int id) =>
            client.PostJsonAsync("api/testing/changestate", new { id });

        public Task<IEnumerable<TestingDTO>> GetTestings(bool currentUserOnly) =>
            client.GetJsonAsync<IEnumerable<TestingDTO>>($"api/testing/testings/{currentUserOnly}");
    }
}
