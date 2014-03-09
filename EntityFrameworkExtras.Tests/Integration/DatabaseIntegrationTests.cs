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


        //helper methods
        public byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}