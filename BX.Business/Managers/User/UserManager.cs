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
    public class UserManager : IUserManager
    {
        #region DEPENDENCY INJECTION
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region GET
        public async Task<IEnumerable<ApplicationUser>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<IEnumerable<ApplicationUser>> GetFilteredUsersAsync(string searchText, string status)
        {
            return await _userRepository.GetFilteredUsersAsync();//searchText, status
        }

        #endregion

        #region POST
        public async Task<bool> CreateUserAsync(ApplicationUser user)
        {
            return await _userRepository.CreateUserAsync(user);
        }
        #endregion

        #region PATCH
        public async Task<bool> UpdateUserAsync(ApplicationUser newUser)
        {
            ApplicationUser existingUser = await _userRepository.GetUserByIdAsync(newUser.Id);
            if (existingUser==null) return false;
            UpdateUserAttributes(existingUser, newUser);
            return await _userRepository.UpdateUserAsync(existingUser);
        }
        #endregion

        #region DELETE
        public async Task<bool> DeleteUserAsync(string id)
        {
            ApplicationUser user = await _userRepository.GetUserByIdAsync(id);
            if (user==null)
            {
                return false;
            }
            return await _userRepository.DeleteUserAsync(user);
        }
        #endregion

        #region Helper Methods
        private void UpdateUserAttributes(ApplicationUser existingUser, ApplicationUser user)
        {
            //existingUser.Name = user.Name;
            //existingUser.Description = user.Description;
            //existingUser.Price = user.Price;
            //existingUser.Status = user.Status;
            //existingUser.CreatedDate = user.CreatedDate;
            //existingUser.ConstructionType = user.ConstructionType;
            //existingUser.Province = user.Province;
            //existingUser.Canton = user.Canton;
            //existingUser.ConstructionSize = user.ConstructionSize;
            //existingUser.LandSize = user.LandSize;
            //existingUser.Bedrooms = user.Bedrooms;
            //existingUser.Bathrooms = user.Bathrooms;
            //existingUser.Price = user.Price;
            //existingUser.Floors = user.Floors;
            //existingUser.HasGarage = user.HasGarage;
            //existingUser.GarageCapacity = user.GarageCapacity;
            //existingUser.IsCondominium = user.IsCondominium;
        }
        #endregion
    }
}
