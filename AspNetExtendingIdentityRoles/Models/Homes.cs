using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospiceWebPortal.Models
{
    public class Home
    {
        public int ID { get; set; }

        [Display(Name = "Title")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        [AllowHtml]
        [Display(Name = "Content")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public DateTime? Created { get; set; }

        [Display(Name = "Author")]
        [StringLength(100, ErrorMessage = "Position cannot be longer than 100 characters.")]
        public string Author { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}