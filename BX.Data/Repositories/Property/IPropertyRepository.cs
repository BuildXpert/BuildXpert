﻿using BX.Models;

namespace BX.Data.Repositories
{
    public interface IPropertyRepository
    {
        Task<bool> CreatePropertyAsync(Property property);
        Task<bool> DeletePropertyAsync(Property property);
        Task<bool> ExistsAsync(Property property);
        Task<Property> GetPropertyByIdAsync(int id);
        Task<IEnumerable<Property>> GetPropertiesAsync();
        Task<bool> UpdatePropertyAsync(Property property);
        Task<List<Property>> GetFilteredPropertiesAsync(string searchText, string status);
    }
}