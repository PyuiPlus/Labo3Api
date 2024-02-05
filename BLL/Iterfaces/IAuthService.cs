using BLL.Models.Forms;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Iterfaces
{
    public interface IAuthService
    {
        Users? Login(LoginForm form);
    }
}
