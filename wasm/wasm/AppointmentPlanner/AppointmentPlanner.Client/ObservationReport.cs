namespace AppointmentPlanner.Client
{
    public class ObservationReport
    {
        public int Id { get; set; } // Auto-incremented by backend or data store

        public string Status { get; set; } // "Outstanding" or "Closed"
        public string Type { get; set; }   // "Good", "Bad", "HS Suggestion", "Invalid"

        // Fields from ObservationModel
        public string Company { get; set; }
        public string SiteLocation { get; set; }
        public string TypeOfReport { get; set; }
        public string NatureOfObservation { get; set; }
        public string DescriptionOfSuggestion { get; set; }
        public string DescriptionOfObservation { get; set; }
        public string ReporterName { get; set; }
        public string UploadedImageUrl { get; set; } // Use a URL or path to the uploaded image

        // New fields
        public DateTime RaisedDateTime { get; set; }
        public DateTime? ClosedOutDateTime { get; set; }

        // Update fields
        public string Comments { get; set; }
        public string CloseOutNotes { get; set; }
        public string InvalidNotes { get; set; }
    }
}
