using System;
using Realms;
using System.ServiceModel.Security;

namespace BasicScanner
{
	public class RealmDB
	{
		public RealmDB()
		{
		}

		public class User : RealmObject { 

			[ObjectId]
			public string username { get; set; }

			public string password { get; set; }
		
		}
	}
}

