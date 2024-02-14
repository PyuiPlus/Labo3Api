using BLL.Models.DTO;
using BLL.Models.Forms;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Services;
using static BLL.Mappers.ArticleMapper;

namespace BLL.Mappers
{
    public static class ArticleMapper
    {
        public enum typeArticle
        {
            Other = 1,
            House = 2,
            Car = 3,
            Apartment = 4

        }
        public static Article ToArticle(this CreateArticleForm form)
        {
            return new Article
            {
                Id = 0,
                Title = form.title,
                type = (int)Enum.Parse(typeof(typeArticle), form.type),
                price = form.price,
                link = form.link,
                description = form.description,
                UsersID = form.UsersId
            };
        }

        public static ArticleDTO ToArticleDTO(this Article entity)
        {

            return new ArticleDTO
            {
                title = entity.Title,
                type =  Enum.GetName(typeof(typeArticle),entity.type),
                price = entity.price,
                link = entity.link,
                description = entity.description,
                UserId = entity.UsersID,
                id = entity.Id
                
                
            };
        }

    }
}
