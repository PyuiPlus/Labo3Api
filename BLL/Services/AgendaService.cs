using BLL.Iterfaces;
using BLL.Mappers;
using BLL.Models.DTO;
using BLL.Models.Forms;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _repository;

        public AgendaService(IAgendaRepository agendaRepository)
        {
            _repository = agendaRepository;
        }
        public AgendaDTO Create(CreateAgenda form)
        {
            return _repository.Create(form.ToAgenda()).ToAgendaDTO();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AgendaDTO> GetAll(int id)
        {
            return _repository.GetAllAgendaByArticleId(id).Select(x => x.ToAgendaDTO());
        }
    }
}
