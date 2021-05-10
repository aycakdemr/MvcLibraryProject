using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class LateFee : IEntity
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public virtual Member Members { get; set; }
        public DateTime BuyingDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal Amount { get; set; }
        public int BookRecordId { get; set; }
        public virtual BookRecord BookRecords { get; set; }
    }
}
