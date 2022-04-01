BEGIN TRANSACTION;
GO

ALTER TABLE [UsuariosClientes] ADD [ExpiracaoCodigoRecuperacaoSenha] DATETIME NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211118140125_ExpiracaoCodigoRecuperacaoSenha', N'5.0.11');
GO

COMMIT;
GO

