using Microsoft.AspNetCore.Components;
using EduMark.Models;
using EduMark.Services.Implementations;
using EduMark.Services.Interfaces;

namespace EduMark.Components.Pages
{
    public class RegisterBase : ComponentBase
    {
        [Inject]        
        public required IAuthService AuthService { get; set; }

        [Inject]
        public required NavigationManager NavManager { get; set; }

        protected RegisterModel RegisterModel = new();
        protected string Message = "";

        protected async Task HandleRegister()
        {
            if (RegisterModel.Password != RegisterModel.ConfirmPassword)
            {
                Message = "Passwords do not match!";
                return;
            }

            bool success = await AuthService.RegisterTeacherAsync(
                RegisterModel.FullName,
                RegisterModel.Email,
                RegisterModel.Password
            );

            if (success)
            {
                Message = "Registration successful!";
                NavManager.NavigateTo($"/verifyemail?email={RegisterModel.Email}");
            }

            else
            {
                Message = "Email already exists.";
            }
        }

        protected void NavigateToLogin()
        {
            NavManager.NavigateTo("/login");
        }
    }
}
