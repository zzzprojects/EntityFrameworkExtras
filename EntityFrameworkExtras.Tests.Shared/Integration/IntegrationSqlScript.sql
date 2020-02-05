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
	@ParameterBinary BINARY(13) = NULL,
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
	    ParameterBinary BINARY(13) NULL,
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


CREATE PROCEDURE AllTypesParameterOutputStoredProcedure

	@ParameterNvarchar NVARCHAR(MAX) = NULL OUTPUT,
	@ParameterBigInt BIGINT = NULL OUTPUT,
	@ParameterBinary BINARY(13) = NULL OUTPUT,
	@ParameterBit BIT = NULL OUTPUT,
	@ParameterChar CHAR(10) = NULL OUTPUT,
	@ParameterDate DATE = NULL OUTPUT,
	@ParameterDateTime DATETIME = NULL OUTPUT,
	@ParameterDateTime2 DATETIME2 = NULL OUTPUT,
	@ParameterDateTimeOffset DATETIMEOFFSET = NULL OUTPUT,
	@ParameterDecimal DECIMAL = NULL OUTPUT,
	@ParameterFloat FLOAT = NULL OUTPUT,	
	@ParameterInt INT = NULL OUTPUT,
	@ParameterMoney MONEY = NULL OUTPUT,
	@ParameterNChar NCHAR(3) = NULL OUTPUT,
	@ParameterReal REAL = NULL OUTPUT,
	@ParameterSmallDateTime SMALLDATETIME = NULL OUTPUT,
	@ParameterSmallInt SMALLINT = NULL OUTPUT,
	@ParameterSmallMoney SMALLMONEY = NULL OUTPUT,
	@ParameterTime TIME = NULL OUTPUT,
	@ParameterTinyInt TINYINT = NULL OUTPUT,
	@ParameterUniqueIdentifier UNIQUEIDENTIFIER = NULL OUTPUT,
	@ParameterVarBinary VARBINARY(100) = NULL OUTPUT,
	@ParameterVarChar VARCHAR(100) = NULL OUTPUT,
	@ParameterXml XML = NULL OUTPUT


AS
BEGIN 

	SET @ParameterNvarchar = 'ParameterNvarcharValue'
	SET @ParameterBigInt = 111222333444
	SET @ParameterBinary = CAST('michael rodda' AS BINARY(13))
	SET @ParameterBit = 1
	SET @ParameterChar = CAST('abcdefghij' AS CHAR(10))
	SET @ParameterDate = CAST('20140603' AS DATE)
	SET @ParameterDateTime = CAST('1990-12-04 06:44:04' AS DATETIME)
	SET @ParameterDateTime2 = CAST('1968-10-23 12:45:37.123' AS DATETIME2)
	SET @ParameterDateTimeOffset = CAST('2007-05-08 12:35:29.123 +12:15' AS DATETIMEOFFSET)
	SET @ParameterDecimal = 555
	SET @ParameterFloat = 897
	SET @ParameterInt = 25
	SET @ParameterMoney = 1300
	SET @ParameterNChar = 'Cat'
	SET @ParameterReal = 6649
	SET @ParameterSmallDateTime = CAST('1995-03-15 12:01:00' AS SMALLDATETIME)
	SET @ParameterSmallInt = 9
	SET @ParameterSmallMoney = 200
	SET @ParameterTime = CAST('13:03:02' AS TIME)
	SET @ParameterTinyInt = 12
	SET @ParameterUniqueIdentifier = '692623c2-a71e-453f-98c6-432c67835ba4'
	SET @ParameterVarBinary = CAST('mike rodda' AS VARBINARY(10))
	SET @ParameterVarChar = 'Once upon a time'
	SET @ParameterXml = '<Some><Xml></Xml></Some>'


END
 

/***********************************/
/*	   UDT Direction Tests	       */
/***********************************/

GO

CREATE TYPE AllTypesUDT AS TABLE 
	(
		ParameterNvarchar NVARCHAR(MAX) NULL,
		ParameterBigInt BIGINT NULL,
	    ParameterBinary BINARY(13) NULL,
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

	DECLARE @ReturnValues TABLE 
	(
		ParameterNvarchar NVARCHAR(MAX) NULL,
		ParameterBigInt BIGINT NULL,
	    ParameterBinary BINARY(13) NULL,
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
	SELECT 	
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
	
	FROM @UserDefinedTableParameter

	SELECT * FROM @ReturnValues

END