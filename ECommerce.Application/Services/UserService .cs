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

        public List<UserDto> GetAllCustomers()
        {
            return _userRepo.GetAll()
                .Where(x => x.Role == UserRole.Customer)
                .Select(x => new UserDto
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Email = x.Email
                })
                .ToList();
        }

        public UserDto CreateCustomer(CreateUserDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FullName) ||
                string.IsNullOrWhiteSpace(dto.Email) ||
                string.IsNullOrWhiteSpace(dto.Password))
            {
                throw new Exception("All fields are required");
            }

            var existing = _userRepo.GetAll()
                .FirstOrDefault(x => x.Email == dto.Email);

            if (existing != null)
                throw new Exception("Email already exists");

            
            var entity = new User
            {
                FullName = dto.FullName.Trim(),
                Email = dto.Email.Trim(),
                Password = dto.Password.Trim(),
                Role = dto.Role
            };

            _userRepo.Add(entity);
            _userRepo.SaveChangesAsync();

            return new UserDto
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                Role = entity.Role
            };
        }

        public UserDto Login(LoginDto dto)
        {
            var user = _userRepo.GetAll()
                .FirstOrDefault(x =>
                    x.Email == dto.Email &&
                    x.Password == dto.Password);

            if (user == null)
                return null;

            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role
            };
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
