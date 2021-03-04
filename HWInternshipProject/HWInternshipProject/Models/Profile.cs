using System;
using System.ComponentModel.DataAnnotations;

namespace HWInternshipProject.Models
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        public string ImageDestination { get; set; } = "";
        [Required]
        public string NickName { get; set; } = "";
        [Required]
        public string Name { get; set; } = "";
        [MaxLength(120, ErrorMessage = "Description must not be greater than 120")]
        public string Description { get; set; } = "";
        [Required]
        public DateTime CreationTime { get; set; }
        public User User { get; set; }
        [Required]
        public Guid UserId { get; set; }

        public static event EventHandler Actualize;

        public void RaiseActualize()
        {
            Actualize?.Invoke(this, new EventArgs());
        }
    }
}
