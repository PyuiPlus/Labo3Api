using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.DTO
{
    public class ArticleDTO
    {
        public string title { get; set; }
        public string type { get; set; }
        public decimal price { get; set; }
        public string link { get; set; }
        public string description { get; set; }
    }
}
