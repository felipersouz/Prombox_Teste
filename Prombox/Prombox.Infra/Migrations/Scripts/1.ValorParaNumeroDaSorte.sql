BEGIN TRANSACTION;
GO

ALTER TABLE [Campanhas] ADD [ValorParaNumeroDaSorte] DECIMAL(18,4) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211110015307_ValorParaNumeroDaSorte', N'5.0.11');
GO

update [Campanhas] set ValorParaNumeroDaSorte = 100

COMMIT;
GO

