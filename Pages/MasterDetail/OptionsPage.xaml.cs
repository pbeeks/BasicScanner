using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace BasicScanner
{
	public partial class OptionsPage : ContentPage
	{
		private RealmDB.User currUser;
		public OptionsPage(RealmDB.User user)
		{
			currUser = user;
			InitializeComponent();
		}

		public async void HistoryClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new HistoryPage(currUser){
				Title = "History"
			});
		}

		public async void LogOutClicked(object sender, EventArgs e)
		{
			var result = await UserDialogs.Instance.ConfirmAsync("Are you sure you want to log out?", "Log out", "Yes", "No");
			if (result == true) {
				App.Current.MainPage = new LoginPage();
			}
		}
	}
}

