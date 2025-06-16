using System;
using System.Collections.Generic;
using System.Linq;

namespace AppointmentPlanner.Client
{
    public static class ObservationReportSeed
    {
        private static List<Observation> _observations = new List<Observation>
        {
            new Observation
            {
                ObservationId = 1,
                CompanyId = 1,
                Company = "HB Clark",
                SiteId = 1,
                Site = new Site { SiteId = 1, Name = "Wakefield" },
                Status = "Outstanding",
                Type = "Good",
                TypeOfReport = "Safety",
                NatureOfObservation = "Clean workspace",
                DescriptionOfSuggestion = "Keep up the good work",
                DescriptionOfObservation = "No hazards found",
                ReporterName = "John Doe",
                UploadedImageUrl = "",
                RaisedDateTime = DateTime.Now.AddDays(-10),
                ClosedOutDateTime = null
            },
            new Observation
            {
                ObservationId = 2,
                CompanyId = 1,
                Company = "HB Clark",
                SiteId = 2,
                Site = new Site { SiteId = 2, Name = "Bolton" },
                Status = "Closed",
                Type = "Bad",
                TypeOfReport = "Incident",
                NatureOfObservation = "Spill",
                DescriptionOfSuggestion = "Improve signage",
                DescriptionOfObservation = "Oil spill near entrance",
                ReporterName = "Jane Smith",
                UploadedImageUrl = "",
                RaisedDateTime = DateTime.Now.AddDays(-20),
                ClosedOutDateTime = DateTime.Now.AddDays(-15)
            },
            new Observation
            {
                ObservationId = 3,
                CompanyId = 2,
                Company = "Eden Farm",
                SiteId = 3,
                Site = new Site { SiteId = 3, Name = "Luton" },
                Status = "Outstanding",
                Type = "HS Suggestion",
                TypeOfReport = "Suggestion",
                NatureOfObservation = "Lighting",
                DescriptionOfSuggestion = "Install brighter lights",
                DescriptionOfObservation = "Dim lighting in warehouse",
                ReporterName = "Alice Brown",
                UploadedImageUrl = "",
                RaisedDateTime = DateTime.Now.AddDays(-5),
                ClosedOutDateTime = null
            },
            new Observation
            {
                ObservationId = 4,
                CompanyId = 2,
                Company = "Eden Farm",
                SiteId = 4,
                Site = new Site { SiteId = 4, Name = "Armstrong Road" },
                Status = "Invalid",
                Type = "Invalid",
                TypeOfReport = "Incident",
                NatureOfObservation = "False alarm",
                DescriptionOfSuggestion = "N/A",
                DescriptionOfObservation = "No issue found",
                ReporterName = "Bob White",
                UploadedImageUrl = "",
                RaisedDateTime = DateTime.Now.AddDays(-2),
                ClosedOutDateTime = null
            },
            new Observation
            {
                ObservationId = 5,
                CompanyId = 3,
                Company = "Creed",
                SiteId = 5,
                Site = new Site { SiteId = 5, Name = "Ilkiston" },
                Status = "Closed",
                Type = "Good",
                TypeOfReport = "Safety",
                NatureOfObservation = "Proper PPE",
                DescriptionOfSuggestion = "Continue PPE checks",
                DescriptionOfObservation = "All staff wearing PPE",
                ReporterName = "Charlie Green",
                UploadedImageUrl = "",
                RaisedDateTime = DateTime.Now.AddDays(-30),
                ClosedOutDateTime = DateTime.Now.AddDays(-25)
            },
            new Observation
            {
                ObservationId = 6,
                CompanyId = 4,
                Company = "Total Food Service",
                SiteId = 6,
                Site = new Site { SiteId = 6, Name = "York" },
                Status = "Outstanding",
                Type = "Bad",
                TypeOfReport = "Incident",
                NatureOfObservation = "Blocked exit",
                DescriptionOfSuggestion = "Clear exit",
                DescriptionOfObservation = "Boxes blocking fire exit",
                ReporterName = "Derek Black",
                UploadedImageUrl = "",
                RaisedDateTime = DateTime.Now.AddDays(-7),
                ClosedOutDateTime = null
            },
            new Observation
            {
                ObservationId = 7,
                CompanyId = 5,
                Company = "M&M Value",
                SiteId = 7,
                Site = new Site { SiteId = 7, Name = "Cumbria" },
                Status = "Closed",
                Type = "HS Suggestion",
                TypeOfReport = "Suggestion",
                NatureOfObservation = "Noise",
                DescriptionOfSuggestion = "Provide ear protection",
                DescriptionOfObservation = "High noise levels in packing area",
                ReporterName = "Emily Red",
                UploadedImageUrl = "",
                RaisedDateTime = DateTime.Now.AddDays(-12),
                ClosedOutDateTime = DateTime.Now.AddDays(-10)
            },
            new Observation
            {
                ObservationId = 8,
                CompanyId = 6,
                Company = "Teatime Tasties",
                SiteId = 8,
                Site = new Site { SiteId = 8, Name = "Bradford" },
                Status = "Outstanding",
                Type = "Good",
                TypeOfReport = "Safety",
                NatureOfObservation = "Well organized",
                DescriptionOfSuggestion = "Maintain standards",
                DescriptionOfObservation = "Warehouse tidy and organized",
                ReporterName = "Fiona Blue",
                UploadedImageUrl = "",
                RaisedDateTime = DateTime.Now.AddDays(-3),
                ClosedOutDateTime = null
            },
            new Observation
            {
                ObservationId = 9,
                CompanyId = 7,
                Company = "Turner & Wrights",
                SiteId = 9,
                Site = new Site { SiteId = 9, Name = "Bolton" },
                Status = "Invalid",
                Type = "Invalid",
                TypeOfReport = "Incident",
                NatureOfObservation = "No issue",
                DescriptionOfSuggestion = "N/A",
                DescriptionOfObservation = "Report submitted in error",
                ReporterName = "George Yellow",
                UploadedImageUrl = "",
                RaisedDateTime = DateTime.Now.AddDays(-1),
                ClosedOutDateTime = null
            },
            new Observation
            {
                ObservationId = 10,
                CompanyId = 8,
                Company = "West Country",
                SiteId = 10,
                Site = new Site { SiteId = 10, Name = "Falmouth" },
                Status = "Closed",
                Type = "Bad",
                TypeOfReport = "Incident",
                NatureOfObservation = "Wet floor",
                DescriptionOfSuggestion = "Place warning signs",
                DescriptionOfObservation = "Slippery floor in loading bay",
                ReporterName = "Helen Purple",
                UploadedImageUrl = "",
                RaisedDateTime = DateTime.Now.AddDays(-18),
                ClosedOutDateTime = DateTime.Now.AddDays(-16)
            },
            new Observation
            {
                ObservationId = 11,
                CompanyId = 9,
                Company = "Westone Wholesale",
                SiteId = 11,
                Site = new Site { SiteId = 11, Name = "Telford" },
                Status = "Outstanding",
                Type = "HS Suggestion",
                TypeOfReport = "Suggestion",
                NatureOfObservation = "Temperature",
                DescriptionOfSuggestion = "Install fans",
                DescriptionOfObservation = "High temperature in storage area",
                ReporterName = "Ian Orange",
                UploadedImageUrl = "",
                RaisedDateTime = DateTime.Now.AddDays(-8),
                ClosedOutDateTime = null
            },
            new Observation
            {
                ObservationId = 12,
                CompanyId = 10,
                Company = "Wilds Of Oldham",
                SiteId = 12,
                Site = new Site { SiteId = 12, Name = "Oldham" },
                Status = "Closed",
                Type = "Good",
                TypeOfReport = "Safety",
                NatureOfObservation = "Quick response",
                DescriptionOfSuggestion = "Acknowledge team",
                DescriptionOfObservation = "Team responded quickly to alarm",
                ReporterName = "Jack Pink",
                UploadedImageUrl = "",
                RaisedDateTime = DateTime.Now.AddDays(-22),
                ClosedOutDateTime = DateTime.Now.AddDays(-20)
            }
        };

        public static List<Observation> GetAll() => _observations;

        public static Observation? GetById(int id) =>
            _observations.FirstOrDefault(o => o.ObservationId == id);

        public static void Add(Observation observation)
        {
            observation.ObservationId = _observations.Any() ? _observations.Max(o => o.ObservationId) + 1 : 1;
            _observations.Add(observation);
        }

        public static void Update(Observation updated)
        {
            var idx = _observations.FindIndex(o => o.ObservationId == updated.ObservationId);
            if (idx >= 0)
                _observations[idx] = updated;
        }

        public static void Delete(int id)
        {
            var obs = _observations.FirstOrDefault(o => o.ObservationId == id);
            if (obs != null)
                _observations.Remove(obs);
        }
    }
}
