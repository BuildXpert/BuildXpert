using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BX.Models;

namespace BX.Data.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier,int>, ISupplierRepository
    {
        public SupplierRepository(BuildXpertContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Supplier>> GetSuppliersAsync()
        {
            return await ReadAsync();
        }

        public async Task<Supplier> GetSupplierAsync(int id)
        {
            return (await ReadAsync()).FirstOrDefault(p => p.Id == id);
        }

        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            return await ReadOneAsync(id);
        }

        public async Task<bool> CreateSupplierAsync(Supplier supplier)
        {
            return await CreateAsync(supplier);
        }

        public async Task<bool> UpdateSupplierAsync(Supplier supplier)
        {
            return await UpdateAsync(supplier);
        }

        public async Task<bool> DeleteSupplierAsync(Supplier supplier)
        {
            return await DeleteAsync(supplier);
        }

        public async Task<bool> ExistsAsync(Supplier supplier)
        {
            return await ExistsAsync(supplier);
        }


    }
}
