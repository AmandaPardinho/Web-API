USE API_Desafio_Cinema;

--Query Informações Básicas das Tabelas
select 
	Cli.Nome as 'NomeComprador',
	Cli.Sexo as 'Gênero',
	Cli.Idade as 'Idade', 
	Ct.Nome as 'Cidade',
	Est.Nome as 'Estado',
	Ct.UfId as 'Sigla',
	Cn.Nome as 'Cinema',
	I.Id as 'Identificador',
	S.Horario as 'Horário' /*trycast as "dd/mm/yyyy'*/,
	F.Titulo as 'Filme',
	F.Duracao as 'Duração',
	G.Nome as 'Gênero'
from Clientes as Cli
	inner join Enderecos as E on Cli.EnderecoId = E.Id 
	inner join Cidades as Ct on Ct.Id = E.CidadeId 
	inner join Ufs as Est on Est.Id = Ct.UfId 
	full outer join Cinemas as Cn on Cn.EnderecoId = E.ClienteId 		
	inner join Ingressos as I on I.ClienteId = Cli.Id
	inner join Sessoes as S on S.Id = I.SessaoId
	inner join Filmes as F on F.Id = S.FilmeId 
	inner join Generos as G on G.Id = F.GeneroId