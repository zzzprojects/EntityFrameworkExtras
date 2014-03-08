using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NUnit.Framework;

namespace EntityFrameworkExtras.Tests.Integration
{
    public class DatabaseIntegrationTests
    {

        DbContext context;

        [SetUp]
        public void Setup()
        {
            context = new DbContext("ConnectionString");
        }
        public void ExecuteStoredProcedure(object storedProcedure)
        {
            context.Database.ExecuteStoredProcedure(storedProcedure);
        }

        public IEnumerable<T> ExecuteStoredProcedure<T>(object storedProcedure)
        {
            return context.Database.ExecuteStoredProcedure<T>(storedProcedure);
        }

        public T ExecuteStoredProcedureSingle<T>(object storedProcedure)
        {
            return context.Database.ExecuteStoredProcedure<T>(storedProcedure).FirstOrDefault();
        }
    }
}