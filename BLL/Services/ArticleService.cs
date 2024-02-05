using BLL.Iterfaces;
using BLL.Mappers;
using BLL.Models.DTO;
using BLL.Models.Forms;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleService _articleService;

        public ArticleService(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public ArticleDTO Create(CreateArticleForm form)
        {

            return _articleService.Create(form.ToArticle()).;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public ArticleDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
