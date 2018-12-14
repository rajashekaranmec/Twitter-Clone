using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MyTwitterClone.Entity
{
    public class PersonEntity
    {
        [Required]
        [Display(Name = "User Name")]
        public string user_id { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public System.DateTime joined { get; set; }
        public bool active { get; set; }
    }
}
