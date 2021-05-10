﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Staff :IEntity
    {
        [Key]
        public int Id { get; set; }
        public string StaffName { get; set; }
        public ICollection<BookRecord> BookRecords { get; set; }
    }
}
