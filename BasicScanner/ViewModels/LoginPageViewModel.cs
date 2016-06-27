using System;
using Xamarin.Forms;
using Realms;
using System.Linq;
using Acr.UserDialogs;
using System.ServiceModel.Channels;

namespace BasicScanner
{
	public class LoginPageViewModel
	{
		private Realm _realm;
		public LoginPageViewModel() {
			
		}

		// Method to login the user
		public async void Login(string userParam, string passParam)
		{

			_realm = Realm.GetInstance();
			var currentUser = _realm.All<RealmDB.User>().Where(d => (d.username == userParam)).ToList().FirstOrDefault();
			if (currentUser == null)
			{
				// Give the user opportunity to create a new user
				var answer = await UserDialogs.Instance.ConfirmAsync("User not found, create user " + userParam + "?", "Cancel", "Create");
				if (answer == true)
				{
					RealmDB.User loginUser = null;
					_realm.Write(() =>
					{
						var newUser = _realm.CreateObject<RealmDB.User>();
						newUser.username = userParam;
						newUser.password = passParam;
						loginUser = newUser;
					});

					// SHow successful login
					UserDialogs.Instance.SuccessToast("User created", null, 3000);


					App.Current.MainPage = new NavigationPage(new RootPage(loginUser));
				}
			}
			else
			{
				// Check if the username & password match
				var loginUser = _realm.All<RealmDB.User>().Where(u => u.username == userParam && u.password == passParam).ToList().FirstOrDefault();
				if (loginUser == null)
				{
					// Show login failure
					UserDialogs.Instance.ErrorToast("Login failed", "Username or password incorrect", 3000);
				}

				App.Current.MainPage = new NavigationPage(new RootPage(loginUser));
			}
		}


	}
}

