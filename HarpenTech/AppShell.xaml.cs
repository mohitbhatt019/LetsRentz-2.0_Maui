using HarpenTech.NewFolder;
using HarpenTech.Services;
using HarpenTech.Services.RequestProvider;
using HarpenTech.Services.SecureServiceStorage;
using HarpenTech.Views;
using HarpenTech.Views.HomePage;
using HarpenTech.Views.RecievePage;

namespace HarpenTech
{
    /// <summary>
    /// Represents the main navigation shell of the application, derived from the Shell class.
    /// </summary>
    public partial class AppShell : Shell
    {
        // Service for handling navigation within the application.
        private readonly INavigationService _navigationService;
        private readonly ISecureStorageService _secureStorageService;
        private readonly DatabaseContext _context;
        private readonly IRequestProvider _requestProvider;


        // Constructor for initializing the AppShell with the provided navigation service.
        public AppShell(INavigationService navigationService)
        {
            _navigationService = navigationService;

            // Initialize routing by registering routes for different views.
            AppShell.InitializeRouting();
            InitializeComponent();
        }


        /// <summary>
        /// This method is invoked when the Page is about to appear on the screen.
        /// </summary>
        protected async override void OnAppearing()
        {
           await _navigationService.NavigateToAsync("//login");
        }



        /// <summary>
        /// Static method to register routes for different views within the application.
        /// </summary>
        private static void InitializeRouting()
        {
            // Register routes for various views in the application.
            Routing.RegisterRoute("//login/details", typeof(LoginView));
            Routing.RegisterRoute("//HomePage/details", typeof(CMSHomePage));
            Routing.RegisterRoute("//Recieve/details", typeof(RecieveView));
        }

        /// <summary>
        /// Initiates push and pull operations.
        /// </summary>


        /// <summary>
        /// Helper method to retrieve the stored date time.
        /// </summary>
        /// <returns>The current date and time.</returns>
        private DateTime GetStoredDateTime()
        {
            return DateTime.Now;
        }
    }

}