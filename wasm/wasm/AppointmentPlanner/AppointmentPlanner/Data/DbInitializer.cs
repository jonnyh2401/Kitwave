using AppointmentPlanner.Client;

namespace AppointmentPlanner.Data
{
    public static class DbInitializer // <-- Add this class wrapper
    {
        public static void SeedUsers(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                var admin = new User
                {
                    FirstName = "Keira",
                    LastName = "Harman",
                    Company = "Kitwave",
                    Site = "HQ",
                    Email = "KeiraHarman@kitwave.co.uk",
                    Username = "Keirah",
                    PasswordHash = PasswordHasher.HashPassword("BBK67ttj"),
                    AccessLevel = "kitwaveadmin",
                    ImageUrl = "css/appoinment/assets/images/Keira.png"
                };
                context.Users.Add(admin);
                context.SaveChanges();
            }
        }
    }
}