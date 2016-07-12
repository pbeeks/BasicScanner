using System;
using Xamarin.Forms;
using SQLite.Net.Attributes;

namespace BasicScanner
{
	public class Tables
	{

		[Table("UserTable")]

		public class UserTable
		{
			[PrimaryKey, AutoIncrement, Column("_id")]
			public int ID { get; set; }

			public string username { get; set; }

			public string password { get; set; }

		}

		[Table("ScanResultTable")]

		public class ScanResultTable
		{

			public string Date { get; set; }

			public string Time { get; set; }

			public UserTable Owner { get; set; }

			public string Format { get; set; }

			public string Content { get; set; }

		}
	}
}

