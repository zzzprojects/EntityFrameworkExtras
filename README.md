### Library Powered By

This library is powered by [Entity Framework Extensions](https://entityframework-extensions.net/?z=github&y=entityframeworkextras-plus)

<a href="https://entityframework-extensions.net/?z=github&y=entityframeworkextras">
<kbd>
<img src="https://zzzprojects.github.io/images/logo/entityframework-extensions-pub.jpg" alt="Entity Framework Extensions" />
</kbd>
</a>

---

What's EntityFrameworkExtras?
=====================

EntityFrameworkExtras provides some useful additions to EntityFramework, such as executing Stored Procedures with User-Defined Table Types and Output Parameters.

### Executing a Stored Procedure with a User Defined Table Type

* Define a stored procedure class

~~~ csharp
[StoredProcedure("storedproc_AddMemberWithAddresses")]
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

~~~ csharp
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

~~~ csharp
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



### Executing a Stored Procedure with an Output parameter

* To add an Output parameter, you need to set the Direction parameter to ParameterDirection.Output. 

~~~ csharp
[StoredProcedure("storedProc_GetOldestAge")]
public class GetOldestAgeStoredProcedure
{
	[StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Output)]
	public int Age { get; set; }
}
~~~

* Execute the Stored Procedure, and the parameter will be set to the output parameter value

~~~ csharp
var proc = new GetOldestAgeStoredProcedure();

context.Database.ExecuteStoredProcedure(proc);

int age = proc.Age; //Is now the oldest age
~~~

## Useful links

- [Website](https://entityframework-extras.net/overview)
- [Download](https://entityframework-extras.net/download)
- [NuGet Entity Framework Core](https://www.nuget.org/packages/EntityFrameworkExtras.EFCore/)
- [Nuget Entity Framework 6](https://www.nuget.org/packages/EntityFrameworkExtras.EF6/)
- [Nuget Entity Framework 5](https://www.nuget.org/packages/EntityFrameworkExtras.EF5/)
- [Nuget Entity Framework 4](https://www.nuget.org/packages/EntityFrameworkExtras/)

## Contribute

The best way to contribute is by **spreading the word** about the library:

 - Blog it
 - Comment it
 - Star it
 - Share it
 
A **HUGE THANKS** for your help.

## More Projects

- Projects:
   - [EntityFramework Extensions](https://entityframework-extensions.net/)
   - [Dapper Plus](https://dapper-plus.net/)
   - [C# Eval Expression](https://eval-expression.net/)
- Learn Websites
   - [Learn EF Core](https://www.learnentityframeworkcore.com/)
   - [Learn Dapper](https://www.learndapper.com/)
- Online Tools:
   - [.NET Fiddle](https://dotnetfiddle.net/)
   - [SQL Fiddle](https://sqlfiddle.com/)
   - [ZZZ Code AI](https://zzzcode.ai/)
- and much more!

To view all our free and paid projects, visit our website [ZZZ Projects](https://zzzprojects.com/).
