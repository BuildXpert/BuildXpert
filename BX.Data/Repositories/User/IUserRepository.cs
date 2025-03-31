using BX.Models;

namespace BX.Data.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CreateUserAsync(ApplicationUser applicationUser);
        Task<bool> DeleteUserAsync(ApplicationUser applicationUser);
        Task<bool> ExistsAsync(ApplicationUser applicationUser);
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<IEnumerable<ApplicationUser>> GetUsersAsync();
        Task<bool> UpdateUserAsync(ApplicationUser applicationUser);
        Task<IEnumerable<ApplicationUser>> GetFilteredUsersAsync();
    }
}