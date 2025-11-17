using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace EduMark.Components.Pages
{
    public class LoginBase : ComponentBase
    {
        protected LoginModel LoginModel { get; set; } = new();

        [Inject] NavigationManager Navigation { get; set; }

        protected void HandleLogin()
        {
            // TODO: validate credentials
            Navigation.NavigateTo("/home");
        }

        protected void NavigateToRegister()
        {
            Navigation.NavigateTo("/register");
        }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
