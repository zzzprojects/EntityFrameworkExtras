USE [master]

-- Drop and Rebuild the database

IF EXISTS(select * from sys.databases where name='EntityFrameworkExtrasTests')
BEGIN

ALTER DATABASE EntityFrameworkExtrasTests SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE EntityFrameworkExtrasTests

END


GO
CREATE DATABASE EntityFrameworkExtrasTests

GO


USE [EntityFrameworkExtrasTests]
GO


/***********************************/
/*		General Tests			   */
/***********************************/

CREATE PROCEDURE NoParametersStoredProcedure

AS
BEGIN 
	SELECT 1;
END 

GO 



/***********************************/
/*		Parameter Tests			   */
/***********************************/


CREATE PROCEDURE AllTypesStoredProcedure

	@ParameterNvarchar NVARCHAR(MAX) = NULL,
	@ParameterBigInt BIGINT = NULL,
	@ParameterBinary BINARY(26) = NULL,
	@ParameterBit BIT = NULL,
	@ParameterChar CHAR(10) = NULL,
	@ParameterDate DATE = NULL,
	@ParameterDateTime DATETIME = NULL,
	@ParameterDateTime2 DATETIME2 = NULL,
	@ParameterDateTimeOffset DATETIMEOFFSET = NULL,
	@ParameterDecimal DECIMAL = NULL,
	@ParameterFloat FLOAT = NULL,
	@ParameterImage IMAGE = NULL,
	@ParameterInt INT = NULL,
	@ParameterMoney MONEY = NULL,
	@ParameterNChar NCHAR(10) = NULL,
	@ParameterNText NTEXT = NULL,
	@ParameterReal REAL = NULL,
	@ParameterSmallDateTime SMALLDATETIME = NULL,
	@ParameterSmallInt SMALLINT = NULL,
	@ParameterSmallMoney SMALLMONEY = NULL,
	@ParameterText TEXT = NULL,
	@ParameterTime TIME = NULL,
	@ParameterTimestamp TIMESTAMP = NULL,
	@ParameterTinyInt TINYINT = NULL,
	@ParameterUniqueIdentifier UNIQUEIDENTIFIER = NULL,
	@ParameterVarBinary VARBINARY(100) = NULL,
	@ParameterVarChar VARCHAR(100) = NULL,
	@ParameterXml XML = NULL


AS
BEGIN 

	DECLARE @ReturnValues TABLE 
	(
		ParameterNvarchar NVARCHAR(MAX) NULL,
		ParameterBigInt BIGINT NULL,
	    ParameterBinary BINARY(26) NULL,
	    ParameterBit BIT NULL,
	    ParameterChar CHAR(10) NULL,
	    ParameterDate DATE NULL,
		ParameterDateTime DATETIME NULL,
		ParameterDateTime2 DATETIME2 NULL,
		ParameterDateTimeOffset DATETIMEOFFSET NULL,
		ParameterDecimal DECIMAL NULL,
	    ParameterFloat FLOAT NULL,
		ParameterImage IMAGE NULL,
		ParameterInt INT NULL,
		ParameterMoney MONEY NULL,
		ParameterNChar NCHAR(10) NULL,
		ParameterNText NTEXT NULL,
		ParameterReal REAL NULL,
		ParameterSmallDateTime SMALLDATETIME NULL,
		ParameterSmallInt SMALLINT NULL,
		ParameterSmallMoney SMALLMONEY NULL,
		ParameterText TEXT NULL,
		ParameterTime TIME NULL,
		ParameterTinyInt TINYINT NULL,
		ParameterUniqueIdentifier UNIQUEIDENTIFIER NULL,
		ParameterVarBinary VARBINARY(100) NULL,
		ParameterVarChar VARCHAR(100) NULL,
		ParameterXml XML NULL
)	

	INSERT INTO 
	@ReturnValues (
		ParameterNvarchar,
		ParameterBigInt,
		ParameterBinary,
		ParameterBit,
		ParameterChar,
		ParameterDate,
		ParameterDateTime,
		ParameterDateTime2,
		ParameterDateTimeOffset,
		ParameterDecimal,
		ParameterFloat,
		ParameterImage,
		ParameterInt,
		ParameterMoney,
		ParameterNChar,
		ParameterNText,
		ParameterReal,
		ParameterSmallDateTime,
		ParameterSmallInt,
		ParameterSmallMoney,
		ParameterText,
		ParameterTime,
		ParameterTinyInt,
		ParameterUniqueIdentifier,
		ParameterVarBinary,
		ParameterVarChar,
		ParameterXml
	)
	VALUES
	(
		@ParameterNvarchar,
		@ParameterBigInt,
		@ParameterBinary,
		@ParameterBit,
		@ParameterChar,
		@ParameterDate,
		@ParameterDateTime,
		@ParameterDateTime2,
		@ParameterDateTimeOffset,
		@ParameterDecimal,
		@ParameterFloat,
		@ParameterImage,
		@ParameterInt,
		@ParameterMoney,
		@ParameterNChar,
		@ParameterNText,
		@ParameterReal,
		@ParameterSmallDateTime,
		@ParameterSmallInt,
		@ParameterSmallMoney,
		@ParameterText,
		@ParameterTime,
		@ParameterTinyInt,
		@ParameterUniqueIdentifier,
		@ParameterVarBinary,
		@ParameterVarChar,
		@ParameterXml
	)

	SELECT * FROM @ReturnValues;
END 


/***********************************/
/*	Parameter Direction Tests	   */
/***********************************/


GO

-- ParameterDirectionStoredProcedure
CREATE PROCEDURE ParameterDirectionStoredProcedure

	@ParameterDirectionDefault NVARCHAR(MAX) = NULL,
	@ParameterDirectionInput NVARCHAR(MAX) = NULL,
	@ParameterDirectionInputOutput NVARCHAR(MAX) = NULL OUTPUT,
	@ParameterDirectionOutput NVARCHAR(MAX) = NULL OUTPUT,
	@ParameterDirectionReturnValue NVARCHAR(MAX) = NULL OUTPUT 

AS
BEGIN 

	DECLARE @ReturnValues TABLE
	(
	    ParameterDirectionDefault NVARCHAR(MAX)  NULL,
		ParameterDirectionInput NVARCHAR(MAX)  NULL,
	    ParameterDirectionInputOutput NVARCHAR(MAX)  NULL,
		ParameterDirectionOutput NVARCHAR(MAX) NULL,
		ParameterDirectionReturnValue NVARCHAR(MAX)  NULL
	)
	
	INSERT @ReturnValues(
			ParameterDirectionDefault,
			ParameterDirectionInput,
		    ParameterDirectionInputOutput,
			ParameterDirectionOutput,
		    ParameterDirectionReturnValue
	)
	VALUES (
		@ParameterDirectionDefault,
		@ParameterDirectionInput,
		@ParameterDirectionInputOutput,
		@ParameterDirectionOutput,
		@ParameterDirectionReturnValue
	)

	
	SELECT * FROM @ReturnValues

	 
	
	-- Attempt to set all parameters for tests
	SET @ParameterDirectionDefault = 'DirectionDefaultValue'
	SET @ParameterDirectionInputOutput = 'DirectionInputOutputValue'
	SET @ParameterDirectionInput = 'DirectionInputValue'
	SET @ParameterDirectionOutput = 'DirectionOutputValue'	
	SET @ParameterDirectionReturnValue = 'DirectionReturnValue'
	
END 

GO

/***********************************/
/*	Parameter Size Tests    	   */
/***********************************/


CREATE PROCEDURE ParameterSizeStoredProcedure

	@ParameterSizeNotSet NVARCHAR(10) = NULL,
	@ParameterSizeSetTo5 NVARCHAR(10) = NULL,
	@ParameterSizeSetTo10 NVARCHAR(10) = NULL,
	@ParameterSizeSetTo20 NVARCHAR(10) = NULL

AS
BEGIN 

	
	DECLARE @ReturnValues TABLE
	(
	    ParameterSizeNotSet NVARCHAR(10) NULL,	
	    ParameterSizeSetTo5 NVARCHAR(10) NULL,
	    ParameterSizeSetTo10 NVARCHAR(10) NULL,
	    ParameterSizeSetTo20 NVARCHAR(10) NULL
	)
	
	INSERT @ReturnValues(
		ParameterSizeNotSet,
		ParameterSizeSetTo5,
		ParameterSizeSetTo10,
		ParameterSizeSetTo20	
	)
	VALUES (
		@ParameterSizeNotSet,
		@ParameterSizeSetTo5,
		@ParameterSizeSetTo10,
		@ParameterSizeSetTo20
	)

	
	SELECT * FROM @ReturnValues


END

GO



/***********************************/
/*	   UDT Direction Tests	       */
/***********************************/

CREATE TYPE AllTypesUDT AS TABLE 
	(
		ParameterNvarchar NVARCHAR(MAX) NULL,
		ParameterBigInt BIGINT NULL,
	    ParameterBinary BINARY(26) NULL,
	    ParameterBit BIT NULL,
	    ParameterChar CHAR(10) NULL,
	    ParameterDate DATE NULL,
		ParameterDateTime DATETIME NULL,
		ParameterDateTime2 DATETIME2 NULL,
		ParameterDateTimeOffset DATETIMEOFFSET NULL,
		ParameterDecimal DECIMAL NULL,
	    ParameterFloat FLOAT NULL,
		ParameterImage IMAGE NULL,
		ParameterInt INT NULL,
		ParameterMoney MONEY NULL,
		ParameterNChar NCHAR(10) NULL,
		ParameterNText NTEXT NULL,
		ParameterReal REAL NULL,
		ParameterSmallDateTime SMALLDATETIME NULL,
		ParameterSmallInt SMALLINT NULL,
		ParameterSmallMoney SMALLMONEY NULL,
		ParameterText TEXT NULL,
		ParameterTime TIME NULL,
		ParameterTinyInt TINYINT NULL,
		ParameterUniqueIdentifier UNIQUEIDENTIFIER NULL,
		ParameterVarBinary VARBINARY(100) NULL,
		ParameterVarChar VARCHAR(100) NULL,
		ParameterXml XML NULL
)	

GO

CREATE PROCEDURE UserDefinedTableStoredProcedure 

	@UserDefinedTableParameter AllTypesUDT READONLY

AS
BEGIN

	SELECT * FROM @UserDefinedTableParameter

END