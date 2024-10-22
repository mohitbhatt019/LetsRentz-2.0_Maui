using HarpenTech.Models.Models;
using Microsoft.Maui.Controls;

namespace HarpenTech.Views.RecievePage
{
    public partial class RecieveView : ContentPage
    {
        public RecieveView(Root root)
        {
            InitializeComponent();
            BindingContext = new RecieveViewModel(root);

            var phoneLabel = new Label { Text = root.data.propertyListing[0].user_detail.phone_number };
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                var action = await DisplayActionSheet("Phone Options", "Cancel", null, "Copy to Clipboard", "Call");
                if (action == "Copy to Clipboard")
                {
                    await Clipboard.SetTextAsync(root.data.propertyListing[0].user_detail.phone_number);
                    await DisplayAlert("Copied", "Phone number copied to clipboard.", "OK");
                }
                else if (action == "Call")
                {
                    PhoneDialer.Open(root.data.propertyListing[0].user_detail.phone_number);
                }
            };

            phoneLabel.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
}
