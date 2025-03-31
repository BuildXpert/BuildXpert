using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BX.Models;

namespace BX.Data.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser, string>, IUserRepository
    {
        public UserRepository(BuildXpertContext context) : base(context)
        {
        }
        public async Task<IEnumerable<ApplicationUser>> GetUsersAsync()
        {
            return await ReadAsync();
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string id)
        {
            return await ReadOneAsync(id);
        }

        public async Task<bool> CreateUserAsync(ApplicationUser applicationUser)
        {
            return await CreateAsync(applicationUser);
        }

        public async Task<bool> UpdateUserAsync(ApplicationUser applicationUser)
        {
            return await UpdateAsync(applicationUser);
        }

        public async Task<bool> DeleteUserAsync(ApplicationUser applicationUser)
        {
            return await DeleteAsync(applicationUser);
        }

        public async Task<bool> ExistsAsync(ApplicationUser applicationUser)
        {
            return await ExistsAsync(applicationUser);
        }

        public async Task<IEnumerable<ApplicationUser>> GetFilteredUsersAsync() 
        {
            return await ReadAsync();
        }
    }
}
