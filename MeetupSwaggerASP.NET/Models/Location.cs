namespace MeetupSwaggerASP.NET.Models
{
    public class Location
    {
        public int? Id { get; set; }
        public string DisplayName { get; set; }
        
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string ZipCode{ get; set; }
        public string City { get; set; }

        public Country Country{ get; set; }
    }
}