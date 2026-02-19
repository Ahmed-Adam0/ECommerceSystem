using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.ApplicationLayer.DTOs.LoginDtos;
using ECommerce.ApplicationLayer.DTOs.UserDtos;
using ECommerce.Domain.Entities;

namespace ECommerce.ApplicationLayer.Services
{
    public interface IUserService
    {
        List<User> GetAllCustomers();
        void CreateCustomer(CreateUserDto dto);
        void UpdateCustomer(UpdateUserDto dto);
        void DeleteCustomer(int id);

        User Login(LoginDto dto);

    }
}
