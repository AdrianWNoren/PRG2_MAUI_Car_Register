namespace PRG_MAUI_Car_Register
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<ViewModel.MainPageViewModel, ViewModel.AlertMessage>(
                this, "ShowAlert", async (sender, message) =>
                {
                    await DisplayAlert(message.Title, message.Message, "OK");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<ViewModel.MainPageViewModel, ViewModel.AlertMessage>(this, "ShowAlert");
        }
    }
}