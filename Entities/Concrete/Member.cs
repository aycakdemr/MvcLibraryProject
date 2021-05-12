using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Member :IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Adı boş bırakamazsınız")]
        [StringLength(20,ErrorMessage ="En fazla yirmi karakter girebilirsiniz")]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifreyi boş bırakamazsınız")]
        [StringLength(10, ErrorMessage = "En fazla on karakter girebilirsiniz")]
        public string Password { get; set; }
        public string Image { get; set; }
        public string PhoneNumber { get; set; }
        public string Education { get; set; }

        public ICollection<LateFee> LateFees { get; set; }
        public ICollection<BookRecord> BookRecords { get; set; }
    }
}
