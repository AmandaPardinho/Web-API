USE API_Desafio_Cinema;

--Query Informações Básicas das Tabelas
select 
	Cli.Nome as 'NomeComprador',
	Cli.Sexo as 'Gênero',
	Cli.Idade as 'Idade', 
	--classificação comprador (faixa etária)--
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
	) AS 'Horário',
	F.Titulo as 'Filme',
	G.Nome as 'Gênero',
	F.Duracao as 'Duração'
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