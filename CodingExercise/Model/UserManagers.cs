using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodingExercise.Model
{
    public class UserManagers
    {
        [Key]
        public int UserId { get;set; }
        [Required]
        public string FirstName { get;set; }
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password {  get; set; }
    }
}
