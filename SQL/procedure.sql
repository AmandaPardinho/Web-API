--USE API_Desafio_Cinema;


--STORED PROCEDURE
CREATE OR ALTER PROCEDURE ListaInfosVenda (
@nome VARCHAR(50),
@idade INT ,
@cinema VARCHAR(100),
@filme VARCHAR(50),
@genero VARCHAR(25)
)
AS
BEGIN
	--Query com as informações que serão retornadas
	
	SELECT 
		UPPER(Cli.Nome) AS 'Nome',
		UPPER(Cli.Sexo) AS 'IdentidadeGênero',
		Cli.Idade AS 'Idade',
		dbo.Func_Faixa_Etaria(Cli.Idade) AS  'Faixa Etária',
		UPPER(Ct.Nome) AS 'Cidade',
		UPPER(Est.Nome) AS 'Estado',
		UPPER(Ct.UfId) AS 'Sigla',
		UPPER(Cn.Nome) AS 'Cinema',
		UPPER(CnCt.Nome) AS 'CidadeCinema',
		I.Id AS 'Identificador',
		(SELECT * FROM dbo.Func_Extrai_Data(Cli.Nome)) AS 'Data',
		--dbo.Func_Formata_Horario(Clientes.Nome)  AS 'Horário',
		UPPER(F.Titulo) AS 'Filme',
		UPPER(G.Nome) AS 'Genero',
		F.Duracao AS 'Duração',			
		--dbo.Func_Duracao_Sessao(Clientes.Nome) AS 'FimSessão'
		dbo.Fim_Sessao(S.Horario, F.Duracao) AS 'FimSessão'
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
		(Cli.Idade = @idade OR @idade = 0) AND
		(Cn.Nome LIKE '%' + @cinema + '%' OR @cinema IS NULL) AND
		(F.Titulo LIKE '%' + @filme + '%' OR @filme IS NULL) AND
		(G.Nome LIKE '%' + @genero + '%' OR @genero IS NULL) 		
	ORDER BY S.Horario ASC;


END
GO



