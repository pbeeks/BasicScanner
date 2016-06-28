using System;
using System.Collections.Generic;
using System.Linq;
using Realms;
using Xamarin.Forms;

namespace BasicScanner
{
	public partial class RootPage : MasterDetailPage
	{

		public RootPage()
		{
			App app = new App();
			Detail = new NavigationPage(new MasterPage());
			NavigationPage.SetHasNavigationBar(this, false);
			Master = new OptionsPage()
			{
				Icon = "burg.png",
				Title = "menu",
				BackgroundColor = Color.FromHex("d3d3d3")
			};
		}

	}
}

