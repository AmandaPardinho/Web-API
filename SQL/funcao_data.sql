CREATE OR ALTER FUNCTION dbo.Func_Extrai_Data
(@Pessoa NVARCHAR(MAX))
RETURNS TABLE
AS
RETURN	
	SELECT TOP 1 FORMAT(S.Horario, 'd', 'pt-br') AS 'Data' 
	FROM Sessoes AS S
		LEFT JOIN Ingressos AS I ON S.Id = I.SessaoId
		INNER JOIN Clientes AS Cli ON I.ClienteId = Cli.Id
	WHERE Cli.Nome like '%' + @Pessoa + '%';
GO

