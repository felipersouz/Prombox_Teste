--SELECT * FROM [Dev_Prombox_Clean].[dbo].[DuvidasFrequentes]

DECLARE @EmpresaId INT = 2
DECLARE @CampanhaId INT = 2 
DECLARE @Pergunta VARCHAR(MAX)
DECLARE @Resposta VARCHAR(MAX)
DECLARE @Ordem INT

DECLARE CUR CURSOR FOR SELECT Pergunta, Resposta, Ordem FROM DuvidasFrequentes WHERE EmpresaId IS NULL AND CampanhaId IS NULL

OPEN CUR  
    FETCH NEXT FROM CUR INTO @Pergunta, @Resposta, @Ordem

WHILE @@FETCH_STATUS = 0  
BEGIN    
    INSERT INTO DuvidasFrequentes (Pergunta, Resposta, Ordem, EmpresaId, CampanhaId) VALUES
        (@Pergunta, @Resposta, @Ordem, @EmpresaId, @CampanhaId)

    FETCH NEXT FROM CUR INTO @Pergunta, @Resposta, @Ordem
    END    
CLOSE CUR  
DEALLOCATE CUR  
 