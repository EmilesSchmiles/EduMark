#if WINDOWS
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

namespace EduMark
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage())
            {
                Title = ""
            };

        }
    }
}
