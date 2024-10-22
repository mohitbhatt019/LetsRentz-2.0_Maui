using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HarpenTech.Models.Models;
using HarpenTech.Services;
using HarpenTech.ViewModels.Base;
using HarpenTech.Views.RecievePage;
using Newtonsoft.Json;

namespace HarpenTech.ViewModels
{
    public partial class HomeViewModel : ViewModelBase
    {
        private string _userInput;
        private readonly HttpClient _httpClient;

        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
            _httpClient = new HttpClient();  // Initialize HttpClient

        }     // Property to store user input
        [ObservableProperty]
        private string userInput;
        [RelayCommand]
        public async Task SubmitAsync()
        {
            if (!string.IsNullOrEmpty(userInput))
            {
           
                  string apiUrl = $"https://www.letsrentz.com/getPropertyWithPID?pid={userInput}";

                try
                {
                    var responseString = await _httpClient.GetStringAsync(apiUrl);
                    Root apiResponse = JsonConvert.DeserializeObject<Root>(responseString);

                    if (apiResponse != null)
                    {

                        // Pass the first property listing in the data as a route parameter
                        var routeParameters = new Dictionary<string, object>
                {
                    { "propertyData", apiResponse.data.propertyListing[0] }
                };
                        await IsBusyFor(
         async () =>
         {
             // Hide the keyboard
             await Task.Delay(800);

                          await Shell.Current.Navigation.PushAsync(new RecieveView(apiResponse));
                  });
                //await NavigationService.NavigateToAsync("//Recieve", routeParameters);
            }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "", "OK");
                    }
                }

                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Check your network connection. Please try again later.", "OK");
                }
      
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Input Error", "Please enter a valid Property ID.", "OK");
            }
        }

    }
}