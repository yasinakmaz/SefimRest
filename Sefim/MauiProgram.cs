namespace Sefim
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureSyncfusionToolkit()
                .UseNaluControls()
                .UseNaluNavigation<App>()
                .UseNaluLayouts()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("EthosNova-Bold.ttf", "EthosNovaBold");
                    fonts.AddFont("EthosNova-Medium.ttf", "EthosNovaMedium");
                    fonts.AddFont("EthosNova-Heavy.ttf", "EthosNovaHeavy");
                    fonts.AddFont("EthosNova-Regular.ttf", "EthosNovaRegular");
                });

            return builder.Build();
        }
    }
}
