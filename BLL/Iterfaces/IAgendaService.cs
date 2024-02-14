using BLL.Models.DTO;
using BLL.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Iterfaces
{
    public interface IAgendaService
    {
        AgendaDTO Create(CreateAgenda form);
        bool Delete();
        IEnumerable<AgendaDTO> GetAll(int id);
    }
}
