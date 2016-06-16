using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BasicScanner
{
	public partial class HistoryDetailsPage : ContentPage
	{
		public HistoryDetailsPage(RealmDB.ScanResult info)
		{
			InitializeComponent();
		}

		public void BackClicked(object sender, EventArgs e) {
			Navigation.PopModalAsync();
		}
	}
}

