CREATE PROCEDURE [dbo].[Ins_Preguntas]
	@Corporativo int = 0,
	@Hotel int,
	@TipoCuestionario nvarchar(5),
	@NoPregunta int,
	@TipoPregunta nvarchar(5),
	@Pregunta nvarchar(150),
	@PreguntaIngles nvarchar(50),
	@CalificacionMax Int
AS
	INSERT INTO [dbo].[C_Preguntas Cuestionario] VALUES (
	@Corporativo,
	@Hotel,
	@TipoCuestionario,
	@NoPregunta,
	@TipoPregunta,
	@Pregunta,
	@PreguntaIngles,
	@CalificacionMax
	)
RETURN 0
