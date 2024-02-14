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
    public interface IArticleService
    {
        ArticleDTO Create(CreateArticleForm form);
        bool Delete(int id);
        IEnumerable<ArticleDTO> GetAll();
        ArticleDTO GetById(int id);
        bool Update(Article article);

        IEnumerable<ArticleDTO> GetAllByUserId(int userId);
    }
}
