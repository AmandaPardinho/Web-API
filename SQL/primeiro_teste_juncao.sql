USE API_Desafio_Cinema;

--Query Informa��es B�sicas das Tabelas
select 
	Cli.Nome as 'NomeComprador',
	Cli.Sexo as 'G�nero',
	Cli.Idade as 'Idade', 
	Ct.Nome as 'Cidade',
	Est.Nome as 'Estado',
	Ct.UfId as 'Sigla',
	Cn.Nome as 'Cinema',
	I.Id as 'Identificador',
	S.Horario as 'Hor�rio' /*trycast as "dd/mm/yyyy'*/,
	F.Titulo as 'Filme',
	F.Duracao as 'Dura��o',
	G.Nome as 'G�nero'
from Clientes as Cli
	inner join Enderecos as E on Cli.EnderecoId = E.Id 
	inner join Cidades as Ct on Ct.Id = E.CidadeId 
	inner join Ufs as Est on Est.Id = Ct.UfId 
	full outer join Cinemas as Cn on Cn.EnderecoId = E.ClienteId 		
	inner join Ingressos as I on I.ClienteId = Cli.Id
	inner join Sessoes as S on S.Id = I.SessaoId
	inner join Filmes as F on F.Id = S.FilmeId 
	inner join Generos as G on G.Id = F.GeneroId