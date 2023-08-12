USE API_Desafio_Cinema;

SELECT 
	Clientes.Nome AS 'NomeComprador', 
	Clientes.Sexo AS 'Gênero',
	Clientes.Idade AS 'Idade'
FROM Clientes; --falta determinar faixa etária => 
				--0-12: criança
				--13-19: adolescente
				--20-59: adulto
				--60+: idoso

SELECT Cidades.Nome AS 'NomeCidade', Cidades.UfId AS 'UF'
from Cidades;

SELECT Ufs.Nome AS 'NomeUF' FROM Ufs;

SELECT 
	Cinemas.Nome AS 'NomeCinema', 
	Cinemas.EnderecoId AS 'EndereçoCinema'
FROM Cinemas;

SELECT 
	Ingressos.Id AS 'IdentificaçãoIngresso',
	Ingressos.SessaoId AS 'Sessão'
From Ingressos;

SELECT 
	Sessoes.Horario AS 'Horário',
	Sessoes.FilmeId as 'Filme'
from Sessoes;

select
	Filmes.Titulo As 'Título',
	Filmes.GeneroId as 'Gênero',
	Filmes.Duracao as 'Duração'
from Filmes;

select * from Generos;


--horário de início do filme(hi) == Sessoes.Horário
--horário de término do filme (ht) == ht = hf - hi
--faixa etária => usar WHEN (?)
--data ingresso (?)


--Testes
SELECT 
	Clientes.Id As 'ID',
	Clientes.Nome AS 'NomeComprador', 
	Clientes.Sexo AS 'Gênero',
	Clientes.Idade AS 'Idade',
	Cidades.Nome As 'Cidade',
	Cidades.UfId as 'Estado'
FROM Clientes
	inner join Enderecos as E on Clientes.EnderecoId = E.Id
	inner join Cidades on E.CidadeId = Cidades.Id;

select * from Enderecos;
select * from Sessoes;

SELECT CONCAT(
	DATEPART(DAY, S.Horario),
	'/',
	DATEPART(MONTH, S.Horario),
	'/',
	DATEPART(YEAR, S.Horario)
) FROM Sessoes AS S;