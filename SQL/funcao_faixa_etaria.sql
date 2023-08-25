CREATE OR ALTER FUNCTION dbo.Func_Faixa_Etaria
(
	@idade int
)
RETURNS varchar(15)
AS
BEGIN
	DECLARE @retorno varchar(15);

	SET @retorno = 
		CASE WHEN @idade <= 12 THEN 'CRIANÇA'
			WHEN @idade BETWEEN 13 AND 19 THEN 'ADOLESCENTE'
			WHEN @idade BETWEEN 20 AND 59 THEN 'ADULTO'
			ELSE 'IDOSO' 
		END; 
	RETURN @retorno;
END
GO