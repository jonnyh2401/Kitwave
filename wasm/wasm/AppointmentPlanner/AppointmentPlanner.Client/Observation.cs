using System.ComponentModel.DataAnnotations.Schema;
using AppointmentPlanner.Client;
using AppointmentPlanner.Shared.DTOs;

public class Observation
{
    public int ObservationId { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public int CompanyId { get; set; }
    public int SiteId { get; set; }
    public string TypeOfReport { get; set; }
    public string NatureOfObservation { get; set; }
    public string? DescriptionOfSuggestion { get; set; }
    public string? DescriptionOfObservation { get; set; }
    public string ReporterName { get; set; }
    public string UploadedImageUrl { get; set; }
    public DateTime RaisedDateTime { get; set; }
    public DateTime? ClosedOutDateTime { get; set; }
    public Site Site { get; set; }
    public List<UpdateNote> Updates { get; set; } = new();

    [NotMapped]
    public string Company { get; set; }

    public string? CloseOutNotes { get; set; }
    public string? ReasonForInvalid { get; set; }
}