using System;
using System.Collections.Generic; 
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Z.EntityFrameworkExtras.Lab.EFCore9
{ 
	class My
	{
		public static string DataBaseName = "LabExtra";
		  
		public static string ConnectionString =
			("Server=[REPLACE];Initial Catalog = [BD]; Integrated Security = true; Connection Timeout = 300; Persist Security Info=True;TrustServerCertificate=True;").Replace("[REPLACE]", Environment.MachineName).Replace("[BD]", DataBaseName);
		public static string ConnectionStringTimeOut =
			("Server=[REPLACE];Initial Catalog = [BD]; Integrated Security = true; Connection Timeout = 5; Persist Security Info=True;TrustServerCertificate=True;").Replace("[REPLACE]", Environment.MachineName).Replace("[BD]", DataBaseName);

		public static void DeleteBD(DbContext context)
		{
			context.Database.EnsureDeleted();
		}

		public static void CreateBD(DbContext context)
		{
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
		}
	}
} 
