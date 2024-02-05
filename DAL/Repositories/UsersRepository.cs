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
    public class UsersRepository : Repository, IUsersRepository
    {
        public UsersRepository(string connectionString) : base(connectionString)
        {
        }

        public bool AddToFavorite(int userId, int articleId)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Favorite VALUES(" +
                    "@UsersId," +
                    "@ArticleId)";
                cmd.Parameters.AddWithValue("UsersId", userId);
                cmd.Parameters.AddWithValue("ArticleId", articleId);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }

        public Users? Create(Users entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Users OUTPUT inserted.Id VALUES(" +
                    "@email," +
                    "@password," +
                    "@firstname," +
                    "@lastname," +
                    "@phone," +
                    "@birthdate)";
                cmd.Parameters.AddWithValue("email", entity.email);
                cmd.Parameters.AddWithValue("password", entity.password);
                cmd.Parameters.AddWithValue("firstname", entity.firstName);
                cmd.Parameters.AddWithValue("lastname", entity.lastName);
                cmd.Parameters.AddWithValue("phone", entity.phone);
                cmd.Parameters.AddWithValue("birthdate", entity.birthdate);

                entity.Id = Convert.ToInt32(cmd.CustomScalar(ConnectionString));

                return entity;

            }
        }

        public bool Delete(Users entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Users WHERE Id = @Id";

                cmd.Parameters.AddWithValue("Id", entity.Id);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }

        public bool DeleteFavorite(int userId, int articleId)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Favorite WHERE UsersId = @UsersId AND ArticleId = @ArticleId";

                cmd.Parameters.AddWithValue("UsersId", userId);
                cmd.Parameters.AddWithValue("ArticleId", userId);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }

        public IEnumerable<Users> GetAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Users";

                return cmd.CustomReader(ConnectionString, x => DbMapper.ToUsers(x));
            }
        }

        public IEnumerable<int> GetAllFavorite(int id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Favorite WHERE UsersID = @UsersId";

                cmd.Parameters.AddWithValue("UsersId", id);

                return cmd.CustomReader(ConnectionString, x => Convert.ToInt32(x["ArticleId"]));    
            }
        }

        public Users GetByEmail(string email)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Users WHERE email = @email";

                cmd.Parameters.AddWithValue("email", email);

                return cmd.CustomReader(ConnectionString, x => DbMapper.ToUsers(x)).SingleOrDefault();
            }
        }

        public Users? GetById(int id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Users WHERE Id = @id";

                cmd.Parameters.AddWithValue("id", id);

                return cmd.CustomReader(ConnectionString, x => DbMapper.ToUsers(x)).SingleOrDefault();
            }
        }

        public bool Update(Users entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Users SET" +
                    "email = @email," +
                    "password = @password," +
                    "firstname = @firstname," +
                    "lastname = @lastname," +
                    "phone = @phone," +
                    "birthdate = @birthdate" +
                    "WHERE Id = @id";
                cmd.Parameters.AddWithValue("id", entity.Id);
                cmd.Parameters.AddWithValue("email", entity.email);
                cmd.Parameters.AddWithValue("password", entity.password);
                cmd.Parameters.AddWithValue("firstname", entity.firstName);
                cmd.Parameters.AddWithValue("lastname", entity.lastName);
                cmd.Parameters.AddWithValue("phone", entity.phone);
                cmd.Parameters.AddWithValue("birthdate", entity.birthdate);


                return cmd.CustomNonQuery(ConnectionString) == 1;

            }
        }
    }
}
