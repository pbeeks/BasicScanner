using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Xamarin.Forms;
using Realms;

namespace BasicScanner
{
	public class HistoryDetailPageViewModel 
	{

		private INavigation _nav;
		private Realm _realm;
		public RealmDB.ScanResult HistoryData { get; set; }

		public HistoryDetailPageViewModel(INavigation iNav)
		{
			_nav = iNav;
			_realm = Realm.GetInstance();
			HistoryData = 
		}
	}
}

