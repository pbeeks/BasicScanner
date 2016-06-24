using System;
using System.Collections.Generic;
using Realms;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using System.Dynamic;
using Acr.UserDialogs;

namespace BasicScanner
{
	public partial class MasterPage : ContentPage
	{
		public MasterPage(RealmDB.User user)
		{
			NavigationPage.SetBackButtonTitle(this, "Back");
			InitializeComponent();
			this.BindingContext = new MasterPageViewModel(user, this.Navigation);
		}


	}
}


