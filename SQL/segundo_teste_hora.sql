USE API_Desafio_Cinema;

--Query Informa��es B�sicas das Tabelas
select 
	Cli.Nome as 'NomeComprador',
	Cli.Sexo as 'G�nero',
	Cli.Idade as 'Idade', 
	--classifica��o comprador (faixa et�ria)--
	Ct.Nome as 'Cidade',
	Est.Nome as 'Estado',
	Ct.UfId as 'Sigla',
	Cn.Nome as 'Cinema',
	Ct.Nome as 'CidadeCinema',
	I.Id as 'Identificador',
	CONCAT(
	DATEPART(DAY, S.Horario),
	'/',
	DATEPART(MONTH, S.Horario),
	'/',
	DATEPART(YEAR, S.Horario) 
	) AS 'Data',
	CONCAT(
	DATEPART(HOUR, S.Horario),
	':',
	DATEPART(MINUTE, S.Horario)
	) AS 'Hor�rio',
	F.Titulo as 'Filme',
	G.Nome as 'G�nero',
	F.Duracao as 'Dura��o'
from Clientes as Cli
	inner join Enderecos as E on Cli.EnderecoId = E.Id 
	inner join Cidades as Ct on Ct.Id = E.CidadeId 
	inner join Ufs as Est on Est.Id = Ct.UfId 
	full outer join Cinemas as Cn on Cn.EnderecoId = E.ClienteId 		
	inner join Ingressos as I on I.ClienteId = Cli.Id
	inner join Sessoes as S on S.Id = I.SessaoId
	inner join Filmes as F on F.Id = S.FilmeId 
	inner join Generos as G on G.Id = F.GeneroId
ORDER BY S.Horario ASC;