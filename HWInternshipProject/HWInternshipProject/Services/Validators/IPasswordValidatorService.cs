namespace HWInternshipProject.Services.Validators
{
    /// <summary>
    /// Defines interface for password validation process
    /// </summary>
    public interface IPasswordValidatorService
    {
        /// <summary>
        /// Defines whether password valid
        /// </summary>
        /// <param name="password"></param>
        /// <returns>Status of password validation process</returns>
        PasswordValidationStatus IsPasswordValid(string password);
    }
}
