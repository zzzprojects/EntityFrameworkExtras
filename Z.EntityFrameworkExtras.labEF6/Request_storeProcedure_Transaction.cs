using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using EntityFrameworkExtras.EF6;

namespace Z.EntityFrameworkExtras.labEF6
{
	class Request_storeProcedure_Transaction
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
				var connection = context.Database.Connection;
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

	@ParameterID INT 	,
	@ParameterInt INT = NULL OUTPUT 


AS
BEGIN 
update EntitySimples
Set ColumnInt = @ParameterID ;

Set @ParameterInt = @ParameterID +1 
END
						";
					commande.ExecuteNonQuery();
				}

				using (var commande = connection.CreateCommand())
				{
					commande.CommandText = @"    
CREATE PROCEDURE [dbo].[PROC_Get_EntitySimple2]

	@ParameterID INT 	,
	@ParameterInt INT = NULL OUTPUT 


AS
BEGIN 
update EntitySimples
Set ColumnInt = @ParameterID ;

Set @ParameterInt = @ParameterID +1 

select * from EntitySimples
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

				var transaction = context.Database.BeginTransaction();

				context.Database.ExecuteStoredProcedure(proc_Get_EntitySimple);

				transaction.Rollback();

				var list = context.EntitySimples.ToList();
			}

			// TEST  
			using (var context = new EntityContext())
			{
				var proc_Get_EntitySimple = new Proc_Get_EntitySimple2() { ParameterID = 2 };

				using (var tran = new TransactionScope())
				{
					context.Database.ExecuteStoredProcedure<EntitySimple>(proc_Get_EntitySimple);
				}

				var transaction = context.Database.BeginTransaction();

				context.Database.ExecuteStoredProcedure<EntitySimple>(proc_Get_EntitySimple);

				transaction.Rollback();

				var list = context.EntitySimples.ToList();
			}

			using (var context = new EntityContext())
			{
				var proc_Get_EntitySimple = new Proc_Get_EntitySimple() { ParameterID = 2 };

				context.Database.ExecuteStoredProcedure(proc_Get_EntitySimple);

				var list = context.EntitySimples.ToList();
			}
		}

		public class EntityContext : DbContext
		{
			public EntityContext() : base(My.ConnectionString)
			{
			}

			public DbSet<EntitySimple> EntitySimples { get; set; }

			protected override void OnModelCreating(DbModelBuilder modelBuilder)
			{
				base.OnModelCreating(modelBuilder);
			}
		}

		[StoredProcedure("PROC_Get_EntitySimple")]
		public class Proc_Get_EntitySimple
		{
			[StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Output)]
			public int ParameterInt { get; set; }

			[StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Input)]
			public int ParameterID { get; set; }
		}

		[StoredProcedure("PROC_Get_EntitySimple2")]
		public class Proc_Get_EntitySimple2
		{
			[StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Output)]
			public int ParameterInt { get; set; }

			[StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Input)]
			public int ParameterID { get; set; }
		}

		public class EntitySimple
		{
			public int ID { get; set; }
			public int ColumnInt { get; set; }
			public String ColumnString { get; set; }
		}
	}
}