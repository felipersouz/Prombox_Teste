USE [Dev_Prombox_Clean]
GO
/****** Object:  StoredProcedure [dbo].[EscolherNumeroDaSorte]    Script Date: 09/11/2021 23:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[EscolherNumeroDaSorte] 
    @ClienteId BIGINT,
    @CampanhaId INT
AS


-- DECLARE @ClienteId BIGINT = 1
-- DECLARE @CampanhaId INT = 2
DECLARE @numeroDaSorteId BIGINT
DECLARE @quantidade INT
DECLARE @random BIGINT

SET @quantidade = ( SELECT
                        COUNT(*)
                    FROM 
                        NumerosDaSorte
                    WHERE
                        CampanhaId = @CampanhaId   
                        AND ClienteId IS NULL
                    )

-- SET @quantidade = 3

SET @random = ( SELECT FLOOR(RAND()*@quantidade+1))

-- SELECT @quantidade as quantidade
-- SELECT @random as randomEscolhido

SET @numeroDaSorteId = (SELECT 
                            Id
                        FROM 
                            NumerosDaSorte
                        WHERE
                            CampanhaId = 2    
                            AND ClienteId IS NULL
                        ORDER BY (Id)
                              OFFSET @random-1 ROWS
                              FETCH NEXT 1 ROWS ONLY)

UPDATE 
    NumerosDaSorte 
SET 
    ClienteId = @ClienteId,
    DataHoraAssociacao = GETDATE()
WHERE Id = @numeroDaSorteId

SELECT @numeroDaSorteId