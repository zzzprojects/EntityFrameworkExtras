using System;
using System.Collections.Generic;
using System.Data; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using EntityFrameworkExtras.EFCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Z.EntityFrameworkExtras.Lab.EFCore9
{
	class Request_storeProcedure_DateTimeOnly
	{
		public static void Execute()
		{
			// Create BD 
			using (var context = new EntityContext())
			{
				My.CreateBD(context);
			}

			// CLEAN  
			using (var context = new EntityContext())
			{
				context.EntitySimples.RemoveRange(context.EntitySimples);

				context.SaveChanges();
			}

			// SEED  
			using (var context = new EntityContext())
			{
				for (int i = 0; i < 3; i++)
				{
					context.EntitySimples.Add(new EntitySimple { ColumnInt = i });
				}

				context.SaveChanges();
			}



			// TEST  
			using (var context = new EntityContext())
			{
				var connection = context.Database.GetDbConnection();
				connection.Open();

				using (var commande = connection.CreateCommand())
				{
					commande.CommandText = @"   
if exists (select 1 from sys.procedures where name = 'PROC_Get_EntitySimple')
BEGIN
DROP PROCEDURE [dbo].[PROC_Get_EntitySimple]
END 
						";
					commande.ExecuteNonQuery();
				}

				using (var commande = connection.CreateCommand())
				{
					commande.CommandText = @"    
CREATE PROCEDURE [dbo].[PROC_Get_EntitySimple]
    @ParameterID INT,
    @DateOnly DATE OUTPUT,
    @TimeOnly TIME(7) OUTPUT
AS
BEGIN
    -- Example update; make sure this is what you want (no WHERE clause)
    UPDATE EntitySimples
    SET ColumnInt = @ParameterID;

    -- Set output values
    SET @DateOnly = CAST(GETDATE() AS DATE);
    SET @TimeOnly = CAST(GETDATE() AS TIME(7));
END

						";
					commande.ExecuteNonQuery();
				}
			}

			// TEST  
			using (var context = new EntityContext())
			{
				var proc_Get_EntitySimple = new Proc_Get_EntitySimple() { ParameterID = 2 };

				using (var tran = new TransactionScope())
				{
					context.Database.ExecuteStoredProcedure(proc_Get_EntitySimple);
				}

				var list2 = context.Database.ExecuteStoredProcedure<EntitySimple>(proc_Get_EntitySimple);
                
				context.Database.ExecuteStoredProcedure(proc_Get_EntitySimple);


				var list = context.EntitySimples.ToList();
			}		
		}

		public class EntityContext : DbContext
		{
			public EntityContext() : base( )
			{
			}

			public DbSet<EntitySimple> EntitySimples { get; set; }
			protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			{
				optionsBuilder.UseSqlServer(new SqlConnection(My.ConnectionString));

				base.OnConfiguring(optionsBuilder);
			}

		}

		[StoredProcedure("PROC_Get_EntitySimple")]
		public class Proc_Get_EntitySimple
		{
			//[StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Output)]
			//public int ParameterInt { get; set; }

			[StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Input)]
			public int ParameterID { get; set; }
            [StoredProcedureParameter(SqlDbType.Date, Direction = ParameterDirection.Output)]
            public DateOnly DateOnly { get; set; }
            [StoredProcedureParameter(SqlDbType.Time, Direction = ParameterDirection.Output)]
            public TimeOnly TimeOnly { get; set; }
        }

		public class EntitySimple
		{
			public int ID { get; set; }
			public int ColumnInt { get; set; }
			public String? ColumnString { get; set; }
		}
	}
}