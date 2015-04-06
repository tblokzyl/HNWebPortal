using HNWebPortal.Models;
using System.Data.Entity.Migrations;

namespace HNWebPortal.Migrations
{
    using HospiceWebPortal.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.IO;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.AddUserAndRoles();

            var homeArticles = new List<Home>
            {
                new Home
                {
                    Author = "Andrew Empacher",
                    Created = DateTime.Parse("2015-04-05"),
                    Title = "What is Hospice Niagara",
                    Content = "Hospice is a concept of care. Hospice Niagara aims to improve the quality of life for people with a life-limiting, progressive illness from the time of diagnosis. The focus is on caring, not curing, and on life, not death. Hospice care extends to family members and caregivers, helping them to care for their loved one and to care for themselves. "+ 
                    "\r\n\r\nHospice Niagara's programs and services (with the exception of pharmaceuticals) are free to residents of Niagara, thanks to the goodwill and charitable donations of members of the community. "+
                    "\r\n\r\nHospice Niagara provides services to individuals and families in St. Catharines, Niagara Falls, Pelham, Thorold, Wainfleet, Welland, Port Colborne, Fort Erie and Lincoln.  We also serve Niagara-on-the-Lake, in co-operation with the Niagara-on-the-Lake Community Palliative Care Service, and West Lincoln and Grimsby, in co-operation with McNally House Hospice and the Rose Cottage Visiting Volunteers."
                },

                new Home
                {
                    Author = "Andrew Empacher",
                    Created = DateTime.Parse("2015-04-05"),
                    Title = "Call for Nominations: Positions on Hospice Niagara’s Board of Directors",
                    Content = "Three positions on Hospice Niagara’s Boardof Directors will become vacant as of June 23rd. The Board is seeking individuals who possess specific skills and experience in:"
                    +"\r\n•Business Law;"
                    +"\r\n•Healthcare and Patient Care;"
                    +"\r\n•Information Technology Management;"
                    +"\r\n•Business management;"
                    +"\r\n•Fundraising experience through community connections"
                    +"\r\n\r\nOur preferred Board composition is representative of our communities and diverse population served by Hospice Niagara."
                    +"\r\n\r\nInterested individuals are to submit in writing why they wish to pursue a position on the Board and attach a resume reflecting their qualifications and experience."
                    +"\r\n\r\nPlease send applications to the attention of Doug Hunt at the address below, or at info@hospiceniagara.ca."
                    +"\r\n\r\nNominations will be accepted until April 15th, 2015. Thank you."
                }
            };
            homeArticles.ForEach(d => context.Homes.AddOrUpdate(n => n.Title, d));
            context.SaveChanges();

            var contacts = new List<Contact>
            {
                new Contact 
                { 
                    FirstName = "Timothy",
                    LastName = "Blokzyl",
                    Position = "Lead Programmer",
                    Phone = 1234567890,
                    EXT = 777
                },
                new Contact 
                { 
                    FirstName = "Alice",
                    LastName = "Merry",
                    Position = "Community Relations Manager",
                    EXT = 230
                },
                new Contact 
                { 
                    FirstName = "Andrea",
                    LastName = "Crompton",
                    Position = "Community Relations Associate",
                    EXT = 231
                },
                new Contact 
                { 
                    FirstName = "Barbara",
                    LastName = "Cowell",
                    Position = "Executive Assistant",
                    EXT = 223
                },
                new Contact 
                { 
                    FirstName = "Barb",
                    LastName = "Nolan",
                    Position = "Day Hospice Coordinator",
                    EXT = 270
                },
                new Contact 
                { 
                    FirstName = "Carol",
                    LastName = "Nagy",
                    Position = "Executive Director",
                    Phone = 2894078197,
                    EXT = 225
                },
                new Contact 
                { 
                    FirstName = "Diane",
                    LastName = "Fahlman",
                    Position = "Legacy Associate",
                    EXT = 250
                },
                new Contact 
                { 
                    FirstName = "Diane",
                    LastName = "Reid",
                    Position = "Palliative Care Consultant",
                    Phone = 9055156276,
                    EXT = 232
                },
                new Contact 
                { 
                    FirstName = "Dorothy",
                    LastName = "Hunse",
                    Position = "Chaplain/Psychosocial-Spiritual Advisor",
                    EXT = 249
                },
                new Contact 
                { 
                    FirstName = "Brian",
                    LastName = " Kerley",
                    Position = "Medical Director",
                    Phone = 9056415684,
                    EXT = 234
                },
                new Contact 
                { 
                    FirstName = "Jessica",
                    LastName = "Estabrooks",
                    Position = "Finance and Operations Manager",
                    EXT = 238
                },
                new Contact 
                { 
                    FirstName = "Jim",
                    LastName = "Horsthuis",
                    Position = "Community Programs Manager",
                    Phone = 9053216948,
                    EXT = 229
                },
                new Contact 
                { 
                    FirstName = "Kate",
                    LastName = "Murrell",
                    Position = "Administrative Assistant",
                    EXT = 222
                },
                new Contact 
                { 
                    FirstName = "Kelly",
                    LastName = "Vlaar",
                    Position = "Human Resources, Quality Improvement Manager",
                    EXT = 269
                },
                new Contact 
                { 
                    FirstName = "Patrick",
                    LastName = "Engel",
                    Position = "Chef",
                    EXT = 241
                },
                new Contact 
                { 
                    FirstName = "Laurie",
                    LastName = "Straw",
                    Position = "Director of Care",
                    Phone = 9056585867,
                    EXT = 247
                },
                new Contact 
                { 
                    FirstName = "Margie",
                    LastName = "Reid",
                    Position = "Coordinator of Volunteer Development",
                    EXT = 224
                },
                new Contact 
                { 
                    FirstName = "Marnie",
                    LastName = "Engel",
                    Position = "Community Programs Volunteer Coordinator",
                    EXT = 228
                },
                new Contact 
                { 
                    FirstName = "Melissa",
                    LastName = "DeBeau",
                    Position = " Financial Administrative Associate",
                    EXT = 235
                },
                new Contact 
                { 
                    FirstName = "Melissa",
                    LastName = "Penner",
                    Position = "Bereavement Advisor",
                    EXT = 233
                },
                new Contact 
                { 
                    FirstName = "Sue",
                    LastName = "Shipley",
                    Position = "Pallative Care Consultant",
                    Phone = 2899684068,
                    EXT = 301
                }
            };
            contacts.ForEach(d => context.Contacts.AddOrUpdate(n => n.EXT, d));
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }

            var meetings = new List<Meeting>
            {
                new Meeting
                {
                    Name = "Prototype III",
                    Description = "Meet with Jessica, Dave, James and Peter to discuss progress.",
                    Date = DateTime.Parse("2015-04-06"), 
                    Location = "Niagara College Rm. S306",
                    Type = "Off-Site",
                    RSVP = "Yes"
                },

                new Meeting
                {
                    Name = "Monthly Adult Support Program",
                    Description = "This group is for those individuals who have completed the Grief Circle",
                    Date = DateTime.Parse("2015-04-28"), 
                    Location = "Hospice Niagara Stabler Center",
                    Type = "On-Site",
                    RSVP = "Yes"
                }
            };
            meetings.ForEach(d => context.Meetings.AddOrUpdate(n => n.Name, d));
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }

            var announcements = new List<Announcement>
            {
                new Announcement
                {
                    Created = DateTime.Parse("2015-03-01"),
                    Author = "Jim Horsthuis, Community Programs Manager",
                    Title = "Announcing Niagara - South Day Hospice",
                    Content = "\r\nWith the “ringing of the bells,” Niagara – South Day Hospice was officially launched at Knox Presbyterian Church in Welland. The development of this program was truly a team effort. It started with community leaders recognizing the need for Day Hospice in the Southern region of Niagara. Together, Hospice Niagara worked with community leaders to plan and implement Niagara – South Day Hospice. Funding has been secured for 2015 and we are now seeking ongoing funding to carry us forward in future years. If you are interested in supporting Niagara-South Day Hospice, please call 905-984-8766."
                    +"\r\n\r\nNiagara – South Day Hospice provides an opportunity for men and women who are living with a life-limiting, progressive illness to enjoy a day of relaxation and caring companionship in a safe, comfortable setting. It offers a place for tranquility, social sharing, a gourmet meal, quality entertainment, complementary therapies and aesthetic services. It is a day to pursue quality of life. Over the past several months, approximately 6-10 clients have enjoyed Niagara – South Day Hospice. All of our clients are eager to see this program expand from a monthly to a weekly endeavor."
                    +"\r\n\r\nOur many volunteers help to make Day Hospice the amazing and sought after program that it is. Their commitment and enthusiasm allows Day Hospice to flourish. From arriving early to making sure the coffee is on, to planning the entertainment at the program, for our volunteers make each client feel special, welcome and cared for."
                    +"\r\n\r\nNiagara – South Day Hospice has a strong foundation because it is rooted in the community, guided with competence, and sustained through volunteers and community organizations. We look forward to the day when those living with a life limiting, progressive illness are able to enjoy all that Day Hospice offers on a weekly basis."
                },
            
                 new Announcement
                {
                    Created = DateTime.Parse("2015-03-01"),
                    Author = "Unknown",
                    Title = "Dancin’ for Miracles raises $3,000 for Hospice Niagara",
                    Content = "Thank you to Ella Turcotte and Valerie Keller (pictured here with Kelly Vlaar), for hosting “Dancin’ for Miracles” in support of Hospice Niagara. It was a fabulous line-dancing event held in Wasaga Beach at which $3,000 was raised in support of our programs and services."
                    +"\r\n\r\nThank you Valerie and Ella and everyone who participated in this fun event."
                }
            };
            announcements.ForEach(d => context.Announcements.AddOrUpdate(n => n.Title, d));
            context.SaveChanges();

            var deaths = new List<DeathNotification>
            {
                new DeathNotification 
                {
                    Name = "Howard Hall, 94",
                    Date = DateTime.Parse("2014-12-23"), 
                    Location = "Community Client",
                    Notes = "Former Niagara resident Howard M. Hall, 94, died Dec. 23, 2014, at his home in Vineland, Ontario."
                            +"\r\nAt his request, no service will be held."
                            +"\r\nMr. Hall was born May. 30, 1920, in Sacramento, Calif., to Salvatore and Elle Hall. Howard could accomplish anything he set his mind to do. At a very early age, he built a wagon to push his little brother around that was too little to walk. Mr. Hall served in the United State Air Force, during World War II as a radio operator. He spent 14 months in the South Pacific.  In 1942, Mr. Hall came to Niagara with his wife, Sally. He worked many years for Amtrak and for Exxon during the oil spill as their communications specialist. Mr. Hall spent more than 50 years in Niagara. He and his wife, Sally, built their vacation home in Muskoka and enjoyed many wonderful winters there together. He is survived by his wife of 28 years, Sally; daughter, Jean Hall."
                },

                new DeathNotification 
                {
                    Name = "Janet Snow, 55",
                    Date = DateTime.Parse("2015-03-01"), 
                    Location = "The Stabler Centre",
                    Notes = "Janet Snow, 44, died March 1, 2015, with her family by her side in Welland, Ontario."
                            +"\r\nA memorial service was Wednesday at Greenwood Memorial Park in Welland, Ontario."
                            +"\r\nShe was born July 10, 1944, in Anchorage to Charles and Phoebe Smith. Her father was a Doctor in the Yukon. Her mother came up from Juneau as a Nurse.  They moved to Washington in 1946. Janet spent summers at her grandparents in remote areas of the wilderness.   She graduated from Washington High School in 1978. She attended college at the University of Washington, where she met and married Eugene Snow. After graduation, they returned to Enumclaw. Mrs. Snow was a homemaker while her husband was a Firefighter. She was an active member of the Brighton Presbyterian Church, belonged to the Arboretum Foundation garden club and worked with various charities. Her interests included family, gardening, sewing and reading. She devoted much of her time and energy as a caregiver to family members, including her mother until she passed away at age 70."
                            +"\r\nMrs. Snow is survived by her sister, Virginia Coiro; brother, Carl Snow; 2 sons and their spouses, George and Eugene Snow,  Jeff and Connie Snow; and 13 grandchildren; and 15 great-grandchildren."
                            +"\r\nShe was preceded in death by her daughter, Sandra Snow."
                            +"\r\nDonations may be sent to Hospice Niagara."
                },

                new DeathNotification 
                {
                    Name = "John Andres, 73",
                    Date = DateTime.Parse("2015-04-05"), 
                    Location = "NN Outreach Team",
                    Notes = "John Franklin Adres, 62, died April 5, 2015, at his Fonthill home."
                    +"\r\nMr. Andres was born July 1, 1952, in Kaneohe, Hawaii, to Richard and Emily (Holt) Andres. He attended Boone High School in Kosciusko, Miss. He continued his education at Holmes Community College in Holmes, Miss., graduating in 1972 with an associate's degree in construction management. He enjoyed football and playing Scrabble with his family. He enjoyed his family and attending Broadway shows in NYC."
                    +"\r\nHe is survived by his mother, Emily Andres; brothers and their spouses, Richard Jr. and Leah Andres, and Thomas and Maggie Andres; several nephews; and special friend, Eva Gibson."
                    +"\r\nHe was preceded in death by his father, Richard Andres."
                    +"\r\nArrangements are with Cook Inlet Funeral Home."
                },
            };
            deaths.ForEach(d => context.DeathNotifications.AddOrUpdate(n => n.Name, d));
            context.SaveChanges();


            //var resources = new List<Resource>
            //{
            //    new Resource 
            //    {
            //        Description = "Hospice Niagara Portal Project Plan",
            //        FileName = "HNPortalProjectPlan.pdf",
            //        CreatedOn = DateTime.Parse("2014-12-16"),
            //        FileContent = File.ReadAllBytes("~/Images/HNPortalProjectPlan.pdf")
            //    }
            //};
            //resources.ForEach(d => context.Resources.AddOrUpdate(n => n.FileName, d));
            //context.SaveChanges();
        }


        bool AddUserAndRoles()
        {
            bool success = false;

            var idManager = new IdentityManager();
            success = idManager.CreateRole("Admin", "Global Access");
            if (!success == true) return success;

            success = idManager.CreateRole("CanEdit", "Edit existing records");
            if (!success == true) return success;

            success = idManager.CreateRole("User", "Restricted to business domain activity");
            if (!success) return success;

            success = idManager.CreateRole("Staff-Community", "Unknown");
            if (!success) return success;

            success = idManager.CreateRole("Outreach", "Unknown");
            if (!success) return success;

            success = idManager.CreateRole("Staff-Residential", "Unknown");
            if (!success) return success;

            success = idManager.CreateRole("New Staff", "Unknown");
            if (!success) return success;

            success = idManager.CreateRole("Admin", "Unknown");
            if (!success) return success;

            success = idManager.CreateRole("Leadership", "Unknown");
            if (!success) return success;

            success = idManager.CreateRole("Audit & Finance", "Unknown");
            if (!success) return success;

            success = idManager.CreateRole("Community Relations", "Unknown");
            if (!success) return success;

            success = idManager.CreateRole("Governance", "Unknown");
            if (!success) return success;

            success = idManager.CreateRole("Operations & Quality", "Unknown");
            if (!success) return success;

            success = idManager.CreateRole("New Board Members", "Unknown");
            if (!success) return success;

            success = idManager.CreateRole("New Volunteers", "Unknown");
            if (!success) return success;

            success = idManager.CreateRole("Admin-Non-Client", "Unknown");
            if (!success) return success;

            success = idManager.CreateRole("Event-Non-Client", "Unknown");
            if (!success) return success;

            success = idManager.CreateRole("Welcome Desk", "Unknown");
            if (!success) return success;

            success = idManager.CreateRole("Volunteers-Residential", "Unknown");
            if (!success) return success;

            success = idManager.CreateRole("Volunteers-Community", "Unknown");
            if (!success) return success;

            success = idManager.CreateRole("Day Hospice", "Unknown");
            if (!success) return success;

            var newUser = new ApplicationUser()
            {
                UserName = "jatten",
                FirstName = "John",
                LastName = "Atten",
                Email = "jatten@typecastexception.com"
            };

            var newUser1 = new ApplicationUser()
            {
                UserName = "rainy",
                FirstName = "Rain",
                LastName = "Maida",
                Email = "rainy@gmail.com"
            };

            var newUser2 = new ApplicationUser()
            {
                UserName = "onetwo",
                FirstName = "Stephanie",
                LastName = "Scottsdale",
                Email = "oblique@gmail.com"
            };

            var newUser3 = new ApplicationUser()
            {
                UserName = "splashpants",
                FirstName = "Kevin",
                LastName = "Allyson",
                Email = "stresstest@aol.com"
            };

            var newUser4 = new ApplicationUser()
            {
                UserName = "timmeh",
                FirstName = "Timmy",
                LastName = "Blockenstylez",
                Email = "tblokzen@outlook.com"
            };

            var newUser5 = new ApplicationUser()
            {
                UserName = "sportscar",
                FirstName = "Peter",
                LastName = "Vansconey",
                Email = "peteyprogrammy@gmail.com"
            };

            var newUser6= new ApplicationUser()
            {
                UserName = "awrend",
                FirstName = "Andrew the",
                LastName = "Man Empacher",
                Email = "andrewempacher@gmail.com"
            };

            // Be careful here - you  will need to use a password which will 
            // be valid under the password rules for the application, 
            // or the process will abort:
            success = idManager.CreateUser(newUser, "Password1");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "Admin");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "CanEdit");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "User");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser1.Id, "Operations & Quality");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser2.Id, "Event-Non-Client");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser3.Id, "Leadership");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser4.Id, "Day Hospice");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser5.Id, "Welcome Desk");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser5.Id, "Welcome Desk");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser6.Id, "Admin");
            if (!success) return success;

            return success;
        }
    }
}
