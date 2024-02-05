using BLL.Iterfaces;
using BLL.Models.Forms;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository _usersRepository;

        public AuthService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Users? Login(LoginForm form)
        {
            Users? users = _usersRepository.GetByEmail(form.email);

            if (users is null)
            {
                return null;
            }

            if (BCrypt.Net.BCrypt.Verify(form.password, users.password))
            {

                return users;
            }

            return null;
        }
    }
    }
}
