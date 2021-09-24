using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eskaney.Models
{
    public class Company
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Company Name Required !!")]
        public string Name { get; set; }

        public string Phone { get; set; }


        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Enter Correct Email")]
        public string Email { get; set; }

        [NotMapped] /* بكتبها لانو مابدي اضيف العنصر على الداتا بيس */
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Enter Correct Email")]
        public string ConfEmail { get; set; }


        [Required(ErrorMessage = "Password Required !!")]
        public string Password { get; set; }

        [NotMapped]
        public string ConfPassword { get; set; }

        public string Logo { get; set; }

        public List<Housing> List_Of_Housings { get; set; }
    }
}