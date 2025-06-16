namespace AppointmentPlanner.Client
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Site { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Store hashed password
        public string AccessLevel { get; set; }
        public string? ImageUrl { get; set; }
    }
}