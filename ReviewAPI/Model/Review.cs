using System.ComponentModel.DataAnnotations;

namespace ReviewAPI.Model
{
    public class Review
    {
        public int Id { get; set; }
        [Required]

        public string? Name { get; set; }
        [Required]
        public string? Role { get; set; }
        [Required]
        public string? Message { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.Now;

    }
}
