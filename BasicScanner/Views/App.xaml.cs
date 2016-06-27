﻿using Xamarin.Forms;

namespace BasicScanner
{
	public partial class App : Application
	{
		public RealmDB.User goob { get; set; }

		public App()
		{
			InitializeComponent();
			MainPage = new LoginPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

