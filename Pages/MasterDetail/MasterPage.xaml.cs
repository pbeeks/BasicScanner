using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace BasicScanner
{
	public partial class MasterPage : ContentPage
	{
		public MasterPage(RealmDB.User user)
		{
			InitializeComponent();
		}

		async public void ScanClicked(object sender, EventArgs e)
		{
			ZXingDefaultOverlay overlay = new ZXingDefaultOverlay
			{
				TopText = "Hold your phone up to the barcode",
				BottomText= "Scanning will happen automatically"
			};

#if __ANDROID__
   			 // Initialize the scanner first so it can track the current context
   			 MobileBarcodeScanner.Initialize (Application);
#endif

			var scanner = new ZXing.Mobile.MobileBarcodeScanner();
			scanner.UseCustomOverlay = true;
			scanner.CustomOverlay = overlay;
			var result = await scanner.Scan();

			if (result != null)
			{
				// TODO 
				// Console.WriteLine("Scanned Barcode: " + result.Text);
			}
		}
	}
}

