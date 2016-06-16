using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Realms;

namespace BasicScanner
{
	public partial class HistoryPage : ContentPage
	{
		public IEnumerable<RealmDB.ScanResult> ScanList { get; set; }

		public HistoryPage(RealmDB.User user)
		{
			InitializeComponent();
			BindingContext = new HistoryPageViewModel { Navigation = Navigation };
		}

		public void HistorySelected(object sender, SelectedItemChangedEventArgs e) {
			
			Navigation.PushModalAsync(new HistoryDetailsPage(e.SelectedItem as RealmDB.ScanResult));
		}
	}
}

