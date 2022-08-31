using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Model
{
    public class UserModel
    {

        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        
        public string EmailAddress { get; set; }
        [Required]
        public string NotesField { get; set; }

        [Required]
        public string CreationTime { get; set; }

       
    }
}
