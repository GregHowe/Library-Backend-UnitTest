namespace LibraryBackend.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() {
                Id = 1,
                Username = "admin"
                , Email = "admin@email.com"
                , Password = "admin"
                , GivenName = "Carlos"
                , Surname = "Cruzado"
                , Role = "Administrator" },

            new UserModel() {
                Id = 2,
                Username = "user",
                Email = "user@email.com",
                Password = "user"
                , GivenName = "Hector"
                , Surname = "Hermosillo"
                , Role = "User" },
        };

    };

}
