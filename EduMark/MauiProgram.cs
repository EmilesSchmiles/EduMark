using Microsoft.Extensions.Logging;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using EduMark.Data;
using EduMark.Services;
using Microsoft.Maui.LifecycleEvents;

#if WINDOWS
using Microsoft.UI.Windowing;
using Windows.Graphics;
using WinUIColor = Windows.UI.Color;         // For Color.FromArgb()
using WinUIColors = Microsoft.UI.Colors;     // Predefined colors
#endif

namespace EduMark
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            builder.Services
                .AddBlazorise(options => { options.Immediate = true; })
                .AddBootstrap5Providers()
                .AddFontAwesomeIcons();

            builder.Services.AddSingleton<AppDb>();
            builder.Services.AddSingleton<AuthService>();

#if WINDOWS
builder.ConfigureLifecycleEvents(events =>
{
    events.AddWindows(win =>
    {
        win.OnWindowCreated(window =>
        {
            var appWindow = window.AppWindow;
            if (appWindow is null) return;

            if (appWindow.Presenter is OverlappedPresenter presenter)
                presenter.SetBorderAndTitleBar(true, true);

            var titleBar = appWindow.TitleBar;
            if (titleBar is null) return;

            // Extend content
            titleBar.ExtendsContentIntoTitleBar = true;

            // Colors
            var darkGrey = Windows.UI.Color.FromArgb(255, 45, 45, 45);
            titleBar.BackgroundColor = darkGrey;
            titleBar.ButtonBackgroundColor = darkGrey;
            titleBar.ButtonHoverBackgroundColor = Windows.UI.Color.FromArgb(255, 60, 60, 60);
            titleBar.ButtonForegroundColor = Microsoft.UI.Colors.White;
            titleBar.ForegroundColor = Microsoft.UI.Colors.White;

            // Resize and center window
            int targetWidth = 1600;
            int targetHeight = 1000;
            appWindow.Resize(new SizeInt32(targetWidth, targetHeight));

            var displayArea = DisplayArea.GetFromWindowId(appWindow.Id, DisplayAreaFallback.Primary);
            int centerX = (displayArea.WorkArea.Width - targetWidth) / 2;
            int centerY = (displayArea.WorkArea.Height - targetHeight) / 2;
            appWindow.Move(new PointInt32(centerX, centerY));
        });
    });
});
#endif



            return builder.Build();
        }
    }
}
