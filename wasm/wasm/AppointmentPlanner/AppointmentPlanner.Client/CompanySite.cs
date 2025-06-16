namespace AppointmentPlanner.Client
{
    public class CompanySite
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int SiteId { get; set; }
        public Site Site { get; set; }
    }
}