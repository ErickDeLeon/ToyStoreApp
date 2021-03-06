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

CREATE TABLE [Toys] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] varchar(50) NOT NULL,
    [Descripcion] varchar(100) NULL,
    [RestriccionEdad] int NULL,
    [Compania] varchar(50) NOT NULL,
    [Precio] float NOT NULL,
    CONSTRAINT [PK_Toys] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210415033934_StartMigration', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre', N'Descripcion', N'RestriccionEdad', N'Compania', N'Precio') AND [object_id] = OBJECT_ID(N'[Toys]'))
    SET IDENTITY_INSERT [Toys] ON;
INSERT INTO [Toys] ([Id], [Nombre], [Descripcion], [RestriccionEdad], [Compania], [Precio])
VALUES (1, 'Jenga', 'jenga Hasbro a los must have de diversión que no podrán faltar en tu hogar.', 10, 'Hasbro', 359.0E0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre', N'Descripcion', N'RestriccionEdad', N'Compania', N'Precio') AND [object_id] = OBJECT_ID(N'[Toys]'))
    SET IDENTITY_INSERT [Toys] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre', N'Descripcion', N'RestriccionEdad', N'Compania', N'Precio') AND [object_id] = OBJECT_ID(N'[Toys]'))
    SET IDENTITY_INSERT [Toys] ON;
INSERT INTO [Toys] ([Id], [Nombre], [Descripcion], [RestriccionEdad], [Compania], [Precio])
VALUES (2, 'Laptop Aprende Conmigo', '¡Esta laptop de juguete mantiene a los bebés ocupados!', 1, 'Fisher Price', 539.0E0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre', N'Descripcion', N'RestriccionEdad', N'Compania', N'Precio') AND [object_id] = OBJECT_ID(N'[Toys]'))
    SET IDENTITY_INSERT [Toys] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre', N'Descripcion', N'RestriccionEdad', N'Compania', N'Precio') AND [object_id] = OBJECT_ID(N'[Toys]'))
    SET IDENTITY_INSERT [Toys] ON;
INSERT INTO [Toys] ([Id], [Nombre], [Descripcion], [RestriccionEdad], [Compania], [Precio])
VALUES (3, 'Woody - Toy Story 4', 'Posee un diseño lleno de detalles únicos que lo hacen una pieza perfecta', 3, 'Disney Collection', 524.29999999999995E0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nombre', N'Descripcion', N'RestriccionEdad', N'Compania', N'Precio') AND [object_id] = OBJECT_ID(N'[Toys]'))
    SET IDENTITY_INSERT [Toys] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210417203547_SeedingData', N'5.0.5');
GO

COMMIT;
GO

