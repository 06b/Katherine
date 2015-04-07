using System;
using CryptSharp;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;
using Katherine.Models;
using Simple.Data;

namespace Katherine.Core.Authentication
{
    public class DatabaseUserMapper : IUserMapper
    {

        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {

            var db = Database.Open();
            var queryUserId = db.Katherine_Users.ExistsByUserID(identifier);

            if (queryUserId == null)
            {
                return null;
            }
            else
            {
                var user = db.Katherine_Users.Find(db.Katherine_Users.UserId == identifier);

                //TODO: Set up Roles Table and pass in user role
                return new KatherineUser { UserName = user.username, Claims = new[] { "administrator" } };

            }

        }

        /// <summary>
        /// Return the Guid of the User Name - Currently not be used.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static Guid? GetIdentiferFromCurrentUser(string username)
        {

            Guid Identifer = Guid.Empty;

            var db = Database.Open();

            bool UserExists = db.Katherine_Users.ExistsByUsername(username);
            if (UserExists)
            {
                var queryUsers = db.Katherine_Users.Find(db.Katherine_Users.Username == username);

                foreach (var user in queryUsers)
                {
                    Identifer = queryUsers.UserID;
                }
            }

            else
            {
                // User doesnt exist
                return null;
            }


            return Identifer;
        }


        public static Guid? ValidateUser(string username, string password)
        {

            Guid returnid = Guid.Empty;

            var db = Database.Open();

            //Check to see if the user exists.
            bool UserExists = db.Katherine_Users.ExistsByUsername(username);
            if (UserExists)
            {

                var queryUsers = db.Katherine_Users.Find(db.Katherine_Users.Username == username);

                foreach (var user in queryUsers)
                {

                    // Check if passwords match
                    bool matches = Crypter.CheckPassword(password, queryUsers.Password);
                    if (matches)
                    {
                        returnid = queryUsers.UserID;
                    }
                    else
                    {
                        // Password is invalid.
                        return null;
                    }

                }

            }

            else
            {
                // User does not exist.
                return null;
            }

            return returnid;
        }

    }
}