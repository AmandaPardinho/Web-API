CREATE OR ALTER FUNCTION dbo.Func_Duracao_Sessao
(@Pessoa NVARCHAR(MAX))
RETURNS TABLE
AS
RETURN
	
	(SELECT FORMAT
		(CAST
			(DATEADD
				(MINUTE, +F.Duracao, S.Horario) 
			AS datetime2),
		N'HH:mm') AS 'FimSessão'
	FROM Sessoes AS S
		INNER JOIN Filmes AS F ON F.Id = S.FilmeId
		INNER JOIN Ingressos AS I ON I.SessaoId = S.Id
		INNER JOIN Clientes AS Cli ON I.ClienteId = Cli.Id
	WHERE Cli.Nome like '%' + @Pessoa + '%'
	);
GO

SELECT * FROM dbo.Func_Duracao_Sessao('');