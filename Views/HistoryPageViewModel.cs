using System;
using System.Collections.Generic;
using Realms;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace BasicScanner
{
	public class HistoryPageViewModel : ContentPage
	{
		public IEnumerable<RealmDB.ScanResult> ScanList { get; set; }
		private Realm _realm;
		public INavigation Navigation { get; set; }

		public HistoryPageViewModel()
		{
			_realm = Realm.GetInstance();
			ScanList = _realm.All<RealmDB.ScanResult>();
		}
	}
}


