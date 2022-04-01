DECLARE @EmpresaId int

SET @EmpresaId = (select top 1 Id from Empresas)


DECLARE @Inicio DATETIME = DATEADD(DAY, -15, GETDATE())

INSERT INTO Campanhas (
    DataInicioCampanha, 
    DataFinalCampanha, 
    DataLimiteCadastro, 
    DataInicioPeriodoCompras, 
    DataFinalPeriodoCompras, 
    DataSorteio, 
    EmpresaId, 
    TipoCAmpanha, 
    IsMaior18Anos, 
    IsLimiteGeografico, 
    IsLimiteTrocasNF, 
    IsLimiteGeneroSexual, 
    IsBloquearFuncionario, 
    RegraParticipacao, 
    DataEnvioNF, 
    DataVencimento,
    Ativa)
VALUES (
    @Inicio,
    DATEADD(DAY, 60, @Inicio),
    DATEADD(DAY, 50, @Inicio),
    @Inicio,
    DATEADD(DAY, 50, @Inicio),
    DATEADD(DAY, 61, @Inicio),
    @EmpresaId,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    DATEADD(DAY, 15, @Inicio),
    DATEADD(DAY, 30, @Inicio),
    1
    )
