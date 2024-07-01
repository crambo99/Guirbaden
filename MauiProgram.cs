using CommunityToolkit.Maui;
using Guirbaden.Pages;
using Guirbaden.Viewmodel;
using Microsoft.Extensions.Logging;

namespace Guirbaden
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()                
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif  
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<Animations>();
            builder.Services.AddSingleton<AnimationViewModel>();
            builder.Services.AddSingleton<Param>();
            builder.Services.AddSingleton<ParamViewModel>();

            return builder.Build();
        }
    }
}
