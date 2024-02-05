using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Services;

namespace DAL.Interfaces
{
    public interface IUsersRepository : IRepository<int, Users>
    {
        bool AddToFavorite(int userId, int articleId);
        bool DeleteFavorite(int userId, int articleId);
        IEnumerable<int> GetAllFavorite(int id);
        Users GetByEmail (string email);
    }
}
