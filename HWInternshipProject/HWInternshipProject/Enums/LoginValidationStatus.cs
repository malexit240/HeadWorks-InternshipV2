namespace HWInternshipProject.Services
{
    /// <summary>
    /// Enums possible statuses of login validation process
    /// </summary>
    public enum LoginValidationStatus { Valid = 0, InvalidLength, StartsWithDigit, LoginNotUnique };
}
