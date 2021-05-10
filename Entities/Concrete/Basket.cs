using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Basket :IEntity
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string Mounth { get; set; }
    }
}
