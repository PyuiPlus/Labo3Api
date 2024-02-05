using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Services;

namespace DAL.Entities
{
    public class Article : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int type { get; set; }
        public decimal price { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public int UsersID { get; set; }
    }
}
