using EduMark.Models;

namespace EduMark.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterTeacherAsync(string fullName, string email, string password);
        Task<bool> VerifyOtpAsync(string email, string otp);
        Task<Teacher?> LoginAsync(string email, string password);

    }
}
