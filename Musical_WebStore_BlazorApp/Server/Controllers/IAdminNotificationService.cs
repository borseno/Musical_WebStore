using System.Threading.Tasks;

namespace Musical_WebStore_BlazorApp.Server.Controllers
{
    public interface IAdminNotificationService
    {
        Task Notify(string info);
    }
}