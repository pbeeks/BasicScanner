using System;
using Acr.UserDialogs;
using Realms;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace BasicScanner
{
	public class MasterDetailPageViewModel : ContentPage
	{

		private Realm _realm;
		private RealmDB.User currUser;
		private INavigation navigation;

		public MasterDetailPageViewModel(RealmDB.User user, INavigation navigation)
		{
			
			currUser = user;
			_realm = Realm.GetInstance();
		}


		// Method for what heppens when the scan button is clicked 
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

		async Task RunScan()
		{
			// TODO custom overlay to match spec
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
						newScan.Content = "This is what I scanned";
					});
				}
			}
		}


		public Command _historyCommand;
		public ICommand HistoryCommand
		{
			get
			{
				if (_historyCommand == null)
				{
					_historyCommand = new Command(async () => await HistoryTask());
				}
				return _historyCommand;
			}
		}

		async Task HistoryTask()
		{
			await navigation.PushAsync(new HistoryPage(currUser)
			{
				Title = "History"
			});
		}

		public Command _logoutCommand;
		public ICommand LogoutCommand
		{
			get
			{
				if (_logoutCommand == null)
				{
					_logoutCommand = new Command(async () => await LogoutTask());
				}
				return _logoutCommand;
			}
		}


		async Task LogoutTask()
		{
			bool result = await UserDialogs.Instance.ConfirmAsync("Are you sure you want to log out?", "Log out", "Yes", "No");
			if (result == true)
			{
				App.Current.MainPage = new LoginPage();
			}


		}
	}
}

