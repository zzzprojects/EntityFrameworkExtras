EntityFrameworkExtras Nuget Package
===================================

The Nuget package for EntityFrameworkExtras is located at: http://www.nuget.org/packages/EntityFrameworkExtras/

## 1.2.1 (also EF5 1.0.0 and EF6 1.0.0)

- A major overhaul of the structure of the project. The changes are to deal with the changes in different versions of EntityFramework.
- There are now versions of the project for EF1-EF4.3.1, EF5 and EF6+ (these are for the nuget packages, including net40 & net45 versions)
- I'll be looking to restructure the code into a core project and specific items for each of the changes for the different EntityFramework projects to avoid repeated code


## 1.2.0

- Fixed "String[1]: the Size property has an invalid size of 0." exception on output parameters. The Size parameter on StoredProcedureParameterAttribute is defaulted to -1 if the parameter is an output parameter and the size is 0, this is the equivalent to MAX.