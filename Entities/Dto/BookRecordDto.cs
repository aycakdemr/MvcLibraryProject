using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class BookRecordDto :IDto
    {
        public int Id { get; set; }
        public String BookName { get; set; }
        public String MemberName { get; set; }
        public String MemberLastName { get; set; }
        public String StaffName { get; set; }
        public DateTime BuyingDate { get; set; }
        public DateTime GivingDate { get; set; }
    }
}
