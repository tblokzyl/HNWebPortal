using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospiceWebPortal.Models
{
    public class Announcement
    {
        public int ID { get; set; }

        [Display(Name = "Title")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        [Display(Name = "Content")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Display(Name = "Created")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; }

        [Display(Name = "Author")]
        [StringLength(100, ErrorMessage = "Position cannot be longer than 100 characters.")]
        public string Author { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}