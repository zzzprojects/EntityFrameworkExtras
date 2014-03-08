using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using EntityFrameworkExtras;

namespace EntityFrameworkExtras.Tests
{
    [TestClass]
    public class StoredProceduresTests
    {
        DbContext context;

        [TestInitialize]
        public void Init()
        {
            context = new DbContext("ConnectionString");
        }


        [TestMethod]
        public void Execute_Stored_Procedure_Without_Error()
        {
            var proc = new AddMemberStoredProcedure()
            {
                FirstName = "Michael",
                LastName = "Rodda",
                Age = 29
            };

            context.Database.ExecuteStoredProcedure(proc);

            Assert.AreEqual(1, 1); //no exception occured            
        }

        [StoredProcedure("sp_AddMember")]
        public class AddMemberStoredProcedure
        {
            [StoredProcedureParameter(SqlDbType.NVarChar)]
            public string FirstName { get; set; }

            [StoredProcedureParameter(SqlDbType.NVarChar)]
            public string LastName { get; set; }

            [StoredProcedureParameter(SqlDbType.Int)]
            public int Age { get; set; }
        }



        [TestMethod]
        public void Execute_Stored_Procedure_With_UDT_Without_Error()
        {
            var proc = new AddMemberStoredWithAddressesProcedure()
            {
                FirstName = "Craig",
                LastName = "Bovis",
                Age = 26,
                Addresses = new List<Address>()
                {
                    new Address() {Line1 = "16", AddressLine2 = "The Lane", Postcode = "MA24WE"},
                    new Address() {Line1 = "77", AddressLine2 = "Ache Lane", Postcode = "DFD44", IsPrimary =  true},
                }
            };

            context.Database.ExecuteStoredProcedure(proc);

            Assert.AreEqual(1, 1); //no exception occured            
        }

        [StoredProcedure("sp_AddMemberWithAddresses")]
        public class AddMemberStoredWithAddressesProcedure
        {
            [StoredProcedureParameter(SqlDbType.NVarChar, ParameterName = "FirstName")]
            public string FirstName { get; set; }

            [StoredProcedureParameter(SqlDbType.NVarChar)]
            public string LastName { get; set; }

            [StoredProcedureParameter(SqlDbType.Int)]
            public int Age { get; set; }

            [StoredProcedureParameter(SqlDbType.Udt)]
            public List<Address> Addresses { get; set; }
        }

        [UserDefinedTableType("udt_Address")]
        public class Address
        {
            [UserDefinedTableTypeColumn(1)]
            public string Line1 { get; set; }

            [UserDefinedTableTypeColumn(2, "Line2")]
            public string AddressLine2 { get; set; }

            [UserDefinedTableTypeColumn(3)]
            public string Postcode { get; set; }

            [UserDefinedTableTypeColumn(4, "IsPrimary")]
            public bool? IsPrimary { get; set; }

        }
        

        [TestMethod]
        public void Execute_Stored_Procedure_With_Output_Parameter_Without_Error()
        {
            var proc = new GetMemberAgesStoredProcedure();

            context.Database.ExecuteStoredProcedure(proc);

            Assert.AreEqual(29, proc.Age);  
        }

        [StoredProcedure("sp_GetOldestAge")]
        public class GetMemberAgesStoredProcedure
        {
            public string AnotherProperty { get; set; }

            public decimal? AdditionalValue { get; set; }

            [StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Output)]
            public int Age { get; set; }

        }


    }


}
