using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace BasicScanner
{
	public partial class HistoryDetailsPage : ContentPage
	{
		private HistoryDetailPageViewModel _detail;

		public HistoryDetailsPage(RealmDB.ScanResult Info)
		{
			// link up the data to the HistoryDetails page
			_detail = new HistoryDetailPageViewModel(Info);
			this.BindingContext = new HistoryDetailPageViewModel(Info);
			InitializeComponent();
		}

		public void BackClicked(object sender, EventArgs e) {
			Navigation.PopModalAsync();
		}
	}
}

