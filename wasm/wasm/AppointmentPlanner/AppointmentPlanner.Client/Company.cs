namespace AppointmentPlanner.Client
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public ICollection<CompanySite> CompanySites { get; set; }
    }
}