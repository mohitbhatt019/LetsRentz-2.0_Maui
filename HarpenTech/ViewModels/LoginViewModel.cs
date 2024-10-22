using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HarpenTech.Models;
using HarpenTech.Services;
using HarpenTech.Services.RequestProvider;
using HarpenTech.Services.SecureServiceStorage;
using HarpenTech.Services.Settings;
using HarpenTech.ViewModels.Base;
using HarpenTech.Views.HomePage;

namespace HarpenTech.ViewModels;

// Partial class for the LoginViewModel, extending ViewModelBase
public partial class LoginViewModel : ViewModelBase
{
    // Private fields to store services and observable properties
    private readonly ISettingsService _settingsService;
    private readonly IRequestProvider _requestProvider;
    private readonly ISecureStorageService _secureStorageService;

    #region Observable properties

    // Observable property for the username
    [ObservableProperty]
    string _userName;

    // Observable property for the password
    [ObservableProperty]
    string _password;

    // Observable property for tracking the login status
    [ObservableProperty]
    private bool _isLogin;

    // Observable property for storing the login URL
    [ObservableProperty]
    private string _loginUrl;

    // Observable property for AppVersion
    [ObservableProperty]
    private string _appversion;

    // Observable property for ReleaseDate
    [ObservableProperty]
    private DateOnly _releaseDate;

    // Observable property for FormatedReleaseDate
    [ObservableProperty]
    private string _formattedReleaseDate;

    // Observable property for FormattedAppVersion
    [ObservableProperty]
    private string _formattedAppVersion;

    // Observable property for MainDb
    [ObservableProperty]
    private string _mainDb;

    // Observable property for Depot
    [ObservableProperty]
    private string _depot;

    // Observable property for Depot
    [ObservableProperty]
    private bool _isClicked = false;
    #endregion

    // Constructor for the LoginViewModel, taking services as parameters
    public LoginViewModel(INavigationService navigationService)
        : base(navigationService)
    {

    }


    // Override method to apply query attributes
    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        base.ApplyQueryAttributes(query);
    }

    // Override method to initialize the ViewModel asynchronously
    public override Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// Asynchronous method for handling the login button click event.
    /// </summary>
    [RelayCommand]
    private async void LoginClickAsync()
    {
        try
        {
            if (_isClicked == false)
            {
                Application.Current.MainPage.DisplayAlert(
                "Subscribe??",
               "Subscribe the channel before login", "Ok");
                return;
            }
            if (Device.RuntimePlatform == Device.Android)
            {

                await IsBusyFor(
               async () =>
               {
      
                   // Check if the access token is not empty
                   if (UserName == "bhatt" && Password == "bhatt")
                   {
                       // Clear username and password, set access token, and save it securely
                       UserName = "";
                       Password = "";


                       #region Snackbar

                       var snackbarOptions = new SnackbarOptions
                       {
                           BackgroundColor = Colors.LightGray,
                           TextColor = Colors.Black,
                           CornerRadius = new CornerRadius(0, 00, 00, 00),
                           Font = Microsoft.Maui.Font.SystemFontOfSize(15),
                           ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(0),
                           CharacterSpacing = 0.2

                       };

                       string text = " \u2713 User Logged in Successfully";
                       string actionButtonText = "";
                       Action action = async () => await Shell.Current.DisplayAlert("Snackbar ActionButton Tapped", "The user has tapped the Snackbar ActionButton", "OK");
                       TimeSpan duration = TimeSpan.FromSeconds(2);

                       var snackbar = Snackbar.Make(text, action, actionButtonText, duration, snackbarOptions);

                       await Task.Delay(2000);
                       await snackbar.Show();
                       #endregion
                       NavigationPage navigationPage = new NavigationPage();
                       HomeViewModel homeViewModel = new HomeViewModel(NavigationService);
                       CMSHomePage cMSHomePage = new CMSHomePage(homeViewModel);
                       _isClicked = false;

                       // Navigate to RecieveView
                       await NavigationService.NavigateToAsync("//HomePage");
                       // Navigate to the home page
                   }
                   else
                   {
                       #region Snackbar

                       var snackbarOptions = new SnackbarOptions
                       {
                           BackgroundColor = Colors.Red,
                           TextColor = Colors.Black,
                           CornerRadius = new CornerRadius(0, 00, 00, 00),
                           Font = Microsoft.Maui.Font.SystemFontOfSize(10),
                           ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(0),
                           CharacterSpacing = 0.2

                       };
                       string text = " ! Login failed. Please check your credentials";
                       string actionButtonText = "";
                       Action action = async () => await Shell.Current.DisplayAlert("Snackbar ActionButton Tapped", "The user has tapped the Snackbar ActionButton", "OK");
                       TimeSpan duration = TimeSpan.FromSeconds(4);

                       var snackbar = Snackbar.Make(text, action, actionButtonText, duration, snackbarOptions);
                       await snackbar.Show();

                       #endregion
                   }

               });
            }




        }
        catch (Exception ex)
        {
            #region Toster
            string text = "Something Went Wrong, Check Your Internet Connection";
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 17;

            var toast = Toast.Make(text, duration, fontSize);

            await toast.Show();
            #endregion

        }
    }

    /// <summary>
    /// Asynchronous method for handling the setting button click event.
    /// </summary>
    [RelayCommand]
    private async void SettingClick()
    {
        // Navigate to the settings page
        await NavigationService.NavigateToAsync("//Settings/details");
    }

    [RelayCommand]
    private async void SubscribeClick()
    {
        try
        {
            // Combine the base URL with the update URL.
            string fullUpdateUrl = "https://linktw.in/QdfqGX";


            // Notify the user about the update and prompt for confirmation.
            bool userWantsToUpdate = await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert(
                "Subscribe the channel before login",
                "Want to subscribe",
                "Yes",
                "No");

            // If the user agrees to update, open the browser to the update URL.
            if (userWantsToUpdate)
            {
                Launcher.OpenAsync(fullUpdateUrl);
                _isClicked = true;
            }
        }
        catch (HttpRequestException ex)
        {
            // Handle HTTP request exception during the update process.
            Console.WriteLine($"HTTP request exception: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Handle other exceptions during the update process.
            Console.WriteLine($"Exception: {ex.Message}");
        }

    }

}