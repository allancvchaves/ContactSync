namespace Application.Entities
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public static List<Contact> GenerateContactList()
        {
            return new List<Contact>
            {
                new Contact { FirstName = "Linda", LastName = "Reeves", Email = "Linda.Reeves789@gmail.com" },
                new Contact { FirstName = "Andrew", LastName = "Holloway", Email = "Andrew.Holloway456@yahoo.com" },
                new Contact { FirstName = "Karen", LastName = "McNeil", Email = "Karen.McNeil321@outlook.com" },
                new Contact { FirstName = "Stephen", LastName = "Frost", Email = "Stephen.Frost654@hotmail.com" },
                new Contact { FirstName = "Diana", LastName = "Manning", Email = "Diana.Manning123@gmail.com" },
                new Contact { FirstName = "Ryan", LastName = "Woods", Email = "Ryan.Woods876@yahoo.com" },
                new Contact { FirstName = "Laura", LastName = "Carlson", Email = "Laura.Carlson987@gmail.com" },
                new Contact { FirstName = "George", LastName = "Peterson", Email = "George.Peterson123@hotmail.com" },
                new Contact { FirstName = "Sophia", LastName = "Barnes", Email = "Sophia.Barnes654@gmail.com" },
                new Contact { FirstName = "James", LastName = "Bishop", Email = "James.Bishop321@yahoo.com" },
                new Contact { FirstName = "Elizabeth", LastName = "Sutton", Email = "Elizabeth.Sutton456@gmail.com" },
                new Contact { FirstName = "Matthew", LastName = "Chandler", Email = "Matthew.Chandler789@hotmail.com" }
            };
        }
    }
}
