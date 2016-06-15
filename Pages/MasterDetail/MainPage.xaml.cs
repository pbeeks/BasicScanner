using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BasicScanner
{
	public partial class MainPage : MasterDetailPage
	{
		public MainPage(RealmDB.User user)
		{
			Detail = new NavigationPage(new MasterPage(user));
			Master = new OptionsPage(user)
			{
				Title = "Menu",
				BackgroundColor = Color.FromHex("d3d3d3")
			};
		}


	}
}

