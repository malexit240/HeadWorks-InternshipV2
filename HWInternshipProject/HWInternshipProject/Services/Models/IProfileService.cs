using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HWInternshipProject.Models;

namespace HWInternshipProject.Services.Models
{
    /// <summary>
    /// Defines interface for logical operation with profiles
    /// </summary>
    public interface IProfileService
    {
        /// <summary>
        /// Returns list of users profiles
        /// </summary>
        /// <param name="userId">Parent user id for profiles</param>
        /// <returns>List of profiles</returns>
        Task<List<Profile>> GetProfilesForUser(Guid userId);

        /// <summary>
        /// Returns list of users profiles
        /// </summary>
        /// <param name="userId">Parent user instance for profiles</param>
        /// <returns>List of profiles</returns>
        Task<List<Profile>> GetProfilesForUser(User user);

        /// <summary>
        /// Add new profile instance to database
        /// </summary>
        /// <param name="profile">Profile instance</param>
        void AddProfile(Profile profile);

        /// <summary>
        /// Update profile in database
        /// </summary>
        /// <param name="profile">Profile instance</param>
        void UpdateProfile(Profile profile);

        /// <summary>
        /// Remove profile from database
        /// </summary>
        /// <param name="profile">Profile instance</param>
        void RemoveProfile(Profile profile);
    }
}
