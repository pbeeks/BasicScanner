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
		public RealmDB.ScanResult HistoryData { get; set; }
		public ZXingBarcodeImageView Barcode { get; set;}

		public HistoryDetailPageViewModel(RealmDB.ScanResult Info)
		{
			HistoryData = Info;
			Barcode = GetBarcode();
		}


		// Method to generate the barcode image for the HistoryDetailsPage
		public ZXingBarcodeImageView GetBarcode() {
			ZXingBarcodeImageView barcode = new ZXingBarcodeImageView();

			// Switch statement for setting the barcode format
			string format = HistoryData.Format;
			switch (format) {
				case "All_1D":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.All_1D;
					break;
				case "AZTEC":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.AZTEC;
					break;
				case "CODABAR":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.CODABAR;
					break;
				case "CODE_128":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.CODE_128;
					break;
				case "CODE_39":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.CODE_39;
					break;
				case "CODE_93":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.CODE_93;
					break;
				case "DATA_MATRIX":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.DATA_MATRIX;
					break;
				case "EAN_13":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.EAN_13;
					break;
				case "EAN_8":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.EAN_8;
					break;
				case "IMB":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.IMB;
					break;
				case "ITF":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.ITF;
					break;
				case "MAXICODE":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.MAXICODE;
					break;
				case "MSI":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.MSI;
					break;
				case "PDF_417":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.PDF_417;
					break;
				case "PLESSEY":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.PLESSEY;
					break;
				case "QR_CODE":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
					break;
				case "RSS_14":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.RSS_14;
					break;
				case "RSS_EXPANDED":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.RSS_EXPANDED;
					break;
				case "UPC_A":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.UPC_A;
					break;
				case "UPC_E":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.UPC_E;
					break;
				case "UPC_EAN_EXTENSION":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.UPC_EAN_EXTENSION;
					break;
			}
			barcode.BarcodeOptions.Width = 100;
			barcode.BarcodeOptions.Height = 100;
			barcode.BarcodeOptions.Margin = 10;
			barcode.BarcodeValue = "Generated barcode";

			return barcode;
		}
	}
}

