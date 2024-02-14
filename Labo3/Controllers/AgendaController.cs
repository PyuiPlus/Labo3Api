using BLL.Iterfaces;
using BLL.Models.DTO;
using BLL.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILabo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaService _agendaService;

        public AgendaController(IAgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<AgendaDTO>> GetAgenda(int id) 
        {
            IEnumerable<AgendaDTO> agendaDTOs = _agendaService.GetAll(id);

            return agendaDTOs is not null ? Ok(agendaDTOs) : NotFound();
        }


        [HttpPost]
        public ActionResult<AgendaDTO> Create(CreateAgenda form)
        {
            AgendaDTO agenda = _agendaService.Create(form);

            return agenda is not null ? Ok(agenda) : NotFound();
        }
    }
}
