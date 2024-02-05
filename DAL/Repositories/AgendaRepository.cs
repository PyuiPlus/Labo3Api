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
    public class AgendaRepository : Repository, IAgendaRepository
    {

        public AgendaRepository(string connectionString) : base(connectionString)
        {
            ConnectionString = connectionString;
        }

        public Agenda? Create(Agenda entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Agenda OUTPUT inserted.Id VALUES(" +
                    "@startDate," +
                    "@endDate," +
                    "@ArticleID)";
                cmd.Parameters.AddWithValue("startDate", entity.startDate);
                cmd.Parameters.AddWithValue("endDate", entity.endDate);

                entity.Id = Convert.ToInt32(cmd.CustomScalar(ConnectionString));

                return entity;
            }
        }

        public bool Delete(Agenda entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Agenda WHERE Id = @Id";

                cmd.Parameters.AddWithValue("Id", entity.Id);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }

        public IEnumerable<Agenda> GetAll()
        {
            throw new NotImplementedException();
        }

        public Agenda? GetById(int id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Agenda WHERE Id = @id";

                cmd.Parameters.AddWithValue("id", id);

                return cmd.CustomReader(ConnectionString, x => DbMapper.ToAgenda(x)).SingleOrDefault();
            }
        }

        public bool Update(Agenda entity)
        {
            throw new NotImplementedException();
        }
    }
}
