using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospiceWebPortal.Models
{
    public class Schedule
    {
        public int ID { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}