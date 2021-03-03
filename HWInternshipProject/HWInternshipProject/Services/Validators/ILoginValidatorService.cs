using System.Threading.Tasks;

namespace HWInternshipProject.Services.Validators
{
    public interface ILoginValidatorService
    {
        Task<LoginValidationStatus> IsLoginValid(string login);
    }
}
