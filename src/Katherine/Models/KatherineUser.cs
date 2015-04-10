using System;
using System.Collections.Generic;
using Nancy.Security;

namespace Katherine.Models
{
    public class KatherineUser : IUserIdentity
    {
        public Guid UserID { get; set; }

        public string UserName { get; set; }

        // Maximum length of a valid email address is 254 characters.
        // See Dominic Sayers answer at SO: http://stackoverflow.com/a/574698/99240
        public string Email { get; set; }
        public bool IsAccountVerified { get; set; }

        public string Password { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastLogin { get; set; }

        public bool RequiresPasswordReset { get; set; }
        public DateTime LastPasswordChangeDate { get; set; }

        public DateTime PasswordResetRequestedDate { get; set; }

        public bool LockoutEnabled{ get; set; }
        public DateTime LockoutEndDate { get; set; }

        public int FailedAttemptsCount { get; set; }
        public DateTime LastFailedLogin { get; set; }

        public string LastLockoutReason { get; set; }

        public bool IsAccountClosed { get; set; }
        public DateTime AccountClosedDate { get; set; }

        public IEnumerable<string> Claims { get; set; }
    }
}