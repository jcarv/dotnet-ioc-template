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

CREATE TABLE [Countries] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [NameAlias] nvarchar(255) NOT NULL,
    [IsoCode] nvarchar(10) NOT NULL,
    [IsoCodeAlias] nvarchar(10) NOT NULL,
    [Observations] nvarchar(2040) NOT NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Teams] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [NameAlias] nvarchar(255) NOT NULL,
    [Observations] nvarchar(2040) NOT NULL,
    [CountryId] int NULL,
    CONSTRAINT [PK_Teams] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Teams_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([Id])
);
GO

CREATE TABLE [Players] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [NameAlias] nvarchar(255) NOT NULL,
    [Observations] nvarchar(2040) NOT NULL,
    [CountryId] int NULL,
    [TeamId] int NULL,
    CONSTRAINT [PK_Players] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Players_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([Id]),
    CONSTRAINT [FK_Players_Teams_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [Teams] ([Id])
);
GO

CREATE TABLE [TeamsPlayers] (
    [TeamId] int NOT NULL,
    [PlayerId] int NOT NULL,
    [ContractStart] datetime2 NOT NULL,
    [ContractEnd] datetime2 NULL,
    CONSTRAINT [PK_TeamsPlayers] PRIMARY KEY ([TeamId], [PlayerId], [ContractStart]),
    CONSTRAINT [FK_TeamsPlayers_Players_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [Players] ([Id]),
    CONSTRAINT [FK_TeamsPlayers_Teams_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [Teams] ([Id])
);
GO

CREATE UNIQUE INDEX [IX_Countries_IsoCode] ON [Countries] ([IsoCode]);
GO

CREATE UNIQUE INDEX [IX_Countries_IsoCodeAlias] ON [Countries] ([IsoCodeAlias]);
GO

CREATE UNIQUE INDEX [IX_Countries_Name] ON [Countries] ([Name]);
GO

CREATE UNIQUE INDEX [IX_Countries_NameAlias] ON [Countries] ([NameAlias]);
GO

CREATE INDEX [IX_Players_CountryId] ON [Players] ([CountryId]);
GO

CREATE INDEX [IX_Players_TeamId] ON [Players] ([TeamId]);
GO

CREATE INDEX [IX_Teams_CountryId] ON [Teams] ([CountryId]);
GO

CREATE INDEX [IX_TeamsPlayers_PlayerId] ON [TeamsPlayers] ([PlayerId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230903155116_InitialCreate', N'7.0.10');
GO

COMMIT;
GO

