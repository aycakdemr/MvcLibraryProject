using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BookRecord :IEntity
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }
        public DateTime BuyingDate { get; set; }
        public DateTime GivingDate { get; set; }
        public DateTime MemberGivingDate { get; set; }
        public bool RecordStatus { get; set; }
    }
}
