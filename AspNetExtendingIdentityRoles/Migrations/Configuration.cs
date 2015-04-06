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
                    Title = "Nullam fringilla mattis tincidunt", 
                    Content = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making " 
                    + "it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, "
                    + "consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum "
                    + "comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise "
                    + "on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, Lorem ipsum dolor sit amet.., comes from a line in section 1.10.32.",
                    Created = DateTime.Parse("2011-03-12"), 
                    Author = "Tim Blokzyl"
                },

                new Home 
                {  
                    Title = "Suspendisse tincidunt tellus in cursus", 
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus et quam libero. Ut viverra erat eu placerat tincidunt. Maecenas vehicula tortor ut " 
                    + "ullamcorper lacinia. Duis feugiat enim turpis, efficitur faucibus quam fermentum nec. Donec sodales tincidunt nisl, sed hendrerit felis feugiat sed. Aliquam eu urna " 
                    + "dolor. Fusce tincidunt sapien risus, nec aliquet justo iaculis eget. Vestibulum a quam massa. Mauris id massa sed dui pellentesque porttitor. Ut lorem ante, efficitur " 
                    + "id ex id, lobortis pulvinar orci. Nullam sollicitudin vel erat a finibus. Fusce gravida ullamcorper ultrices. Nam dictum felis at imperdiet aliquet. Quisque a orci ut " 
                    + "felis feugiat pretium quis non ante. Cras purus turpis, venenatis sit amet fermentum hendrerit, fringilla sit amet orci. Quisque dapibus ipsum ipsum, eu varius augue" 
                    + "interdum eu. \r\n\r\n Etiam tempor vitae velit ac maximus. Aliquam ultricies malesuada felis, at ultrices turpis tempor eget. Nullam eget tincidunt mauris. Donec eget orci" 
                    + "eget ipsum commodo eleifend vel vel lorem. Sed et urna feugiat, eleifend massa non, mollis dui. Sed lobortis pulvinar facilisis. Sed magna sapien, sollicitudin vel " 
                    + "blandit sed, porta et enim.", 
                    Created = DateTime.Parse("2011-03-12"), 
                    Author = "Hospice Niagara"
                },

                new Home 
                { 
                    Title = "Lorem ipsum dolor sit amet", 
                    Content = "Aenean tristique at tellus quis consequat. Aenean ex nibh, fringilla a nulla in, elementum ultricies tortor. Nullam at gravida lacus. Integer molestie odio non " 
                    + "nunc dictum venenatis. Fusce ultrices dignissim eleifend. Nulla facilisi. Nunc purus lorem, ultricies ut tellus at, vehicula semper sem. Fusce sit amet massa ligula. " 
                    + "Donec vel fringilla arcu. Suspendisse diam orci, interdum in tortor ac, tincidunt hendrerit arcu. Integer dolor metus, tempor ac mi vel, interdum hendrerit erat. Fusce " 
                    + "eu convallis dolor. Curabitur faucibus libero in neque euismod vehicula. Nullam vel finibus nisl, faucibus eleifend ex. \r\n\r\n"
                    + "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc tincidunt blandit urna sed pellentesque. Nam eget quam at dolor molestie placerat. Praesent viverra enim " 
                    + "nec ante hendrerit, ac consequat est eleifend. Fusce id diam finibus, condimentum lacus ut, lobortis odio. Aliquam dictum euismod sem posuere ultricies. Praesent eget " 
                    + "est velit. Aenean a lectus non lectus commodo sollicitudin ut a sapien. Aliquam in porttitor lectus, ac rutrum ipsum. Nulla ut consequat nisi, et pharetra dolor. " 
                    + "Pellentesque condimentum accumsan nisl non volutpat. Aliquam rutrum efficitur faucibus. Donec quis sodales eros. Nulla vestibulum tempus purus non pharetra. \r\n\r\n"
                    + "Nam facilisis sodales tortor et viverra. Donec sollicitudin auctor lectus, sed vestibulum libero elementum vitae. Pellentesque vel nulla mi. Nam arcu sapien, lobortis vel " 
                    + "sem at, malesuada viverra ex. Phasellus eros orci, lacinia eget metus a, porta fermentum enim. Praesent eu venenatis mauris, vitae scelerisque massa. Nam dictum, lorem " 
                    + "id egestas posuere, risus odio tempor mi, in mollis nulla sem vel libero. Aenean in magna sed libero vestibulum ultrices. Fusce libero ipsum, ultricies non viverra in, " 
                    + "tincidunt vel velit.", 
                    Created = DateTime.Parse("2011-03-12"), 
                    Author = "Hospice Niagara"
                },
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
