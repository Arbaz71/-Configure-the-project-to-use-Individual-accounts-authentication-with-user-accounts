using System.ComponentModel.DataAnnotations;

namespace CodingExercise.Model
{
    public class Presentations
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        [StringLength(255)]
        public string PresenterName { get; set; }
        [Required]
        [Range(1, 60)]
        public int Duration { get; set; }   
        public bool IsDeleted { get;set; }

        //internal void Update(Presentations item)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
