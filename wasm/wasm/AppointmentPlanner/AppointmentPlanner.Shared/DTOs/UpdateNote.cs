namespace AppointmentPlanner.Shared.DTOs;

public class UpdateNote
{
    public int UpdateNoteId { get; set; } // Primary key
    public int ObservationId { get; set; } // Foreign key
    public string Note { get; set; }
    public string Author { get; set; }
    public DateTime Timestamp { get; set; }
}