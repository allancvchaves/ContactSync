﻿namespace MockAPI.Entities
{
    public class Contact
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }

        public List<Contact> GenerateContactList()
        {
            return
        [
            new Contact { FirstName = "Patricia", LastName = "Goodwin", Email = "Patricia.Goodwin542@hotmail.com" },
            new Contact { FirstName = "Tracy", LastName = "Wyman", Email = "Tracy.Wyman123@yahoo.com" },
            new Contact { FirstName = "Samuel", LastName = "Lemke", Email = "Samuel.Lemke876@hotmail.com" },
            new Contact { FirstName = "Sandra", LastName = "Fay", Email = "Sandra.Fay902@gmail.com" },
            new Contact { FirstName = "Brittany", LastName = "Blick", Email = "Brittany.Blick765@gmail.com" },
            new Contact { FirstName = "Michael", LastName = "Stokes", Email = "Michael.Stokes423@yahoo.com" },
            new Contact { FirstName = "Jessica", LastName = "Keebler", Email = "Jessica.Keebler321@hotmail.com" },
            new Contact { FirstName = "Christopher", LastName = "Swift", Email = "Christopher.Swift678@gmail.com" },
            new Contact { FirstName = "Emily", LastName = "Cormier", Email = "Emily.Cormier456@gmail.com" },
            new Contact { FirstName = "Jonathan", LastName = "Daniels", Email = "Jonathan.Daniels223@gmail.com" },
            new Contact { FirstName = "Rebecca", LastName = "Walsh", Email = "Rebecca.Walsh987@yahoo.com" },
            new Contact { FirstName = "Daniel", LastName = "Barton", Email = "Daniel.Barton213@gmail.com" }
        ];
        }
    }
}
