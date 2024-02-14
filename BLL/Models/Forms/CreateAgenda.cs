using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Forms
{
    public class CreateAgenda
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int articleId { get; set; }
    }
}
