using Xamarin.Forms;

namespace BasicScanner
{
	public partial class App : Application
	{
		
		public static RealmDB.User pubUser { get; set; }

		public App()
		{
			InitializeComponent();

			var isLoggedIn = Properties.ContainsKey("IsLoggedIn") ? (bool)Properties["IsLoggedIn"] : false;
			if (isLoggedIn == true)
			{
				MainPage = new NavigationPage(new RootPage());
			}
			else {
				MainPage = new LoginPage();
			}
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

