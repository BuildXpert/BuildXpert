using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BX.Models;
using Microsoft.EntityFrameworkCore;

namespace BX.Data.Repositories
{
    public class PropertyRepository : RepositoryBase<Property>, IPropertyRepository
    {
        public PropertyRepository(BuildXpertContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Property>> GetPropertiesAsync()
        {
            return await ReadAsync();
        }
        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            return await ReadOneAsync(id);
        }
        public async Task<bool> CreatePropertyAsync(Property property)
        {
            return await CreateAsync(property);
        }
        public async Task<bool> UpdatePropertyAsync(Property property)
        {
            return await UpdateAsync(property);
        }
        public async Task<bool> DeletePropertyAsync(Property property)
        {
            return await DeleteAsync(property);
        }
        public async Task<bool> ExistsAsync(Property property)
        {
            return await BExistsAsync(property);
        }
        public async Task<List<Property>> GetFilteredPropertiesAsync(string searchText, string status)
        {
            var query = ReadQueriableAsync();

            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(p => p.Name.Contains(searchText) || p.Description.Contains(searchText));
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(p => p.Status == status);
            }

            return await query.ToListAsync();
        }
        public async Task<bool> UpdatePropertyStatusAsync(Property property)
        {
            return await UpdateAsync(property);
        }
        public async Task<bool> UpdatePropertyDetailsAsync(Property property)
        {
            return await UpdateAsync(property);
        }
    }
}
