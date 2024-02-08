using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsumeWebApi.Models
{
    public class StudentViewModel
    {
        public string? Id { get; set; }
        [Required]
        [DisplayName ("Student Name")]
        public string Firstame { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        
    }
}
