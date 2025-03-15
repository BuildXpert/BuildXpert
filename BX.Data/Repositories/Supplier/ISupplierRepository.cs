using BX.Models;

namespace BX.Data.Repositories
{
    public interface ISupplierRepository
    {
        Task<bool> CreateSupplierAsync(Supplier supplier);
        Task<bool> DeleteSupplierAsync(Supplier supplier);
        Task<bool> ExistsAsync(Supplier supplier);
        Task<Supplier> GetSupplierAsync(int id);
        Task<Supplier> GetSupplierByIdAsync(int id);
        Task<IEnumerable<Supplier>> GetSuppliersAsync();
        Task<bool> UpdateSupplierAsync(Supplier supplier);
    }
}