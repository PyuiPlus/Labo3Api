using BLL.Models.DTO;
using BLL.Models.Forms;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Iterfaces
{
    public interface IUsersService
    {
        UsersDTO Create(RegisterForm form);
        bool AddToFavorite(int userId, int articleId);
        bool Delete(int userID);
        bool DeleteFavorite(int userID, int articleID);
        IEnumerable<ArticleDTO> GetAllFavorite(int userId);
        UsersDTO GetById(int id);
        bool Update(Users users);
    }   
}
