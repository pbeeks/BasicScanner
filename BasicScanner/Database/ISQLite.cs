using System;
using SQLite.Net;

namespace BasicScanner
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

