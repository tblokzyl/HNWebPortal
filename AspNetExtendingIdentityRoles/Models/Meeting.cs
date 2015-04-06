using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospiceWebPortal.Models
{
    public class Meeting
    {
        public int ID { get; set; }

        [StringLength(100, ErrorMessage = "Meeting name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }

        [StringLength(100, ErrorMessage = "Location cannot be longer than 100 characters.")]
        public string Location { get; set; }

        [StringLength(100, ErrorMessage = "Location cannot be longer than 100 characters.")]
        public string Type { get; set; }

        [Display(Name = "Attending")]
        public string RSVP { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}