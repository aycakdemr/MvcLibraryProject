using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Announcement :IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Detail { get; set; }
        public DateTime DateTime { get; set; }
    }
}
