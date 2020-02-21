using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z.EntityFrameworkExtras.labEF6
{ 
	class My
	{
		public static string DataBaseName = "LabExtra";
		  
		public static string ConnectionString =
			("Server=[REPLACE];Initial Catalog = [BD]; Integrated Security = true; Connection Timeout = 300; Persist Security Info=True").Replace("[REPLACE]", Environment.MachineName).Replace("[BD]", DataBaseName);

		public static void DeleteBD(DbContext context)
		{
			context.Database.Delete();
		}

		public static void CreateBD(DbContext context)
		{
			try
			{
				context.Database.CreateIfNotExists();
				if (!context.Database.CompatibleWithModel(throwIfNoMetadata: true))
				{
					throw new Exception("Delete and Create DataBase");
				}
			}
			catch
			{
				try
				{
					My.DeleteBD(context);
				}
				catch (Exception e)
				{
					using (var commande = new SqlCommand("ALTER DATABASE " + DataBaseName + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;DROP DATABASE " + DataBaseName + " ;", new SqlConnection(My.ConnectionString)))
					{
						commande.Connection.Open();
						commande.ExecuteNonQuery();
					}
				}
				context.Database.CreateIfNotExists();
			}
		}
	}
} 
