namespace AppointmentPlanner.Client
{
    public class Site
    {
        public int SiteId { get; set; }
        public string Name { get; set; }
        public ICollection<CompanySite> CompanySites { get; set; }
        public ICollection<Observation> Observations { get; set; }
    }
}