using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class BookWriterCategoryDto :IDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string WriterName { get; set; }
        public string WriterLastName { get; set; }
        public string CategoryName { get; set; }
        public String ReleaseYear { get; set; }
        public String Publisher { get; set; }
        public String NumberOfPages { get; set; }
        public bool Status { get; set; }
    }
}
