-- DROP SCHEMA dbo;

CREATE SCHEMA dbo;
-- immob.dbo.Address definition

-- Drop table

-- DROP TABLE immob.dbo.Address;

CREATE TABLE immob.dbo.Address (
	Id uniqueidentifier NOT NULL,
	Street nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	City nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	State nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ZipCode nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Number nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_Address PRIMARY KEY (Id)
);


-- immob.dbo.Tenants definition

-- Drop table

-- DROP TABLE immob.dbo.Tenants;

CREATE TABLE immob.dbo.Tenants (
	Id uniqueidentifier NOT NULL,
	Name nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Email nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_Tenants PRIMARY KEY (Id)
);


-- immob.dbo.[__EFMigrationsHistory] definition

-- Drop table

-- DROP TABLE immob.dbo.[__EFMigrationsHistory];

CREATE TABLE immob.dbo.[__EFMigrationsHistory] (
	MigrationId nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ProductVersion nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY (MigrationId)
);


-- immob.dbo.Properties definition

-- Drop table

-- DROP TABLE immob.dbo.Properties;

CREATE TABLE immob.dbo.Properties (
	Id uniqueidentifier NOT NULL,
	AddressId uniqueidentifier NOT NULL,
	RentAmount decimal(18,2) NOT NULL,
	IsAvailable bit NOT NULL,
	TenantId uniqueidentifier NULL,
	CONSTRAINT PK_Properties PRIMARY KEY (Id),
	CONSTRAINT FK_Properties_Address_AddressId FOREIGN KEY (AddressId) REFERENCES immob.dbo.Address(Id) ON DELETE CASCADE,
	CONSTRAINT FK_Properties_Tenants_TenantId FOREIGN KEY (TenantId) REFERENCES immob.dbo.Tenants(Id)
);
 CREATE NONCLUSTERED INDEX IX_Properties_AddressId ON dbo.Properties (  AddressId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE NONCLUSTERED INDEX IX_Properties_TenantId ON dbo.Properties (  TenantId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- immob.dbo.Owners definition

-- Drop table

-- DROP TABLE immob.dbo.Owners;

CREATE TABLE immob.dbo.Owners (
	Id uniqueidentifier NOT NULL,
	Name nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Active bit NOT NULL,
	Email nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	PropertyId uniqueidentifier NULL,
	CONSTRAINT PK_Owners PRIMARY KEY (Id),
	CONSTRAINT FK_Owners_Properties_PropertyId FOREIGN KEY (PropertyId) REFERENCES immob.dbo.Properties(Id)
);
 CREATE NONCLUSTERED INDEX IX_Owners_PropertyId ON dbo.Owners (  PropertyId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- immob.dbo.PropertyOwners definition

-- Drop table

-- DROP TABLE immob.dbo.PropertyOwners;

CREATE TABLE immob.dbo.PropertyOwners (
	Id uniqueidentifier NOT NULL,
	PropertyId uniqueidentifier NOT NULL,
	OwnerId uniqueidentifier NOT NULL,
	CONSTRAINT PK_PropertyOwners PRIMARY KEY (Id),
	CONSTRAINT FK_PropertyOwners_Owners_OwnerId FOREIGN KEY (OwnerId) REFERENCES immob.dbo.Owners(Id) ON DELETE CASCADE,
	CONSTRAINT FK_PropertyOwners_Properties_PropertyId FOREIGN KEY (PropertyId) REFERENCES immob.dbo.Properties(Id) ON DELETE CASCADE
);
 CREATE NONCLUSTERED INDEX IX_PropertyOwners_OwnerId ON dbo.PropertyOwners (  OwnerId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE NONCLUSTERED INDEX IX_PropertyOwners_PropertyId ON dbo.PropertyOwners (  PropertyId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
