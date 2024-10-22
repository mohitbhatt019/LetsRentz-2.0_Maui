﻿using CommunityToolkit.Maui;
using HarpenTech.Models.Models;
using HarpenTech.NewFolder;
using HarpenTech.Services;
using HarpenTech.Services.AppEnvironment;
using HarpenTech.Services.Container;
using HarpenTech.Services.Handler;
using HarpenTech.Services.PartialMethods;
using HarpenTech.Services.RequestProvider;
using HarpenTech.Services.SecureServiceStorage;
using HarpenTech.Services.Settings;
using HarpenTech.ViewModels;
using HarpenTech.Views;
using HarpenTech.Views.HomePage;
using HarpenTech.Views.RecievePage;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using UraniumUI;

namespace HarpenTech
{
    // This static class represents the entry point for configuring and building the MAUI application.
    public static class MauiProgram
    {
        // Method to create and configure the MauiApp instance.
        public static MauiApp CreateMauiApp()
       => MauiApp
           .CreateBuilder()
           .UseMauiApp<App>()
            .UseSkiaSharp()
           .ConfigureEffects(
               effects =>
               {// Additional configuration for effects can be added here if needed.
               })
           .UseMauiCommunityToolkit()
           .ConfigureFonts(
               fonts =>
               {
                   // Register custom fonts for the application.
                   fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                   fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                   fonts.AddFont("Font_Awesome_5_Free-Regular-400.otf", "FontAwesome-Regular");
                   fonts.AddFont("Font_Awesome_5_Free-Solid-900.otf", "FontAwesome-Solid");
                   fonts.AddFont("Montserrat-Bold.ttf", "Montserrat-Bold");
                   fonts.AddFont("Montserrat-Regular.ttf", "Montserrat-Regular");
                   fonts.AddFont("SourceSansPro-Regular.ttf", "SourceSansPro-Regular");
                   fonts.AddFont("SourceSansPro-Solid.ttf", "SourceSansPro-Solid");
               }).ConfigureEssentials(
                essentials =>
                {
                    // Configure essential services like version tracking.
                    essentials.UseVersionTracking();
                })
           .UseMauiApp<App>()
           .UseUraniumUI()
           .RegisterAppServices()
           .RegisterViewModels()
           .RegisterViews()
           .Build();

        // Method to register application-level services.
        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<DatabaseContext>();
            mauiAppBuilder.Services.AddSingleton<Root>();
            mauiAppBuilder.Services.AddSingleton<PropertyListing>();
        
            mauiAppBuilder.Services.AddSingleton<ISettingsService, SettingsService>();
            mauiAppBuilder.Services.AddSingleton<INavigationService, MauiNavigationService>();
            mauiAppBuilder.Services.AddTransient<IRequestProvider, RequestProvider>();
            mauiAppBuilder.Services.AddSingleton<ISecureStorageService, SecureStorageService>();
            mauiAppBuilder.Services.AddSingleton<FullScreenMessage>();



            mauiAppBuilder.Services.AddSingleton<IAppEnvironmentService, AppEnvironmentService>(
                serviceProvider =>
                {
                    var requestProvider = serviceProvider.GetService<IRequestProvider>();
                    var settingsService = serviceProvider.GetService<ISettingsService>();

                    // Create and configure the AppEnvironmentService.
                    var aes =
                        new AppEnvironmentService(
                            new ContainerMockService(), new ContainerService(requestProvider));

                    aes.UpdateDependencies(settingsService.UseMocks);
                    return aes;
                });

            return mauiAppBuilder;
        }

        // Method to register view models as singleton services.
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<LoginViewModel>();
            mauiAppBuilder.Services.AddSingleton<HomeViewModel>();
            mauiAppBuilder.Services.AddSingleton<RecieveViewModel>();

            return mauiAppBuilder;
        }

        // Method to register view classes as transient services.
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<LoginView>();
            mauiAppBuilder.Services.AddSingleton<CMSHomePage>();
            mauiAppBuilder.Services.AddSingleton<RecieveView>();

            return mauiAppBuilder;
        }
    }
}