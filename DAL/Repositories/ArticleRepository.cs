using DAL.Entities;
using DAL.Interfaces;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.DataBase;
using ToolBox.Services;

namespace DAL.Repositories
{
    public class ArticleRepository : Repository, IArticleRepository
    {
        public ArticleRepository(string connectionString) : base(connectionString)
        {
            ConnectionString = connectionString;
        }

        public Article? Create(Article entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Article (title, type, price, link, description, UsersID)  OUTPUT inserted.Id VALUES(" +
                    "@title," +
                    "@type," +
                    "@price," +
                    "@link," +
                    "@description," +
                    "@UsersID)";
                cmd.Parameters.AddWithValue("title", entity.Title);
                cmd.Parameters.AddWithValue("type", entity.type);
                cmd.Parameters.AddWithValue("price", entity.price);
                cmd.Parameters.AddWithValue("link", entity.link);
                cmd.Parameters.AddWithValue("description", entity.description);
                cmd.Parameters.AddWithValue("UsersID", entity.UsersID);

                entity.Id = Convert.ToInt32(cmd.CustomScalar(ConnectionString));

                return entity;

            }
        }

        public bool Delete(Article entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Article WHERE Id = @Id";

                cmd.Parameters.AddWithValue("Id", entity.Id);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }

        public IEnumerable<Article> GetAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Article";

                return cmd.CustomReader(ConnectionString, x => DbMapper.ToArticle(x));
            }
        }

        public IEnumerable<Article> GetAllIdUser(int id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Article where UsersID = @id";
                cmd.Parameters.AddWithValue("id", id);

                return cmd.CustomReader(ConnectionString, x => DbMapper.ToArticle(x));
            }
        }

        public Article? GetById(int id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Article WHERE Id = @id";

                cmd.Parameters.AddWithValue("id", id);

                return cmd.CustomReader(ConnectionString, x => DbMapper.ToArticle(x)).SingleOrDefault();
            }
        }

        public bool Update(Article entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Article SET" +
                    "title = @title," +
                    "type = @type," +
                    "price = @price," +
                    "link = @link," +
                    "description = @description," +
                    "UsersID = @UsersID" +
                    "WHERE Id = @id";
                cmd.Parameters.AddWithValue("id", entity.Id);
                cmd.Parameters.AddWithValue("title", entity.Title);
                cmd.Parameters.AddWithValue("type", entity.type);
                cmd.Parameters.AddWithValue("price", entity.price);
                cmd.Parameters.AddWithValue("link", entity.link);
                cmd.Parameters.AddWithValue("description", entity.description);
                cmd.Parameters.AddWithValue("UsersID", entity.UsersID);


                return cmd.CustomNonQuery(ConnectionString) == 1;

            }
        }
    }
}
