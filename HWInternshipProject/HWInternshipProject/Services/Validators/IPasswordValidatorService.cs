namespace HWInternshipProject.Services.Validators
{
    public interface IPasswordValidatorService
    {
        PasswordValidationStatus IsPasswordValid(string password);
    }
}
