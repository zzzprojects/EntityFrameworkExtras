using EntityFrameworkExtras.EF6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z.EntityFrameworkExtras.labEF6
{
	class Request_OutputParam
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
	@ParameterDouble decimal(5,4) 	,
	@ParameterInt INT = NULL OUTPUT ,
	@ParameterDoubleOutput decimal(5,4)  = NULL OUTPUT


AS
BEGIN 

update entitySimples 
set ColumnDouble = @ParameterDouble

Select * from EntitySimples
Where ColumnInt = @ParameterID
Set @ParameterInt = @ParameterID +1 

set @ParameterDoubleOutput = @ParameterDouble + 1
END
						";
					commande.ExecuteNonQuery();
				}

			}

			// TEST  
			using (var context = new EntityContext())
			{
				try
				{

					var proc_Get_EntitySimple = new Proc_Get_EntitySimple() { ParameterID = 2, ParameterDouble = new decimal(35.809192) };
					var entity = context.Database.ExecuteStoredProcedureFirstOrDefault<EntitySimple>(proc_Get_EntitySimple);
					var output = proc_Get_EntitySimple.ParameterInt;
				}
				catch (Exception e)
				{
					{

						var proc_Get_EntitySimple = new Proc_Get_EntitySimple() { ParameterID = 2, ParameterDouble = new decimal(5.8001) };
						var entity = context.Database.ExecuteStoredProcedureFirstOrDefault<EntitySimple>(proc_Get_EntitySimple);
						var output = proc_Get_EntitySimple.ParameterInt;
						var output2 = proc_Get_EntitySimple.ParameterDoubleOutput;
					}
					//{


					//	var proc_Get_EntitySimple = new Proc_Get_EntitySimple() { ParameterID = 2  };
					//	var entity = context.Database.ExecuteStoredProcedureFirstOrDefault<EntitySimple>(proc_Get_EntitySimple);
					//	var output = proc_Get_EntitySimple.ParameterInt;
					//}

				}

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
				modelBuilder.Entity<EntitySimple>().Property(x => x.ColumnDouble).HasPrecision(5, 4);

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
			
			[StoredProcedureParameter(SqlDbType.Decimal, Direction = ParameterDirection.Input, Precision = 5, Scale = 4)]
			public decimal? ParameterDouble { get; set; }

			[StoredProcedureParameter(SqlDbType.Decimal, Direction = ParameterDirection.Output, Precision = 5, Scale = 4)]
			public decimal? ParameterDoubleOutput { get; set; }
		}

		public class EntitySimple
		{
			public int ID { get; set; }
			public int ColumnInt { get; set; } 
			public decimal ColumnDouble { get; set; }
			public String ColumnString { get; set; }
		}
	}
}