using BX.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BX.Models;
using System.ComponentModel.DataAnnotations;

namespace BX.Business.Managers
{
    public class PropertyManager : IPropertyManager
    {
        #region DEPENDENCY INJECTION
        private readonly IPropertyRepository _propertyRepository;
        public PropertyManager(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        #endregion

        #region GET
        public async Task<IEnumerable<Property>> GetPropertiesAsync()
        {
            return await _propertyRepository.GetPropertiesAsync();
        }

        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            return await _propertyRepository.GetPropertyByIdAsync(id);
        }

        public async Task<IEnumerable<Property>> GetFilteredPropertiesAsync(string searchText, string status)
        {
            return await _propertyRepository.GetFilteredPropertiesAsync(searchText, status);
        }

        #endregion

        #region POST
        public async Task<bool> CreatePropertyAsync(Property property)
        {
            return await _propertyRepository.CreatePropertyAsync(property);
        }
        #endregion

        #region PATCH
        public async Task<bool> UpdatePropertyStatusAsync(Property property)
        {
            return await _propertyRepository.UpdatePropertyStatusAsync(property);
        }
        public async Task<bool> UpdatePropertyDetailsAsync(Property property)
        {
            Property existingProperty = await _propertyRepository.GetPropertyByIdAsync(property.Id);
            if (existingProperty == null)
            {
                throw new Exception("Property not found");
            }
            existingProperty.Name = property.Name;
            existingProperty.Description = property.Description;
            existingProperty.Price = property.Price;
            existingProperty.Status = property.Status;
            existingProperty.CreatedDate = property.CreatedDate;
            existingProperty.ConstructionType = property.ConstructionType;
            existingProperty.Province = property.Province;
            existingProperty.Canton = property.Canton;
            existingProperty.ConstructionSize = property.ConstructionSize;
            existingProperty.LandSize = property.LandSize;
            existingProperty.Bedrooms = property.Bedrooms;
            existingProperty.Bathrooms = property.Bathrooms;
            existingProperty.Price = property.Price;
            existingProperty.Floors = property.Floors;
            existingProperty.HasGarage = property.HasGarage;
            existingProperty.GarageCapacity = property.GarageCapacity;
            existingProperty.IsCondominium = property.IsCondominium;
            return await _propertyRepository.UpdatePropertyDetailsAsync(property);
        }
        public async Task<bool> UpdatePropertyAsync(Property newProperty)
        {
            Property existingProperty = await _propertyRepository.GetPropertyByIdAsync(newProperty.Id);
            if (existingProperty==null) return false;
            UpdatePropertyDetails(existingProperty, newProperty);
            return await _propertyRepository.UpdatePropertyAsync(existingProperty);
        }
        #endregion

        #region DELETE
        public async Task<bool> DeletePropertyAsync(int id)
        {
            Property property = await _propertyRepository.GetPropertyByIdAsync(id);
            if (property==null)
            {
                return false;
            }
            return await _propertyRepository.DeletePropertyAsync(property);
        }
        #endregion

        private void UpdatePropertyDetails(Property existingProperty, Property property)
        {
            existingProperty.Name = property.Name;
            existingProperty.Description = property.Description;
            existingProperty.Price = property.Price;
            existingProperty.Status = property.Status;
            existingProperty.CreatedDate = property.CreatedDate;
            existingProperty.ConstructionType = property.ConstructionType;
            existingProperty.Province = property.Province;
            existingProperty.Canton = property.Canton;
            existingProperty.ConstructionSize = property.ConstructionSize;
            existingProperty.LandSize = property.LandSize;
            existingProperty.Bedrooms = property.Bedrooms;
            existingProperty.Bathrooms = property.Bathrooms;
            existingProperty.Price = property.Price;
            existingProperty.Floors = property.Floors;
            existingProperty.HasGarage = property.HasGarage;
            existingProperty.GarageCapacity = property.GarageCapacity;
            existingProperty.IsCondominium = property.IsCondominium;
        }
    }
}
