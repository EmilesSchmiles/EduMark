using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using EduMark.Models;
using EduMark.Services;

namespace EduMark.Components.Pages
{
    public class LoginBase : ComponentBase
    {
        protected LoginModel LoginModel { get; set; } = new();

        [Inject]public required NavigationManager Navigation { get; set; }

        protected void HandleLogin()
        {
            // TODO: validate credentials
            Navigation.NavigateTo("/home");
        }

        protected void NavigateToRegister() => Navigation.NavigateTo("/register");
    }

}
