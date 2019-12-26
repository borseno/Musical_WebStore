using Musical_WebStore_BlazorApp.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Musical_WebStore_BlazorApp.Client
{
    public interface ITestingInfoService
    {
        Task<IEnumerable<TestingDTO>> GetTestings(bool currentUserOnly);
        Task<TestingDTO> GetTestingInfo(int id);
        Task ChangeState(int id);
    }
}