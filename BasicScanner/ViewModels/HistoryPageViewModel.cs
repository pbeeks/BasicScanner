using System;
using System.Collections.Generic;
using Realms;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using Acr.UserDialogs;

namespace BasicScanner
{
	public class HistoryPageViewModel
	{
		public IEnumerable<RealmDB.ScanResult> ScanList { get; set; }
		private Realm _realm;
		public INavigation Navigation { get; set; }
		private RealmDB.User _user;

		// Populates the HistoryPage listview
		public HistoryPageViewModel(INavigation iNav)
		{
			_user = App.pubUser;
			Navigation = iNav;
			_realm = Realm.GetInstance();


		}

		public void GetData()
		{
			string uName = _user.username;
			ScanList = _realm.All<RealmDB.ScanResult>().Where(u => u.Owner.username.Equals(uName));

		}
	}
}


