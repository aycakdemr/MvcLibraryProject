using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Writer:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string WriterName { get; set; }
        public string WriterLastName { get; set; }
        public string Detail { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
