using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class MainPageDto :IDto
    {
        public IEnumerable<Book> deger1 { get; set; }
        public IEnumerable<About> deger2 { get; set; }
    }
}
