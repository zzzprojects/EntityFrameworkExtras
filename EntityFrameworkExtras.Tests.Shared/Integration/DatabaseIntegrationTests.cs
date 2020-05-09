using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using NUnit.Framework;

#if EFCORE
using Microsoft.EntityFrameworkCore;
#else
using System.Data.Entity;
#endif

#if EF5
using EntityFrameworkExtras.EF5;
#elif EF6
using EntityFrameworkExtras.EF6;
#elif EFCORE
using EntityFrameworkExtras.EFCore;
#endif

namespace EntityFrameworkExtras.Tests.Integration
{
    public class DatabaseIntegrationTests
    {

        DbContext context;

        [SetUp]
        public void Setup()
        {
#if EFCORE
            var contextOptions = new DbContextOptionsBuilder<DbContext>();
            contextOptions.UseSqlServer(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            context = new DbContext(contextOptions.Options);
#else
            context = new DbContext("ConnectionString");
#endif
        }
        public void ExecuteStoredProcedure(object storedProcedure)
        {
            context.Database.ExecuteStoredProcedure(storedProcedure);
        }

        public IEnumerable<T> ExecuteStoredProcedure<T>(object storedProcedure) where  T : class
        {
            return context.Database.ExecuteStoredProcedure<T>(storedProcedure);
        }

        public T ExecuteStoredProcedureSingle<T>(object storedProcedure) where T : class
        {
            return context.Database.ExecuteStoredProcedure<T>(storedProcedure).FirstOrDefault();
        }


        //helper methods
        public byte[] GetBytes(string str)
        {
            return str.Select(e => (byte)e).ToArray();

//            byte[] bytes = new byte[str.Length * sizeof(char)];
//            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
//            return bytes;
        }
    }
}