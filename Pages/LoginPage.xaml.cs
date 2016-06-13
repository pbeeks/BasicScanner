using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BasicScanner
{
	public partial class LoginPage : ContentPage
	{
		private LoginPageViewModel _loginPageVM;
		public LoginPage()
		{
			this.BindingContext = _loginPageVM;
			InitializeComponent();
		}

		public void LoginClicked(object sender, EventArgs e) {
			_loginPageVM = new LoginPageViewModel();
			string username = usernameBox.Text;
			string password = passwordBox.Text;
			_loginPageVM.Login(username, password);
		}
	}
}

