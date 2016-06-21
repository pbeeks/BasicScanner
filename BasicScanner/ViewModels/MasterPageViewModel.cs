using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Realms;
using Xamarin.Forms;

namespace BasicScanner
{
	public class MasterPageViewModel : ContentPage
	{
		private Realm _realm;
		private RealmDB.User currUser;
		private INavigation _nav;

		public MasterPageViewModel(RealmDB.User user, INavigation navigation)
		{
			_nav = navigation;
			currUser = user;
			_realm = Realm.GetInstance();
		}


	//	// Method for what heppens when the scan button is clicked 
		// Scans the barcode, prompts a message, and adds it to the database
		public Command _scanCommand;
		public ICommand ScanCommand
		{
			get
			{
				if (_scanCommand == null)
				{
					_scanCommand = new Command(async () => await RunScan());
				}
				return _scanCommand;
			}
		}

		// Method to actually scan the barcode
		async Task RunScan()
		{
			// TODO custom overlay to match spec
			//ZXingDefaultOverlay overlay = new ZXingDefaultOverlay
			//{
			//	TopText = "Hold your phone up to the barcode",
			//	BottomText= "Scanning will happen automatically"
			//};

//#if __ANDROID__
//   			 // Initialize the scanner first so it can track the current context
//   			 MobileBarcodeScanner.Initialize (Application);
//#endif

			var scanner = new ZXing.Mobile.MobileBarcodeScanner();
			var result = await scanner.Scan();

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
						newScan.Owner = currUser;
						newScan.Content = result.Text;
					});
				}
			}
		}
	}
}


