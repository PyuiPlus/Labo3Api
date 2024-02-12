using DAL.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Iterfaces
{
    public interface IJwtService
    {
        string CreateToken(Users user);
    }
}
