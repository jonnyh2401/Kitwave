namespace AppointmentPlanner.Shared
{

    using AppointmentPlanner.Shared.DTOs;

    public class ObservationDto
    {
        public int ObservationId { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public int CompanyId { get; set; }

        public string Company { get; set; }
        public int SiteId { get; set; }
        public string TypeOfReport { get; set; }
        public string NatureOfObservation { get; set; }
        public string? DescriptionOfSuggestion { get; set; }
        public string? DescriptionOfObservation { get; set; }
        public string ReporterName { get; set; }
        public List<string> UploadedImageUrls { get; set; } = new();
        public DateTime RaisedDateTime { get; set; }
        public DateTime? ClosedOutDateTime { get; set; }
        public string? CloseOutNotes { get; set; }
        public string? ReasonForInvalid { get; set; }
        public SiteDto Site { get; set; }

        public List<UpdateNoteDto> Updates { get; set; } = new();

    }

    public class SiteDto
    {
        public int SiteId { get; set; }
        public string Name { get; set; }
    }

}