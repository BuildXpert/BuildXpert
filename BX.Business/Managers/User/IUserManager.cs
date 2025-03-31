using BX.Models;

namespace BX.Business.Managers
{
    public interface IUserManager
    {
        Task<IEnumerable<ApplicationUser>> GetUsersAsync();
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<IEnumerable<ApplicationUser>> GetFilteredUsersAsync(string searchText, string status);
        Task<bool> CreateUserAsync(ApplicationUser property);
        Task<bool> UpdateUserAsync(ApplicationUser property);
        Task<bool> DeleteUserAsync(string id);
    }
}