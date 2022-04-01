BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ClientesCampanhas]') AND [c].[name] = N'Saldo');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ClientesCampanhas] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [ClientesCampanhas] DROP COLUMN [Saldo];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[NumeroDaSorteDetalhe]') AND [c].[name] = N'ValorUtilizado');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [NumeroDaSorteDetalhe] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [NumeroDaSorteDetalhe] ALTER COLUMN [ValorUtilizado] decimal(18,2) NOT NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[NotasFiscais]') AND [c].[name] = N'ValorTotal');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [NotasFiscais] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [NotasFiscais] ALTER COLUMN [ValorTotal] DECIMAL(18,4) NOT NULL;
GO

ALTER TABLE [NotasFiscais] ADD [Saldo] DECIMAL(18,4) NOT NULL DEFAULT 0.0;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Campanhas]') AND [c].[name] = N'ValorParaNumeroDaSorte');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Campanhas] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Campanhas] ALTER COLUMN [ValorParaNumeroDaSorte] DECIMAL(18,4) NOT NULL;
ALTER TABLE [Campanhas] ADD DEFAULT 0.0 FOR [ValorParaNumeroDaSorte];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211110052823_SaldoNotasFiscais', N'5.0.11');
GO

COMMIT;
GO

