using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BasicScanner
{
	public partial class HistoryDetailsPage : ContentPage
	{

		public HistoryDetailsPage(RealmDB.ScanResult Info)
		{
			// link up the data to the HistoryDetails page
			this.BindingContext = new HistoryDetailPageViewModel(Info);
			InitializeComponent();
		}

		public void BackClicked(object sender, EventArgs e) {
			Navigation.PopModalAsync();
		}
	}
}

