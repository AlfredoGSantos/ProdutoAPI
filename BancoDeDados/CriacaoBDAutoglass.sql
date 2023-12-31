USE master
GO

CREATE DATABASE Autoglass
ON PRIMARY
(
	NAME = 'DB_Autoglass',
	FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DB_Autoglass.mdf',
	SIZE = 5MB,
	FILEGROWTH = 1MB
),
FILEGROUP FG_Dados
(
	NAME = 'DB_Autoglass_Dados',
	FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DB_Autoglass_Dados.ndf',
	SIZE = 5MB,
	FILEGROWTH = 5MB
),
FILEGROUP FG_Log
(
	NAME = 'DB_Autoglass_Log',
	FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DB_Autoglass_Log.ndf',
	SIZE = 5MB,
	FILEGROWTH = 5MB
)
LOG ON
(
	NAME = 'Log_Autoglass',
	FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Log_Autoglass.ldf',
	SIZE = 5MB,
	FILEGROWTH = 5MB
)
COLLATE Latin1_General_CI_AI
GO

-- Modificação do Recovery Model
ALTER DATABASE Autoglass SET RECOVERY SIMPLE
GO

-- Criação do login para o banco de dados
CREATE LOGIN Autoglass_Admin
WITH PASSWORD = 'Aut0gl@a5s_Adm1n.',
DEFAULT_DATABASE = Autoglass,
CHECK_EXPIRATION = OFF,
CHECK_POLICY = OFF

USE Autoglass
GO

-- Cria usuário para o login criado
CREATE USER Autoglass_Admin
FOR LOGIN Autoglass_Admin
GO

-- Incluio o usuário do banco da regra de dono do banco
SP_ADDROLEMEMBER @RoleName = 'db_owner', @MemberName = 'Autoglass_Admin'
GO