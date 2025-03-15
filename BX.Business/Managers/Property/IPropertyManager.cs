using BX.Models;

namespace BX.Business.Managers
{
    public interface IPropertyManager
    {
        Task<IEnumerable<Property>> GetPropertiesAsync();
        Task<Property> GetPropertyAsync(int id);
        Task<IEnumerable<Property>> GetFilteredPropertiesAsync(string searchText, string status);
        Task<bool> CreatePropertyAsync(Property property);
        Task<bool> UpdatePropertyAsync(Property property);
        Task<bool> UpdatePropertyStatusAsync(Property property);
        Task<bool> UpdatePropertyDetailsAsync(Property property);
        Task<bool> DeletePropertyAsync(Property property);
    }
}