using MyTestProject.Data.Models;
using MyTestProject.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTestProject.Common
{
    public static class UserCommon
    {
        public static User ConvertDTOtoBO(UserDTO userDTO)
        {
            var user = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Username = userDTO.Username,
                RoleId = 2, 
                Password = userDTO.Password
            };
            return user;
        }

        public static UserDTO ConvertBOtoDTO(User user)
        {
            var userDTO = new UserDTO
            {
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };
            return userDTO;
        }
    }
}