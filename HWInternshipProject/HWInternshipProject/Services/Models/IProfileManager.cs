using System;
using System.Threading.Tasks;
using HWInternshipProject.Models;

namespace HWInternshipProject.Services.Models
{
    /// <summary>
    /// Defines interface of basic operation with profiles
    /// </summary>
    public interface IProfileManager
    {
        /// <summary>
        /// Creates profile in database
        /// </summary>
        /// <param name="profile">Profile instance for saving</param>
        /// <returns>Saved profile instance</returns>
        Task<Profile> Create(Profile profile);

        /// <summary>
        /// Creates profile in database
        /// </summary>
        /// <param name="user_id">Parent user id</param>
        /// <param name="nick">Nickname</param>
        /// <param name="name">Name</param>
        /// <param name="description">Description</param>
        /// <param name="imageDestination">Destination to image file</param>
        /// <returns>Saved profile instance</returns>
        Task<Profile> Create(Guid user_id, string nick, string name, string description = "", string imageDestination = "");

        /// <summary>
        /// Updates profile instance in database
        /// </summary>
        /// <param name="profile">Instance for updating</param>
        /// <returns></returns>
        Task Update(Profile profile);

        /// <summary>
        /// Deletes profile instance from database
        /// </summary>
        /// <param name="profile">Instance for deleting</param>
        /// <returns></returns>
        Task Delete(Profile profile);
    }
}
