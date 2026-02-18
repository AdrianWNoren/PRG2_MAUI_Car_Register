using PRG_MAUI_Car_Register.ViewModel;
using Microsoft.Maui.Controls;

namespace PRG_MAUI_Car_Register
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();

            // Sätt BindingContext här istället för i XAML
            BindingContext = viewModel;

            // Prenumerera på alerts
            MessagingCenter.Subscribe<MainPageViewModel, AlertMessage>(
                this,
                "ShowAlert",
                async (sender, message) =>
                {
                    await DisplayAlert(message.Title, message.Message, "OK");
                });
        }

        // Glöm inte att avregistrera vid navigering
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<MainPageViewModel, AlertMessage>(this, "ShowAlert");
        }
    }
}