using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospiceWebPortal.Models
{
    public class DeathNotification
    {
        public int ID { get; set; }

        [Display(Name = "Name")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Location")]
        [StringLength(100, ErrorMessage = "Position cannot be longer than 100 characters.")]
        public string Location { get; set; }

        [AllowHtml]
        [Display(Name = "Notes")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }
}