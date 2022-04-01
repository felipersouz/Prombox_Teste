DECLARE @EmpresaId int
DECLARE @CampanhaId int

SET @EmpresaId = (select top 1 Id from Empresas)
SET @CampanhaId = (select top 1 Id from Campanhas)


INSERT INTO Aderentes (Nome, Cnpj, EmpresaId) values ('Loja Centro', '05.543.460/0001-80', @EmpresaId)
INSERT INTO Aderentes (Nome, Cnpj, EmpresaId) values ('Loja Av. Brasil', '76.741.373/0001-85', @EmpresaId)
INSERT INTO Aderentes (Nome, Cnpj, EmpresaId) values ('Matriz', '50.335.243/0001-59', @EmpresaId)


INSERT INTO CampanhaAderentes (CampanhaId, AderenteId) values (@CampanhaId, (SELECT TOP 1 Id from Aderentes where Cnpj = '05.543.460/0001-80'))
INSERT INTO CampanhaAderentes (CampanhaId, AderenteId) values (@CampanhaId, (SELECT TOP 1 Id from Aderentes where Cnpj = '76.741.373/0001-85'))
INSERT INTO CampanhaAderentes (CampanhaId, AderenteId) values (@CampanhaId, (SELECT TOP 1 Id from Aderentes where Cnpj = '50.335.243/0001-59'))