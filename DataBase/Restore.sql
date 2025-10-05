RESTORE DATABASE DVLD
FROM DISK = 'C:\yourpath\DLMS.bak'
WITH MOVE 'DVLD' TO 'C:\System\Sql Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DVLD.mdf',
     MOVE 'DVLD_log' TO 'C:\System\Sql Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DVLD_log.ldf',
     REPLACE;
	 
	 -- verify the path

-- please change the connection string file in data access	 
-- and log to system using those info 
-- Username =Msaqer77
-- Pass     =1234
