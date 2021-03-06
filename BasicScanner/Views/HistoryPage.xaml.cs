﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Realms;
using System.Linq;

namespace BasicScanner
{
	public partial class HistoryPage : ContentPage
	{
		public IEnumerable<RealmDB.ScanResult> ScanList { get; set; }
		private HistoryPageViewModel _histVM;

		public HistoryPage()
		{
			_histVM = new HistoryPageViewModel(this.Navigation);
			this.BindingContext = _histVM;
			_histVM.GetData();
			InitializeComponent();
		}

		public void HistorySelected(object sender, SelectedItemChangedEventArgs e) {
			
 			Navigation.PushModalAsync(new HistoryDetailsPage(e.SelectedItem as RealmDB.ScanResult));
		}
	}
}

