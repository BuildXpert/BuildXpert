using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BX.Models;

namespace BX.Data.Repositories
{
    public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(BuildXpertContext context) : base(context)
        {
        }
        public async Task<IEnumerable<ApplicationUser>> GetApplicationUsersAsync()
        {
            return await ReadAsync();
        }

        public async Task<ApplicationUser> GetApplicationUserAsync(int id)
        {
            return (await ReadAsync()).FirstOrDefault(p => p.Id.Equals(id));
        }

        public async Task<ApplicationUser> GetApplicationUserByIdAsync(int id)
        {
            return await ReadOneAsync(id);
        }

        public async Task<bool> CreateApplicationUserAsync(ApplicationUser applicationUser)
        {
            return await CreateAsync(applicationUser);
        }

        public async Task<bool> UpdateApplicationUserAsync(ApplicationUser applicationUser)
        {
            return await UpdateAsync(applicationUser);
        }

        public async Task<bool> DeleteApplicationUserAsync(ApplicationUser applicationUser)
        {
            return await DeleteAsync(applicationUser);
        }

        public async Task<bool> ExistsAsync(ApplicationUser applicationUser)
        {
            return await ExistsAsync(applicationUser);
        }


    }
}
