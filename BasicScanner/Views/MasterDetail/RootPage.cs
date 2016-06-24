using System;
using System.Collections.Generic;
using System.Linq;
using Realms;
using Xamarin.Forms;

namespace BasicScanner
{
	public partial class RootPage : MasterDetailPage
	{
		Realm _realm;

		//Constructor for if the user is coming from the LoginPage
		public RootPage(RealmDB.User user)
		{
			Detail = new NavigationPage(new MasterPage(user));
			NavigationPage.SetHasNavigationBar(this, false);
			Master = new OptionsPage(user)
			{
				Icon = "burg.png",
				Title = "menu",
				BackgroundColor = Color.FromHex("d3d3d3")
			};
		}

		// Constructor for if the user is already logged in
		public RootPage()
		{
			_realm = Realm.GetInstance();
			RealmDB.User user = _realm.All<RealmDB.User>().ToList().FirstOrDefault();
			Detail = new NavigationPage(new MasterPage(user));
			NavigationPage.SetHasNavigationBar(this, false);
			Master = new OptionsPage(user)
			{
				Icon = "burg.png",
				Title = "menu",
				BackgroundColor = Color.FromHex("d3d3d3")
			};
		}

	}
}

