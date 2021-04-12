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

Want to help us? Your donation directly helps us maintain and grow ZZZ Free Projects. 

We can't thank you enough for your support 🙏.

👍 [One-time donation](https://zzzprojects.com/contribute)

❤️ [Become a sponsor](https://github.com/sponsors/zzzprojects) 

### Why should I contribute to this free & open-source library?
We all love free and open-source libraries! But there is a catch... nothing is free in this world.

We NEED your help. Last year alone, we spent over **3000 hours** maintaining all our open source libraries.

Contributions allow us to spend more of our time on: Bug Fix, Development, Documentation, and Support.

### How much should I contribute?
Any amount is much appreciated. All our free libraries together have more than **100 million** downloads.

If everyone could contribute a tiny amount, it would help us make the .NET community a better place to code!

Another great free way to contribute is  **spreading the word** about the library.

A **HUGE THANKS** for your help!

## More Projects

- [EntityFramework Extensions](https://entityframework-extensions.net/)
- [Dapper Plus](https://dapper-plus.net/)
- [C# Eval Expression](https://eval-expression.net/)
- and much more! 

To view all our free and paid projects, visit our [website](https://zzzprojects.com/).
