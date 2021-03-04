using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class ShippingDetail
    {
        //[Required(ErrorMessage = "FirsName required")]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "LastName required")]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "E-mail required")]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Address required")]
        public string Address { get; set; }

        //[Required(ErrorMessage = "City required")]
        [MinLength(10,ErrorMessage = "Must be 10 characters minimum")]
        public string City { get; set; }

        //[Required]
        //[Range(18,65)]
        public int Age { get; set; }

    }
}
