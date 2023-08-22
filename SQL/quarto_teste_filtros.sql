USE API_Desafio_Cinema;

--Parâmetros
DECLARE 
	@nome VARCHAR(50),
	@idade INT,
	@cinema VARCHAR(100),
	@filme VARCHAR(50),
	@genero VARCHAR(25);

--Query Informações Básicas das Tabelas
SELECT 
	UPPER(Cli.Nome) AS 'NomeComprador',
	UPPER(Cli.Sexo) AS 'IdentidadeGênero',
	Cli.Idade AS 'Idade', 
		CASE WHEN Idade <= 12 THEN 'CRIANÇA'
		WHEN Idade BETWEEN 13 AND 19 THEN 'ADOLESCENTE'
		WHEN Idade BETWEEN 20 AND 59 THEN 'ADULTO'
		ELSE 'IDOSO' 
		END AS  'Faixa Etária' ,
	UPPER(Ct.Nome) AS 'Cidade',
	UPPER(Est.Nome) AS 'Estado',
	UPPER(Ct.UfId) AS 'Sigla',
	UPPER(Cn.Nome) AS 'Cinema',
	UPPER(CnCt.Nome) AS 'CidadeCinema',
	I.Id AS 'Identificador',
	CONCAT(
	DATEPART(DAY, S.Horario),
	'/',
	DATEPART(MONTH, S.Horario),
	'/',
	DATEPART(YEAR, S.Horario) 
	) AS 'Data',
	FORMAT(CAST(S.Horario AS datetime2), N'HH:mm') AS 'Horário',
	UPPER(F.Titulo) AS 'Filme',
	UPPER(G.Nome) AS 'Gênero',
	F.Duracao AS 'Duração',
		FORMAT(CAST(DATEADD(MINUTE, +F.Duracao, S.Horario) AS datetime2), N'HH:mm') AS 'FimSessão'
FROM Clientes AS Cli
	INNER JOIN Enderecos AS E ON Cli.EnderecoId = E.Id 
	INNER JOIN Cidades AS Ct ON Ct.Id = E.CidadeId 
	INNER JOIN Ufs AS Est ON Est.Id = Ct.UfId 
	INNER JOIN Ingressos AS I ON I.ClienteId = Cli.Id
	INNER JOIN Sessoes AS S ON S.Id = I.SessaoId
	LEFT JOIN Cinemas AS Cn ON Cn.Id = S.CinemaId 
		LEFT JOIN Enderecos AS CnE ON CnE.Id = Cn.EnderecoId
			LEFT JOIN Cidades AS CnCt ON CnCt.Id = CnE.CidadeId
	INNER JOIN Filmes AS F ON F.Id = S.FilmeId 
	INNER JOIN Generos AS G ON G.Id = F.GeneroId
WHERE 
	(Cli.Nome LIKE '%' + @nome + '%' OR @nome IS NULL) AND
	(Cli.Idade = @idade OR @idade IS NULL) AND
	(Cn.Nome LIKE '%' + @cinema + '%' OR @cinema IS NULL) AND
	(F.Titulo LIKE '%' + @filme + '%' OR @filme IS NULL) AND
	(G.Nome LIKE '%' + @genero + '%' OR @genero IS NULL)
ORDER BY S.Horario ASC;