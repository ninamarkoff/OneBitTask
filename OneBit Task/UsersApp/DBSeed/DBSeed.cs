namespace DBSeed
{
    using UserApp.DBModels.DBModels;
    using UserApp.Data;

    public class DBSeed
    {
        private static void SeedUsers(UserAppData data)
        {
            for (int i = 0; i < 20; i++)
            {
                data.Users.Add(new User
                {
                    FirstName = "Pesho" + i,
                    LastName = "Goshev" + i,
                    PhoneNumber = "087" + i,
                    PhotoUrl = "http://gosho.com" + i,
                    GenderId = i % 3,
                    StatusId = (i + 1) % 3
                });
               
            }

           data.SaveChanges();
        }

        public static void Main()
        {
            SeedUsers(new UserAppData(new UsersDBEntities()));
        }
    }
}