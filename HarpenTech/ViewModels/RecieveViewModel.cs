using CommunityToolkit.Mvvm.ComponentModel;
using HarpenTech.Models.Models;
using System.Windows.Input;

public partial class RecieveViewModel : ObservableObject
{
    [ObservableProperty]
    private Root root;

    [ObservableProperty]
    private bool isBusy;
    public ICommand PhoneTapCommand { get; }
    public ICommand OpenImageCommand { get; }

    public ICommand OpenMapCommand => new Command<PropertyListing>(async (property) =>
    {
        var latitude = property.lati;
        var longitude = property.longi;

        var location = new Location(latitude, longitude);
        var options = new MapLaunchOptions
        {
            NavigationMode = NavigationMode.Driving
        };

        await Map.OpenAsync(location, options);
    });
    public RecieveViewModel(Root rootData)
    {
        root = rootData; // Set the Root model data
        isBusy = false; // Initial loading state
        PhoneTapCommand = new Command(async () =>
        {
            var action = await Application.Current.MainPage.DisplayActionSheet("Phone Options", "Cancel", null, "Copy to Clipboard", "Call");
            if (action == "Copy to Clipboard")
            {
                await Clipboard.SetTextAsync(root.data.propertyListing[0].user_detail.phone_number);
                await Application.Current.MainPage.DisplayAlert("Copied", "Phone number copied to clipboard.", "OK");
            }
            else if (action == "Call")
            {
                PhoneDialer.Open(root.data.propertyListing[0].user_detail.phone_number);
            }
        });

    }



}