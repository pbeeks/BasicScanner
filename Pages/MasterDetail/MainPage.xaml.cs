﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BasicScanner
{
	public partial class MainPage : MasterDetailPage
	{
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


	}
}

