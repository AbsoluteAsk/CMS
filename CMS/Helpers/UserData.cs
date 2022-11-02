namespace CMS.Helpers
{
    using CMS.Models.User;
    using System.Collections.Generic;
    using System.Security.Cryptography;

    public class UserData
    {
        public static List<User> Users => new List<User>
        {
            new User {
                Id = "1001",
                UserName = "Admin",
                EmailAddress = "reader1001@me.com",
              //  requestedUserDiagRole": \"reader1001@me.com\",
                //ecuIdentifier:"reader1001@me.com"  ,
                //OrgId:"reader1001@me.com" ,
                Role = Roles.Admin
            },
            new User {
                Id = "1007",
                UserName = "Viewer",
                EmailAddress = "reader1007@me.com",
                Role = Roles.Admin
            },
            new User {
                Id = "1002",
                UserName = "Viewer",
                EmailAddress = "reader1002@me.com",
                Role = Roles.Viewer
            },
            new User {
                Id = "1003",
                UserName = "Editor",
                EmailAddress = "reader1003@me.com",
                Role = Roles.Editor
            },

             new User {
                Id = "1005",
                UserName = "Editor",
                EmailAddress = "reader1005@me.com",
                Role = Roles.None

            }
        };

        public static List<UserMain> Readers => new List<UserMain>() {
            new User {
                Id = "1003",
                EmailAddress = "reader1003@me.com",
                UserName = "reader1003"
            },
            new User {
                Id = "1002",
                EmailAddress = "reader1002@me.com",
                UserName = "reader1002"
            }
        };
    }
}