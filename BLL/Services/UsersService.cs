using BCrypt.Net;
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
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IArticleRepository _articlesRepository;

        public UsersService(IUsersRepository usersRepository, IArticleRepository articlesRepository)
        {
            _usersRepository = usersRepository;
            _articlesRepository = articlesRepository;

        }

        public bool AddToFavorite(int userId, int articleId)
        {
            return _usersRepository.AddToFavorite(userId, articleId);
        }

        public UsersDTO Create(RegisterForm form)
        {
            form.password = BCrypt.Net.BCrypt.HashPassword(form.password);
            form.email = form.email.ToLower();
            return _usersRepository.Create(form.ToUsers()).ToUsersDTO();
        }

        public bool Delete(int userID)
        {
            Users users = _usersRepository.GetById(userID);

            if (users is null)
            {
                return false;
            }
            return _usersRepository.Delete(users);
        }

        public bool DeleteFavorite(int userID, int articleID)
        {
            return _usersRepository.DeleteFavorite(userID, articleID);
        }

        public IEnumerable<ArticleDTO> GetAllFavorite(int userId)
        {
            List<ArticleDTO> articles = new List<ArticleDTO>();

            IEnumerable<int> idArticle = _usersRepository.GetAllFavorite(userId);
            foreach (int item in idArticle)
            {
                articles.Add(_articlesRepository.GetById(item).ToArticleDTO());
            }

            return articles;
        }

        public UsersDTO GetById(int id)
        {
            return _usersRepository.GetById(id).ToUsersDTO();
        }

        public bool Update(Users users)
        {
            return _usersRepository.Update(users);
        }
    }
}
