namespace PRG_MAUI_Car_Register
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Ta bort denna rad:
            // MainPage = new AppShell();

            // Använd istället CreateWindow
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            return new Window(new AppShell())
            {
                // Optional: Ställ in fönsterstorlek för desktop
                Width = 400,
                Height = 800,
                Title = "PRG MAUI Car Register"
            };
        }
    }
}