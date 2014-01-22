EntityFrameworkExtras
=====================

EntityFrameworkExtras provides some useful additions to EntityFramework such as executing Stored Procedures with User-Defined Table Types and Output Parameters.



###Executing a Stored Procedure with a User Defined Table Type###


* Define a stored procedure class

~~~
[StoredProcedure("sp_AddMemberWithAddresses")]
public class AddMemberStoredWithAddressesProcedure
{
  [StoredProcedureParameter(SqlDbType.NVarChar, ParameterName = "ForeName")]
	public string FirstName { get; set; }

	[StoredProcedureParameter(SqlDbType.NVarChar,ParameterName = "SurName")]
	public string LastName { get; set; }

	[StoredProcedureParameter(SqlDbType.Int)]
	public int Age { get; set; }

	[StoredProcedureParameter(SqlDbType.Udt)]
	public List<Address> Addresses { get; set; }
}
~~~


* A User Defined Table Type parameter is declared as a List<> (List<Address>). The UDT will also require some attributes:

~~~
[UserDefinedTableType("udt_Address")]
public class Address
{
	[UserDefinedTableTypeColumn(1)]
	public string Line1 { get; set; }

	[UserDefinedTableTypeColumn(2)]
	public string Line2 { get; set; }

	[UserDefinedTableTypeColumn(3)]
	public string Postcode { get; set; }
}
~~~

* Execute the Stored Procedure with either a DbContext or an ObjectContext

~~~
DbContext context = new DbContext("ConnectionString");

var proc = new AddMemberStoredWithAddressesProcedure()
	{
		FirstName = "Michael",
		LastName = "Bovis",
		Age = 26,
		Addresses = new List<Address>()
		{
			new Address() {Line1 = "16", Line2 = "The Lane", Postcode = "MA24WE"}
		}
	};

context.Database.ExecuteStoredProcedure(proc);
~~~



###Executing a Stored Procedure with a Output parameter###

* To add an Output parameter you just need to set the Direction parameter to ParameterDirection.Output. 

~~~
[StoredProcedure("sp_GetOldestAge")]
public class GetOldestAgeStoredProcedure
{
	[StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Output)]
	public int Age { get; set; }
}
~~~

* Execute the Stored Procedure and the parameter will be set to the output parameter value

~~~
var proc = new GetOldestAgeStoredProcedure();

context.Database.ExecuteStoredProcedure(proc);

int age = proc.Age; //Is now the oldest age
~~~


###Thanks to the contributors!###

* https://github.com/JoeBrockhaus - Joe
* https://github.com/thomasvanderhoofWork - Thomas


