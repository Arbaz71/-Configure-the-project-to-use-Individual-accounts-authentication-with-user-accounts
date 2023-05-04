using System.ComponentModel.DataAnnotations;

namespace CodingExercise.Dto
{
    public class PresentationDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [StringLength(255)]
        public string PresenterName { get; set; }
        [Required]
        [Range(1, 60)]
        public int Duration { get; set; }
    }
}
