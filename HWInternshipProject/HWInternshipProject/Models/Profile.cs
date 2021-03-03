using System;

namespace HWInternshipProject.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string ImageDestination { get; set; } = "";
        public string NickName { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime CreationTime { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }

        public static event EventHandler Actualize;

        public void RaiseActualize()
        {
            Actualize?.Invoke(this, new EventArgs());
        }
    }
}
