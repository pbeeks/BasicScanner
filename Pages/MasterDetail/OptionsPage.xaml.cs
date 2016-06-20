using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace BasicScanner
{
	public partial class OptionsPage : ContentPage
	{
		private RealmDB.User currUser;

		public OptionsPage(RealmDB.User user)
		{
			this.BindingContext = new OptionsPageViewModel(user, this.Navigation);
			InitializeComponent();
		}
	}
}

