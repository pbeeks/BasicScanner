using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Realms;
using Xamarin.Forms;

namespace BasicScanner
{
	public class OptionsPageViewModel : ContentPage
	{
		private Realm _realm;
		private RealmDB.User currUser;
		private INavigation _nav;

		public OptionsPageViewModel(RealmDB.User user, INavigation navigation)
		{
			_nav = navigation;
			currUser = user;
			_realm = Realm.GetInstance();
		}

		public Command _historyCommand;
		public ICommand HistoryCommand
		{
			get
			{
				if (_historyCommand == null)
				{
					_historyCommand = new Command(async () => await HistoryTask());
				}
				return _historyCommand;
			}
		}

		async Task HistoryTask()
		{
			await _nav.PushAsync(new HistoryPage(currUser)
			{
				Title = "History"
			});
		}

		public Command _logoutCommand;
		public ICommand LogoutCommand
		{
			get
			{
				if (_logoutCommand == null)
				{
					_logoutCommand = new Command(async () => await LogoutTask());
				}
				return _logoutCommand;
			}
		}


		async Task LogoutTask()
		{
			bool result = await UserDialogs.Instance.ConfirmAsync("Are you sure you want to log out?", "Log out", "Yes", "No");
			if (result == true)
			{
				App.Current.Properties["IsLoggedIn"] = false;
				App.Current.MainPage = new LoginPage();
			}


		}
	}
}


