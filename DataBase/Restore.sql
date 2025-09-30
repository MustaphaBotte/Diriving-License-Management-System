RESTORE DATABASE DVLD
FROM DISK = 'D:\Course 19\DLMS(Teacher)\DataBase\XYiWYPRgRCmCQugVIzlw_DVLD.bak'
WITH MOVE 'DVLD' TO 'D:\System\Sql Server\MSSQL16.MSSQLSERVER1\MSSQL\DATA\DVLD.mdf',
     MOVE 'DVLD_log' TO 'D:\System\Sql Server\MSSQL16.MSSQLSERVER1\MSSQL\DATA\DVLD_log.ldf',
     REPLACE;
	 
	 

-- please change the connection string file in data access	 
-- and log to system using those info 
-- Username =Msaqer77
-- Pass     =1234
