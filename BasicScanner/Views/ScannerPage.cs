﻿using System;
using ZXing.Net.Mobile.Forms;
using Xamarin.Forms;
using Realms;
using Acr.UserDialogs;
using ZXing;

namespace BasicScanner
{
	public class ScannerPage : ContentPage
	{
		ZXingScannerView zxing;
		ZXingDefaultOverlay overlay;
		private INavigation _nav;
		private Realm _realm;
		private RealmDB.User _currUser;

	     public ScannerPage(INavigation nav)
		{
			_realm = Realm.GetInstance();
			_currUser = App.pubUser;
			_nav = nav;
			Title = "Scan";
			zxing = new ZXingScannerView()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			zxing.OnScanResult += (result) =>
			   Device.BeginInvokeOnMainThread(async () =>
			  {
				   // Stop analysis until we navigate away so we don't keep reading barcodes
				   zxing.IsAnalyzing = false;
				  zxing.IsScanning = false;
			#if __ANDROID__
   			 // Initialize the scanner first so it can track the current context
   			 MobileBarcodeScanner.Initialize (Application);
			#endif

				   if (result != null)
				  {
					  var answer = await UserDialogs.Instance.ConfirmAsync("Would you like to track this barcode?", "Barcode found!", "Yes", "No");
					  if (answer == true)
					  {
						  string[] timeArray = DateTime.Now.ToString().Split(null);
						  _realm.Write(() =>
						  {
							  var newScan = _realm.CreateObject<RealmDB.ScanResult>();
							  newScan.Date = timeArray[0];
							  newScan.Time = timeArray[1] + " " + timeArray[2];
							  newScan.Format = result.BarcodeFormat.ToString();
							  newScan.Owner = _currUser;
							  newScan.Content = result.Text;
						  });
					  }
				  }
				  await _nav.PopAsync();
			  });

			overlay = new ZXingDefaultOverlay
			{
				TopText = "Hold your phone up to the barcode",
				BottomText = "Scanning will happen automatically",
			};

			var grid = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			grid.Children.Add(zxing);
			grid.Children.Add(overlay);

			// The root page of your application
			Content = grid;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			zxing.IsScanning = true;
		}

		protected override void OnDisappearing()
		{
			zxing.IsScanning = false;

			base.OnDisappearing();
		}

	}
}