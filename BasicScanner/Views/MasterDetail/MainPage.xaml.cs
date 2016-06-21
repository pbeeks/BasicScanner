using System;
using System.Collections.Generic;
using System.Linq;
using Realms;
using Xamarin.Forms;

namespace BasicScanner
{
	public partial class MainPage : MasterDetailPage
	{
		Realm _realm;

		//Constructor for if the user is coming from the LoginPage
		public MainPage(RealmDB.User user)
		{
			Detail = new NavigationPage(new MasterPage(user));
			NavigationPage.SetHasNavigationBar(this, false);
			Master = new OptionsPage(user)
			{
				Icon = "menuIcon2.png",
				Title = "menu",
				BackgroundColor = Color.FromHex("d3d3d3")
			};
		}

		// Constructor for if the user is already logged in
		public MainPage()
		{
			_realm = Realm.GetInstance();
			RealmDB.User user = _realm.All<RealmDB.User>().ToList().FirstOrDefault();
			Detail = new NavigationPage(new MasterPage(user));
			NavigationPage.SetHasNavigationBar(this, false);
			Master = new OptionsPage(user)
			{
				Icon = "menuIcon2.png",
				Title = "menu",
				BackgroundColor = Color.FromHex("d3d3d3")
			};
		}

	}
}

