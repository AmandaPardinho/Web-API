USE API_Desafio_Cinema;

--Query Informa��es B�sicas das Tabelas
SELECT 
	UPPER(Cli.Nome) AS 'NomeComprador',
	UPPER(Cli.Sexo) AS 'IdentidadeG�nero',
	Cli.Idade AS 'Idade', 
		CASE WHEN Idade <= 12 THEN 'CRIAN�A'
		WHEN Idade BETWEEN 13 AND 19 THEN 'ADOLESCENTE'
		WHEN Idade BETWEEN 20 AND 59 THEN 'ADULTO'
		ELSE 'IDOSO' 
		END AS  'Faixa Et�ria' ,
	UPPER(Ct.Nome) AS 'Cidade',
	UPPER(Est.Nome) AS 'Estado',
	UPPER(Ct.UfId) AS 'Sigla',
	UPPER(Cn.Nome) AS 'Cinema',
	UPPER(Ct.Nome) AS 'CidadeCinema',
	I.Id AS 'Identificador',
	CONCAT(
	DATEPART(DAY, S.Horario),
	'/',
	DATEPART(MONTH, S.Horario),
	'/',
	DATEPART(YEAR, S.Horario) 
	) AS 'Data',
	FORMAT(CAST(S.Horario AS datetime2), N'HH:mm') AS 'Hor�rio',
	UPPER(F.Titulo) AS 'Filme',
	UPPER(G.Nome) AS 'G�nero',
	F.Duracao AS 'Dura��o',
		FORMAT(CAST(DATEADD(MINUTE, +F.Duracao, S.Horario) AS datetime2), N'HH:mm') AS 'FimSess�o'
FROM Clientes AS Cli
	INNER JOIN Enderecos AS E ON Cli.EnderecoId = E.Id 
	INNER JOIN Cidades AS Ct ON Ct.Id = E.CidadeId 
	INNER JOIN Ufs AS Est ON Est.Id = Ct.UfId 
	FULL OUTER JOIN Cinemas AS Cn ON Cn.EnderecoId = E.ClienteId 		
	INNER JOIN Ingressos AS I ON I.ClienteId = Cli.Id
	INNER JOIN Sessoes AS S ON S.Id = I.SessaoId
	INNER JOIN Filmes AS F ON F.Id = S.FilmeId 
	INNER JOIN Generos AS G ON G.Id = F.GeneroId
ORDER BY S.Horario ASC;