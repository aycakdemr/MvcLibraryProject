using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public  class Book :IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
        public String ReleaseYear { get; set; }
        public String Publisher { get; set; }
        public String NumberOfPage { get; set; }
        public bool Status { get; set; }

        public ICollection<BookRecord> BookRecords { get; set; }
    }
}
