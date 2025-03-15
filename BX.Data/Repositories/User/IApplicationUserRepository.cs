using BX.Models;

namespace BX.Data.Repositories
{
    public interface IApplicationUserRepository
    {
        Task<bool> CreateApplicationUserAsync(ApplicationUser applicationUser);
        Task<bool> DeleteApplicationUserAsync(ApplicationUser applicationUser);
        Task<bool> ExistsAsync(ApplicationUser applicationUser);
        Task<ApplicationUser> GetApplicationUserAsync(int id);
        Task<ApplicationUser> GetApplicationUserByIdAsync(int id);
        Task<IEnumerable<ApplicationUser>> GetApplicationUsersAsync();
        Task<bool> UpdateApplicationUserAsync(ApplicationUser applicationUser);
    }
}