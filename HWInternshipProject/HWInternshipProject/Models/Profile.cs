using System;
using System.ComponentModel.DataAnnotations;

namespace HWInternshipProject.Models
{
    /// <summary>
    /// Profile model`s class
    /// </summary>
    public class Profile
    {

        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int ProfileId { get; set; }

        /// <summary>
        /// Destination to image file
        /// </summary>
        public string ImageDestination { get; set; } = "";

        [Required]
        public string NickName { get; set; } = "";

        [Required]
        public string Name { get; set; } = "";

        [MaxLength(120, ErrorMessage = "Description must not be greater than 120")]
        public string Description { get; set; } = "";

        [Required]
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Parent user object
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Parent user key
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Occurs when profile table changes
        /// </summary>
        public static event EventHandler Actualize;

        /// <summary>
        /// Notify that model`s object changed in database
        /// </summary>
        public void InvokeActualize()
        {
            Actualize?.Invoke(this, new EventArgs());
        }
    }
}
