using BLL.Iterfaces;
using BLL.Mappers;
using BLL.Models.DTO;
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
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public ArticleDTO Create(CreateArticleForm form)
        {

            return _articleRepository.Create(form.ToArticle()).ToArticleDTO();
        }

        public bool Delete(int id)
        {
            Article article = _articleRepository.GetById(id);

            if (article is null)
            {
                return false;
            }

            return _articleRepository.Delete(article);
        }

        public IEnumerable<ArticleDTO> GetAll()
        {
            return _articleRepository.GetAll().Select(x => x.ToArticleDTO());
        }

        public IEnumerable<ArticleDTO> GetAllByUserId(int userId)
        {
            return _articleRepository.GetAllIdUser(userId).Select(x => x.ToArticleDTO());
        }

        public ArticleDTO GetById(int id)
        {
            return _articleRepository.GetById(id).ToArticleDTO();
        }

        public bool Update(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
