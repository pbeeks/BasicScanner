using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Xamarin.Forms;
using Realms;
using ZXing.Net.Mobile.Forms;

namespace BasicScanner
{
	public class HistoryDetailPageViewModel 
	{

		private INavigation _nav;
		private Realm _realm;
		public RealmDB.ScanResult HistoryData { get; set; }
		ZXingBarcodeImageView barcode;

		public HistoryDetailPageViewModel(RealmDB.ScanResult Info)
		{
			_realm = Realm.GetInstance();
			HistoryData = Info;
		}

		public ZXingBarcodeImageView GetBarcode() {
			barcode = new ZXingBarcodeImageView
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
			};

			// barcode.BarcodeFormat = ZXing.BarcodeFormat.;
			barcode.BarcodeOptions.Width = 100;
			barcode.BarcodeOptions.Height = 100;
			barcode.BarcodeOptions.Margin = 10;
			barcode.BarcodeValue = "Generated barcode";

			return barcode;
		}
	}
}

