using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.ApplicationLayer.DTOs.LoginDtos;
using ECommerce.ApplicationLayer.DTOs.RegisterDtos;
using ECommerce.ApplicationLayer.DTOs.UserDtos;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;

namespace ECommerce.ApplicationLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User, int> _userRepo;

        public UserService(IGenericRepository<User, int> userRepo)
        {
            _userRepo = userRepo;
        }

        public List<User> GetAllCustomers()
        {
            return _userRepo.GetAll()
                            .Where(x => x.Role == UserRole.Customer)
                            .ToList();
        }

        public void CreateCustomer(CreateUserDto dto)
        {
            var entity = new User()
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = dto.Password,
                Role = UserRole.Customer
            };

            _userRepo.Add(entity);
        }

        public User Login(LoginDto dto)
        {
            var user = _userRepo.GetAll()
                .FirstOrDefault(x =>
                    x.Email == dto.Email &&
                    x.Password == dto.Password);

            return user;
        }

        public void UpdateCustomer(UpdateUserDto dto)
        {
            var entity = _userRepo.GetAll()
                                  .FirstOrDefault(x => x.Id == dto.Id);

            if (entity != null)
            {
                entity.FullName = dto.FullName;
                entity.Email = dto.Email;

                _userRepo.Update(entity);
            }
        }

        public void DeleteCustomer(int id)
        {
            var entity = _userRepo.GetAll()
                                  .FirstOrDefault(x => x.Id == id);

            if (entity != null)
                _userRepo.Delete(entity);
        }
    }
}
