using System;
using Xamarin.Forms;
using Realms;
using System.Linq;

namespace BasicScanner
{
	public class LoginPageViewModel
	{
		private Realm _realm;
		LoginPage page = new LoginPage();
		public LoginPageViewModel() {
			
		}

		public async void Login(string userParam, string passParam)
		{

			_realm = Realm.GetInstance();
			var currentUser = _realm.All<RealmDB.User>().Where(d => (d.username == userParam)).ToList().FirstOrDefault();
			if (currentUser == null)
			{
				var answer = await page.DisplayAlert("Login Failed", "Would you like to create a user with the username " + userParam + "?", "Yes", "No");
				if (answer == true)
				{
					_realm.Write(() =>
					{
						var newUser = _realm.CreateObject<RealmDB.User>();
						newUser.username = userParam;
						newUser.password = passParam;
					});
				}
				else{
					return;
				}

			}
		}

	}
}

