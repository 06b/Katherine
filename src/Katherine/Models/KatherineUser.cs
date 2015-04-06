using System;
using System.Collections.Generic;
using Nancy.Security;

namespace Katherine.Models
{
    public class KatherineUser : IUserIdentity
    {
        public Guid UserID { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<string> Claims { get; set; }
    }
}