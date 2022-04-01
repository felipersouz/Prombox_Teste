BEGIN TRANSACTION;
GO

ALTER TABLE [NumerosDaSorte] ADD [Serie] int NOT NULL DEFAULT 0;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[NumeroDaSorteDetalhe]') AND [c].[name] = N'ValorUtilizado');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [NumeroDaSorteDetalhe] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [NumeroDaSorteDetalhe] ALTER COLUMN [ValorUtilizado] DECIMAL(18,4) NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211112052618_serieNumeroDaSorte', N'5.0.11');
GO

COMMIT;
GO

