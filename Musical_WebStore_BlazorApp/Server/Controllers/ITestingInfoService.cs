using Musical_WebStore_BlazorApp.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Musical_WebStore_BlazorApp.Server.Controllers
{
    public interface ITestingService
    {
        Task<TestingDTO> GetTestingInfo(int id);
        Task ChangeStateAsync(int id);
        Task<IEnumerable<TestingDTO>> GetTestings(string userId);
        Task<IEnumerable<TestingDTO>> GetTestings();
    }
}