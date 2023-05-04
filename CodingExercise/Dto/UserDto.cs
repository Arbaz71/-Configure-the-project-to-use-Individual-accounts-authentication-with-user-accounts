using System.ComponentModel.DataAnnotations;

namespace CodingExercise.Dto
{
    public class UserDto
    {   
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
