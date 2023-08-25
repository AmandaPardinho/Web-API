CREATE OR ALTER FUNCTION dbo.Fim_Sessao
(
	@sessaoHorario datetime2(7),
	@duracao int
)
RETURNS varchar(7)
AS
BEGIN

	DECLARE @fimSessao datetime2;
	DECLARE @retorno varchar(7);

	SET @fimSessao = (DATEADD(MINUTE, @duracao, @sessaoHorario));
	SET @retorno = FORMAT(@fimSessao, N'HH:mm');

	RETURN @retorno;
END
GO