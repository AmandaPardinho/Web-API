USE API_Desafio_Cinema;

SELECT 
	Clientes.Nome AS 'NomeComprador', 
	Clientes.Sexo AS 'G�nero',
	Clientes.Idade AS 'Idade'
FROM Clientes; --falta determinar faixa et�ria => 
				--0-12: crian�a
				--13-19: adolescente
				--20-59: adulto
				--60+: idoso

SELECT Cidades.Nome AS 'NomeCidade', Cidades.UfId AS 'UF'
from Cidades;

SELECT Ufs.Nome AS 'NomeUF' FROM Ufs;

SELECT 
	Cinemas.Nome AS 'NomeCinema', 
	Cinemas.EnderecoId AS 'Endere�oCinema'
FROM Cinemas;

SELECT 
	Ingressos.Id AS 'Identifica��oIngresso',
	Ingressos.SessaoId AS 'Sess�o'
From Ingressos;

SELECT 
	Sessoes.Horario AS 'Hor�rio',
	Sessoes.FilmeId as 'Filme'
from Sessoes;

select
	Filmes.Titulo As 'T�tulo',
	Filmes.GeneroId as 'G�nero',
	Filmes.Duracao as 'Dura��o'
from Filmes;

select * from Generos;


--hor�rio de in�cio do filme(hi) == Sessoes.Hor�rio
--hor�rio de t�rmino do filme (ht) == ht = hf - hi
--faixa et�ria => usar WHEN (?)
--data ingresso (?)


--Testes
SELECT 
	Clientes.Id As 'ID',
	Clientes.Nome AS 'NomeComprador', 
	Clientes.Sexo AS 'G�nero',
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