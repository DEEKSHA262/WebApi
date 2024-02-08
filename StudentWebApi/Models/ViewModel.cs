using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentWebApi.Models
{
    public class ViewModel
    {
        public string? Id { get; set; }
        [Required]
        [DisplayName(" Student Name  ")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; } = null!;
        [Required]

        public List<string> studentsID { get; set; }
    }
}
