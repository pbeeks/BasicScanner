using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BasicScanner
{
	public partial class OptionsPage : ContentPage
	{
		public OptionsPage(RealmDB.User user)
		{
			InitializeComponent();
		}

		public void HistoryClicked(object sender, EventArgs e) { 
			// TODO 
		}

		public void LogOutClicked(object sender, EventArgs e) { 
			// TODO
		}
	}
}

