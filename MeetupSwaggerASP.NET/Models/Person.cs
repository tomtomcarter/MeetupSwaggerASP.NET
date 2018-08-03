using System.Collections.Generic;

namespace MeetupSwaggerASP.NET.Models
{
    public class Person
    {
        public int? Id { get; set; }
        public string ExternalId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Office> Offices { get; set; }
        public Office DefaultOffice { get; set; }
    }
}