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
                    Content = "Hospice is a concept of care. Hospice Niagara aims to improve the quality of life for people with a life-limiting, progressive illness from the time of diagnosis. The focus is on caring, not curing, and on life, not death. Hospice care extends to family members and caregivers, helping them to care for their loved one and to care for themselves."+ 
                    "Hospice Niagara's programs and services (with the exception of pharmaceuticals) are free to residents of Niagara, thanks to the goodwill and charitable donations of members of the community."+
                    "Hospice Niagara provides services to individuals and families in St. Catharines, Niagara Falls, Pelham, Thorold, Wainfleet, Welland, Port Colborne, Fort Erie and Lincoln.  We also serve Niagara-on-the-Lake, in co-operation with the Niagara-on-the-Lake Community Palliative Care Service, and West Lincoln and Grimsby, in co-operation with McNally House Hospice and the Rose Cottage Visiting Volunteers."
                },

                new Home
                {
                    Author = "Andrew Empacher",
                    Created = DateTime.Parse("2015-04-05"),
                    Title = "What is Hospice Niagara",
                    Content = "Hospice is a concept of care. Hospice Niagara aims to improve the quality of life for people with a life-limiting, progressive illness from the time of diagnosis. The focus is on caring, not curing, and on life, not death. Hospice care extends to family members and caregivers, helping them to care for their loved one and to care for themselves."+ 
                    "Hospice Niagara's programs and services (with the exception of pharmaceuticals) are free to residents of Niagara, thanks to the goodwill and charitable donations of members of the community."+
                    "Hospice Niagara provides services to individuals and families in St. Catharines, Niagara Falls, Pelham, Thorold, Wainfleet, Welland, Port Colborne, Fort Erie and Lincoln.  We also serve Niagara-on-the-Lake, in co-operation with the Niagara-on-the-Lake Community Palliative Care Service, and West Lincoln and Grimsby, in co-operation with McNally House Hospice and the Rose Cottage Visiting Volunteers."
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
                    Name = "Prototype II",
                    Description = "Meet with Jessica, Dave, and Peter to discuss progress.",
                    Date = DateTime.Parse("2015-03-16"), 
                    Location = "Niagara College Rm. S306",
                    Type = "Off-Site",
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

            var deaths = new List<DeathNotification>
            {
                new DeathNotification 
                {
                    Name = "Joe Smith",
                    Date = DateTime.Parse("2014-12-16"), 
                    Location = "Community Client",
                    Notes = "Volunteer: Ted Tennant"
                },

                new DeathNotification 
                {
                    Name = "Rachel Jones",
                    Date = DateTime.Parse("2014-12-14"), 
                    Location = "The Stabler Centre",
                    Notes = "Room 4"
                },

                new DeathNotification 
                {
                    Name = "Mary Brown",
                    Date = DateTime.Parse("2014-12-08"), 
                    Location = "NN Outreach Team",
                    Notes = ""
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


            var newUser = new ApplicationUser()
            {
                UserName = "jatten",
                FirstName = "John",
                LastName = "Atten",
                Email = "jatten@typecastexception.com"
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

            return success;
        }
    }
}
