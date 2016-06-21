using Xamarin.Forms;

namespace BasicScanner
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			var isLoggedIn = Properties.ContainsKey("IsLoggedIn") ? (bool)Properties["IsLoggedIn"] : false;
			if (isLoggedIn == true)
			{
				MainPage = new NavigationPage(new MainPage());
			}
			else { 
				MainPage = new NavigationPage(new LoginPage());
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

