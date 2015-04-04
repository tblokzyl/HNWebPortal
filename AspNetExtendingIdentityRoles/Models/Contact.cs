using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospiceWebPortal.Models
{
    public class Contact
    {
        public int ID { get; set; }

        [Display(Name = "Full Name")]
        public string FormalName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        [Display(Name = "First Name ")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(30, ErrorMessage = "First name cannot be more than 30 characters long.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name ")]
        [Required(ErrorMessage = "You cannot leave the last name blank.")]
        [StringLength(50, ErrorMessage = "Last name cannot be more than 50 characters long.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You cannot leave the position blank!")]
        [StringLength(100, ErrorMessage = "Position cannot be more than 100 characters long.")]
        public string Position { get; set; }

        //[Required(ErrorMessage = "You cannot leave the position description blank!")]
        //[StringLength(500, ErrorMessage = "Position Description be more than 500 characters long.")]
        //public string Description { get; set; }

        //[Required(ErrorMessage = "You cannot leave the phone number blank.")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "The phone number must be exactly 10 numeric digits.")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = false)]
        public Int64? Phone { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public int EXT { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}