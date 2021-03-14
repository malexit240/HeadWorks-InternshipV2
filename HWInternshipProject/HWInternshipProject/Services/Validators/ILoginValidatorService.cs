using System.Threading.Tasks;

namespace HWInternshipProject.Services.Validators
{
    /// <summary>
    /// Defines interface fro login validation process
    /// </summary>
    public interface ILoginValidatorService
    {
        /// <summary>
        /// Defines whether login valid
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Status of login validation process</returns>
        Task<LoginValidationStatus> IsLoginValid(string login);
    }
}
