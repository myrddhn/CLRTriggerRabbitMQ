use TriggerMQTest;
--use TestDB;

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [id]
      ,[queue]
      ,[message]
  FROM [dbo].[QueueData]

sp_configure 'clr enabled',1
GO
RECONFIGURE
GO

alter database testdb
SET TRUSTWORTHY ON;
go

DROP TRIGGER TR_TriggerMQTest
GO
drop assembly [CLR_Triggers]
GO
CREATE ASSEMBLY [CLR_Triggers] FROM
'C:\Andi\Assemblies\TriggerCLRMQConnector.dll' WITH PERMISSION_SET=UNSAFE
GO
CREATE TRIGGER TR_TriggerMQTest
ON dbo.QueueData
FOR INSERT, UPDATE, DELETE    
AS EXTERNAL NAME [CLR_Triggers].[CLRTriggers].QueueTrigger;
GO

drop assembly [System.Runtime.Serialization]

CREATE ASSEMBLY [System.Runtime.Serialization] FROM
'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\System.Runtime.Serialization.dll' WITH PERMISSION_SET=UNSAFE
GO

UPDATE QueueData SET message = 'Hello world, it''s not working yet!!!' WHERE "queue" = '/trigger/two'

select * from sys.dm_clr_properties