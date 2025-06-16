using System;

namespace AppointmentPlanner.Shared
{
    public class ObservationCreateDto
    {
        public int CompanyId { get; set; }
        public int SiteId { get; set; }
        public string TypeOfReport { get; set; }
        public string NatureOfObservation { get; set; }
        public string? DescriptionOfSuggestion { get; set; }
        public string? DescriptionOfObservation { get; set; }
        public string ReporterName { get; set; }
        public List<string> UploadedImageUrls { get; set; } = new();
        public string Status { get; set; }
        public string Type { get; set; }
    }
}