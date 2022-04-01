DECLARE @CampanhaId int

SET @CampanhaId = (select top 1 Id from Campanhas)

DECLARE @NumeroInicial INT = 1
DECLARE @NumeroFinal INT = 100000

DECLARE @numero INT = @NumeroInicial;

WHILE @numero <= @NumeroFinal
BEGIN
    INSERT INTO [dbo].[NumerosDaSorte] (Numero, CampanhaId) VALUES (@numero, @CampanhaId)   
    SET @numero = @numero + 1;
END;

SELECT * FROM NumerosDaSorte