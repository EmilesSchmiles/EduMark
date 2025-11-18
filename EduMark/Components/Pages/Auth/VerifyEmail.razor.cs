using Microsoft.AspNetCore.Components;
using EduMark.Services.Interfaces;

namespace EduMark.Pages.Auth
{
    public class VerifyEmailBase : ComponentBase
    {
        [Parameter, SupplyParameterFromQuery]
        public string? Email { get; set; }

        public string Otp { get; set; } = "";
        public string Error { get; set; } = "";

        [Inject] public IAuthService AuthService { get; set; }
        [Inject] public NavigationManager NavManager { get; set; }

        protected async Task Verify()
        {
            bool ok = await AuthService.VerifyOtpAsync(Email!, Otp);
            if (ok)
                NavManager.NavigateTo("/login");
            else
                Error = "Invalid or expired OTP.";
        }
    }
}