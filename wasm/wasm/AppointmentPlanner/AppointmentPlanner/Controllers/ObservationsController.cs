using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppointmentPlanner.Client;
using AppointmentPlanner.Data;
using AppointmentPlanner.Shared;
using AppointmentPlanner.Shared.DTOs;
using AppointmentPlanner.Services;
using System.Text.Json;

namespace AppointmentPlanner.Controllers
{
    [ApiController]
    [Route("api/observations")]
    public class ObservationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly AzureEmailService _emailService;

        public ObservationsController(AppDbContext context, AzureEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        // GET: api/observations
        [HttpGet]
        public async Task<ActionResult<List<ObservationDto>>> GetAll()
        {
            var observations = await _context.Observations
                .Include(o => o.Site)
                .Include(o => o.Updates)
                .Join(_context.Companies,
                      o => o.CompanyId,
                      c => c.CompanyId,
                      (o, c) => new { o, c })
                .ToListAsync();

            var dtos = observations.Select(x => new ObservationDto
            {
                ObservationId = x.o.ObservationId,
                Status = x.o.Status,
                Type = x.o.Type,
                CompanyId = x.o.CompanyId,
                Company = x.c.Name,
                SiteId = x.o.SiteId,
                TypeOfReport = x.o.TypeOfReport,
                NatureOfObservation = x.o.NatureOfObservation,
                DescriptionOfSuggestion = x.o.DescriptionOfSuggestion,
                DescriptionOfObservation = x.o.DescriptionOfObservation,
                ReporterName = x.o.ReporterName,
                UploadedImageUrls = string.IsNullOrEmpty(x.o.UploadedImageUrl)
                    ? new List<string>()
                    : JsonSerializer.Deserialize<List<string>>(x.o.UploadedImageUrl),
                RaisedDateTime = x.o.RaisedDateTime,
                ClosedOutDateTime = x.o.ClosedOutDateTime,
                CloseOutNotes = x.o.CloseOutNotes,
                ReasonForInvalid = x.o.ReasonForInvalid,
                Site = x.o.Site == null ? null : new SiteDto
                {
                    SiteId = x.o.Site.SiteId,
                    Name = x.o.Site.Name
                },
                Updates = x.o.Updates?
                    .OrderByDescending(u => u.Timestamp)
                    .Select(u => new UpdateNoteDto
                    {
                        Note = u.Note,
                        Author = u.Author,
                        Timestamp = u.Timestamp
                    }).ToList() ?? new List<UpdateNoteDto>()
            }).ToList();

            return dtos;
        }

        // GET: api/observations/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ObservationDto>> GetById(int id)
        {
            var result = await _context.Observations
                .Include(o => o.Site)
                .Include(o => o.Updates)
                .Join(_context.Companies,
                      o => o.CompanyId,
                      c => c.CompanyId,
                      (o, c) => new { o, c })
                .Where(x => x.o.ObservationId == id)
                .FirstOrDefaultAsync();

            if (result == null)
                return NotFound();

            var dto = new ObservationDto
            {
                ObservationId = result.o.ObservationId,
                Status = result.o.Status,
                Type = result.o.Type,
                CompanyId = result.o.CompanyId,
                Company = result.c.Name,
                SiteId = result.o.SiteId,
                TypeOfReport = result.o.TypeOfReport,
                NatureOfObservation = result.o.NatureOfObservation,
                DescriptionOfSuggestion = result.o.DescriptionOfSuggestion,
                DescriptionOfObservation = result.o.DescriptionOfObservation,
                ReporterName = result.o.ReporterName,
                UploadedImageUrls = string.IsNullOrEmpty(result.o.UploadedImageUrl)
                    ? new List<string>()
                    : JsonSerializer.Deserialize<List<string>>(result.o.UploadedImageUrl),
                RaisedDateTime = result.o.RaisedDateTime,
                ClosedOutDateTime = result.o.ClosedOutDateTime,
                CloseOutNotes = result.o.CloseOutNotes,
                ReasonForInvalid = result.o.ReasonForInvalid,
                Site = result.o.Site == null ? null : new SiteDto
                {
                    SiteId = result.o.Site.SiteId,
                    Name = result.o.Site.Name
                },
                Updates = result.o.Updates?
                    .OrderByDescending(u => u.Timestamp)
                    .Select(u => new UpdateNoteDto
                    {
                        Note = u.Note,
                        Author = u.Author,
                        Timestamp = u.Timestamp
                    }).ToList() ?? new List<UpdateNoteDto>()
            };

            return dto;
        }

        // POST: api/observations
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ObservationCreateDto dto)
        {
            var observation = new Observation
            {
                CompanyId = dto.CompanyId,
                SiteId = dto.SiteId,
                TypeOfReport = dto.TypeOfReport,
                NatureOfObservation = dto.NatureOfObservation,
                DescriptionOfSuggestion = dto.DescriptionOfSuggestion,
                DescriptionOfObservation = dto.DescriptionOfObservation,
                ReporterName = dto.ReporterName,
                UploadedImageUrl = dto.UploadedImageUrls != null
                    ? JsonSerializer.Serialize(dto.UploadedImageUrls)
                    : JsonSerializer.Serialize(new List<string>()),
                Status = dto.Status,
                Type = dto.Type,
                RaisedDateTime = DateTime.UtcNow
            };

            _context.Observations.Add(observation);
            await _context.SaveChangesAsync();

            // Email notification logic
            var site = await _context.Sites.FindAsync(dto.SiteId);
            var company = await _context.Companies.FindAsync(dto.CompanyId);
            var siteOwner = await _context.Users
                .FirstOrDefaultAsync(u =>
                    u.AccessLevel == "SiteAdmin" &&
                    u.Company == company.Name &&
                    u.Site == site.Name);

            if (siteOwner != null)
            {
                // Build the login link with returnUrl
                var baseUrl = $"{Request.Scheme}://{Request.Host}";
                var observationPath = $"/observations/update/{observation.ObservationId}";
                var loginUrl = $"{baseUrl}/login?returnUrl={Uri.EscapeDataString(observationPath)}";

                var subject = $"New Observation Raised for {company.Name} - {site.Name}";
                var body = $@"
A new observation has been raised:

Type: {dto.TypeOfReport}
Nature: {dto.NatureOfObservation}
Description: {(dto.DescriptionOfObservation ?? dto.DescriptionOfSuggestion)}
Reporter: {dto.ReporterName}

View and update this observation: {loginUrl}
";
                try
                {
                    await _emailService.SendEmailAsync(siteOwner.Email, subject, body);
                }
                catch (Exception ex)
                {
                    // Return error to client so it can be shown on the screen
                    return BadRequest(new { error = $"Email send failed: {ex.Message}" });
                }
            }

            // Return the created observation as DTO
            var created = await _context.Observations
                .Include(o => o.Site)
                .Include(o => o.Updates)
                .Join(_context.Companies,
                      o => o.CompanyId,
                      c => c.CompanyId,
                      (o, c) => new { o, c })
                .Where(x => x.o.ObservationId == observation.ObservationId)
                .FirstOrDefaultAsync();

            var createdDto = new ObservationDto
            {
                ObservationId = created.o.ObservationId,
                Status = created.o.Status,
                Type = created.o.Type,
                CompanyId = created.o.CompanyId,
                Company = created.c.Name,
                SiteId = created.o.SiteId,
                TypeOfReport = created.o.TypeOfReport,
                NatureOfObservation = created.o.NatureOfObservation,
                DescriptionOfSuggestion = created.o.DescriptionOfSuggestion,
                DescriptionOfObservation = created.o.DescriptionOfObservation,
                ReporterName = created.o.ReporterName,
                UploadedImageUrls = string.IsNullOrEmpty(created.o.UploadedImageUrl)
                    ? new List<string>()
                    : JsonSerializer.Deserialize<List<string>>(created.o.UploadedImageUrl),
                RaisedDateTime = created.o.RaisedDateTime,
                ClosedOutDateTime = created.o.ClosedOutDateTime,
                CloseOutNotes = created.o.CloseOutNotes,
                ReasonForInvalid = created.o.ReasonForInvalid,
                Site = created.o.Site == null ? null : new SiteDto
                {
                    SiteId = created.o.Site.SiteId,
                    Name = created.o.Site.Name
                },
                Updates = created.o.Updates?
                    .OrderByDescending(u => u.Timestamp)
                    .Select(u => new UpdateNoteDto
                    {
                        Note = u.Note,
                        Author = u.Author,
                        Timestamp = u.Timestamp
                    }).ToList() ?? new List<UpdateNoteDto>()
            };

            return CreatedAtAction(nameof(GetById), new { id = observation.ObservationId }, createdDto);
        }

        // PUT: api/observations/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ObservationDto updated)
        {
            if (id != updated.ObservationId)
                return BadRequest();

            var existing = await _context.Observations
                .Include(o => o.Updates)
                .FirstOrDefaultAsync(o => o.ObservationId == id);

            if (existing == null)
                return NotFound();

            // Store the original status for comparison
            var originalStatus = existing.Status;

            // Update all properties
            existing.Status = updated.Status;
            existing.Type = updated.Type;
            existing.CompanyId = updated.CompanyId;
            existing.SiteId = updated.SiteId;
            existing.TypeOfReport = updated.TypeOfReport;
            existing.NatureOfObservation = updated.NatureOfObservation;
            existing.DescriptionOfSuggestion = updated.DescriptionOfSuggestion;
            existing.DescriptionOfObservation = updated.DescriptionOfObservation;
            existing.ReporterName = updated.ReporterName;
            existing.UploadedImageUrl = updated.UploadedImageUrls != null
                ? JsonSerializer.Serialize(updated.UploadedImageUrls)
                : JsonSerializer.Serialize(new List<string>());
            existing.RaisedDateTime = updated.RaisedDateTime;
            existing.ClosedOutDateTime = updated.ClosedOutDateTime;
            existing.CloseOutNotes = updated.CloseOutNotes;
            existing.ReasonForInvalid = updated.ReasonForInvalid;

            // Update the Updates collection
            // Remove all existing notes and add the new ones from the DTO
            if (existing.Updates != null)
            {
                _context.UpdateNotes.RemoveRange(existing.Updates);
            }
            if (updated.Updates != null)
            {
                existing.Updates = updated.Updates.Select(u => new UpdateNote
                {
                    ObservationId = existing.ObservationId,
                    Note = u.Note,
                    Author = u.Author,
                    Timestamp = u.Timestamp
                }).ToList();
            }

            // *** Add this logic to set ClosedOutDateTime ***
            if ((originalStatus != "Closed" && updated.Status == "Closed") ||
                (originalStatus != "Invalid" && updated.Status == "Invalid"))
            {
                existing.ClosedOutDateTime = DateTime.UtcNow;
            }
            else if (originalStatus != "Outstanding" && updated.Status == "Outstanding")
            {
                existing.ClosedOutDateTime = null; // Optionally clear the date
            }
            else
            {
                existing.ClosedOutDateTime = updated.ClosedOutDateTime; // Keep the existing value
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/observations/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obs = await _context.Observations.FindAsync(id);
            if (obs == null)
                return NotFound();

            _context.Observations.Remove(obs);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}