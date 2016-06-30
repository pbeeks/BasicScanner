using System.Linq;
using Realms;
using Xamarin.Forms;

namespace BasicScanner
{
	public partial class App : Application
	{
		Realm _realm;
		public static RealmDB.User pubUser { get; set; }

		public App()
		{
			InitializeComponent();
			_realm = Realm.GetInstance();
			var isLoggedIn = Properties.ContainsKey("IsLoggedIn") ? (bool)Properties["IsLoggedIn"] : false;
			string persistUser = Properties.ContainsKey("LoggedInUser") ? (string)App.Current.Properties["LoggedInUser"] : "nope";
			if (isLoggedIn == true)
			{
				pubUser = _realm.All<RealmDB.User>().Where(u => u.username == persistUser ).ToList().FirstOrDefault();

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

