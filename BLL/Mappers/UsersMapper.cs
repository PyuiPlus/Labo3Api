using BLL.Models.DTO;
using BLL.Models.Forms;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class UsersMapper
    {
        public static Users ToUsers(this RegisterForm form)
        {
            return new Users
            {
                Id = 0,
                email = form.email,
                password = form.password,
                firstName = form.firstname,
                lastName = form.lastname,
                phone = form.phone,
                birthdate = form.birthDate
            };
        }

        public static UsersDTO ToUsersDTO(this Users entity)
        {
            return new UsersDTO
            {
                name = entity.lastName + " " + entity.firstName,
                email = entity.email,
                phone = entity.phone
            };
        }
    }
}
