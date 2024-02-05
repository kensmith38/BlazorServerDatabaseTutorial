using System.ComponentModel.DataAnnotations;

namespace BlazorServerDatabaseTutorial.Data
{
    public class Volunteer
    {
        [Key]
        public int Id { get; set; }
        public string VolunteerName { get; set; }
        public string? VolunteerPhone { get; set; }
        public string? VolunteerEmail { get; set; }

    }
}
