using System;
using Simple.Data;

namespace Katherine.Core.Data
{
    /// <summary>
    /// Checks if the database can be opened.
    /// </summary>
    public class DatabaseCheck
    {
        public static bool Connection()
        {
            try
            {
                var db = Database.Open();
                // Confirm that the Database Exists by checking if the Katherine Admin "Katherine" exists as it's the default site admin.

                // TODO: On first login - The Administrator of the site is forced to change the default Katherine password before proceeding any further into the CMS.
                // RISK: IF the Administration section is never used then it's a risk, as that would allow someone to take over the site if they know the default Katherine Username & Password which is likely due to it being in Documentation.

                // Granted, if someone views having an additional administrator as a risk after changing the Katherine Admin Password, they can always choice to Lock the account - or delete the account if they wish.

                db.Katherine_Users.ExistsByUsername(Username: "Katherine");

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

    }
}