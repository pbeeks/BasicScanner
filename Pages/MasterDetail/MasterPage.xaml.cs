﻿using System;
using System.Collections.Generic;
using Realms;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using System.Dynamic;

namespace BasicScanner
{
	public partial class MasterPage : ContentPage
	{
		private Realm _realm;
		private RealmDB.User currUser;
		public MasterPage(RealmDB.User user)
		{
			currUser = user;
			InitializeComponent();
			_realm = Realm.GetInstance();
		}

		async public void ScanClicked(object sender, EventArgs e)
		{
			//ZXingDefaultOverlay overlay = new ZXingDefaultOverlay
			//{
			//	TopText = "Hold your phone up to the barcode",
			//	BottomText= "Scanning will happen automatically"
			//};

#if __ANDROID__
   			 // Initialize the scanner first so it can track the current context
   			 MobileBarcodeScanner.Initialize (Application);
#endif

			var scanner = new ZXing.Mobile.MobileBarcodeScanner();
			//scanner.UseCustomOverlay = true;
			//scanner.CustomOverlay = overlay;
			var result = await scanner.Scan();

			if (result != null)
			{
				string[] timeArray = DateTime.Now.ToString().Split(null);
				_realm.Write(() =>
				{
					var newScan = _realm.CreateObject<RealmDB.ScanResult>();
					newScan.Date = timeArray[0];
					newScan.Time = timeArray[1] + " " + timeArray[2];
					newScan.Format = result.BarcodeFormat.ToString();
					newScan.Owner = currUser;
					newScan.Content = "This is what I scanned";
				});
			}
		}
	}
}

