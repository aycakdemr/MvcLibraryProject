using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category :IEntity
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
