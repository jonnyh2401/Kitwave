namespace AppointmentPlanner.Shared.DTOs;

public class UpdateNoteDto
{
    public string Note { get; set; }
    public string Author { get; set; }
    public DateTime Timestamp { get; set; }
}