using BX.Models;

namespace BX.Business.Managers
{
    public interface IPropertyManager
    {
        Task<IEnumerable<Property>> GetPropertiesAsync();
        Task<Property> GetPropertyByIdAsync(int id);
        Task<IEnumerable<Property>> GetFilteredPropertiesAsync(string searchText, string status);
        Task<bool> CreatePropertyAsync(Property property);
        Task<bool> UpdatePropertyAsync(Property property);
        Task<bool> UpdatePropertyStatusAsync(Property property);
        Task<bool> UpdatePropertyDetailsAsync(Property property);
        Task<bool> DeletePropertyAsync(int id);
    }
}