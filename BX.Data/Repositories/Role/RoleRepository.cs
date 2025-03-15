//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using BX.Models;

//namespace BX.Data.Repositories
//{
//    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
//    {
//        public async Task<IEnumerable<Role>> GetRolesAsync()
//        {
//            return await ReadAsync();
//        }

//        public async Task<Role> GetRoleAsync(int id)
//        {
//            return (await ReadAsync()).FirstOrDefault(p => p.Id == id);
//        }

//        public async Task<Role> GetRoleByIdAsync(int id)
//        {
//            return await ReadOneAsync(id);
//        }

//        public async Task<bool> CreateRoleAsync(Role role)
//        {
//            return await CreateAsync(role);
//        }

//        public async Task<bool> UpdateRoleAsync(Role role)
//        {
//            return await UpdateAsync(role);
//        }

//        public async Task<bool> DeleteRoleAsync(Role role)
//        {
//            return await DeleteAsync(role);
//        }

//        public async Task<bool> ExistsAsync(Role role)
//        {
//            return await ExistsAsync(role);
//        }


//    }
//}
