EntityFrameworkExtras Nuget Package
===================================

The Nuget package for EntityFrameworkExtras is located at: http://www.nuget.org/packages/EntityFrameworkExtras/


## 1.2.0

- Fixed "String[1]: the Size property has an invalid size of 0." exception on output parameters. The Size parameter on StoredProcedureParameterAttribute is defaulted to -1 if the parameter is an output parameter and the size is 0, this is the equivalent to MAX.