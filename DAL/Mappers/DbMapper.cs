using DAL.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class DbMapper
    {
        public static Users ToUsers(this SqlDataReader reader)
        {
            return new Users
            {
                Id = Convert.ToInt32(reader["Id"]),
                email = reader["email"].ToString(),
                password = reader["password"].ToString(),
                firstName = reader["firstname"].ToString(),
                lastName = reader["lastname"].ToString(),
                phone = reader["phone"].ToString(),
                birthdate = Convert.ToDateTime(reader["birthdate"])
            };
        }

        public static Article ToArticle(this SqlDataReader reader)
        {
            return new Article
            {
                Id = Convert.ToInt32(reader["Id"]),
                Title = reader["title"].ToString(),
                type = Convert.ToInt32(reader["type"]),
                price = Convert.ToDecimal(reader["price"]),
                link = reader["link"].ToString(),
                description = reader["description"].ToString(),
                UsersID = Convert.ToInt32(reader["UsersID"])
            };
        }

        public static Agenda ToAgenda(this SqlDataReader reader)
        {
            return new Agenda
            {
                Id = Convert.ToInt32(reader["Id"]),
                startDate = Convert.ToDateTime( reader["startDate"]),
                endDate = Convert.ToDateTime(reader["endDate"]),
                ArticleID = Convert.ToInt32(reader["ArticleID"])
            };
        }
    }
}
