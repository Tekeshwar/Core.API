IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Departments] (
    [DepartmentId] int NOT NULL IDENTITY,
    [DepartmentName] nvarchar(max) NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY ([DepartmentId])
);
GO

CREATE TABLE [Employees] (
    [EmployeeId] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [DateOfBrith] datetime2 NOT NULL,
    [Gender] nvarchar(max) NULL,
    [DepartmentId] int NOT NULL,
    [PhotoPath] nvarchar(max) NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployeeId])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DepartmentId', N'DepartmentName') AND [object_id] = OBJECT_ID(N'[Departments]'))
    SET IDENTITY_INSERT [Departments] ON;
INSERT INTO [Departments] ([DepartmentId], [DepartmentName])
VALUES (1, N'IT'),
(2, N'HR'),
(3, N'Payroll'),
(4, N'Admin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DepartmentId', N'DepartmentName') AND [object_id] = OBJECT_ID(N'[Departments]'))
    SET IDENTITY_INSERT [Departments] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EmployeeId', N'DateOfBrith', N'DepartmentId', N'Email', N'FirstName', N'Gender', N'LastName', N'PhotoPath') AND [object_id] = OBJECT_ID(N'[Employees]'))
    SET IDENTITY_INSERT [Employees] ON;
INSERT INTO [Employees] ([EmployeeId], [DateOfBrith], [DepartmentId], [Email], [FirstName], [Gender], [LastName], [PhotoPath])
VALUES (1, '1980-10-05T00:00:00.0000000', 1, N'David@pragimtech.com', N'John', N'Male', N'Hastings', N'images/john.png'),
(2, '1981-12-22T00:00:00.0000000', 2, N'Sam@pragimtech.com', N'Sam', N'Male', N'Galloway', N'images/sam.jpg'),
(3, '1979-11-11T00:00:00.0000000', 1, N'mary@pragimtech.com', N'Mary', N'Female', N'Smith', N'images/mary.png'),
(4, '1982-09-23T00:00:00.0000000', 3, N'sara@pragimtech.com', N'Sara', N'Female', N'Longway', N'images/sara.png');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EmployeeId', N'DateOfBrith', N'DepartmentId', N'Email', N'FirstName', N'Gender', N'LastName', N'PhotoPath') AND [object_id] = OBJECT_ID(N'[Employees]'))
    SET IDENTITY_INSERT [Employees] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220327062628_InitialCreate', N'5.0.15');
GO

COMMIT;
GO

