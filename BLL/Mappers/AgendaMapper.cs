using BLL.Models.DTO;
using BLL.Models.Forms;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class AgendaMapper
    {
        public static Agenda ToAgenda(this CreateAgenda agenda)
        {
            return new Agenda
            {
                Id = 0,
                startDate = agenda.startDate,
                endDate = agenda.endDate,
                ArticleID = agenda.articleId
            };
        }

        public static AgendaDTO ToAgendaDTO(this Agenda agenda)
        {
            return new AgendaDTO
            {
                startDate = agenda.startDate,
                endDate = agenda.endDate
            };
        }
    }
}
