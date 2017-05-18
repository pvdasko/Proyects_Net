CREATE PROCEDURE [dbo].[Upd_Preguntas]
	@Corporativo int = 0,
	@Hotel int,
	@TipoCuestionario nvarchar(5),
	@NoPregunta int,
	@TipoPregunta nvarchar(5),
	@Pregunta nvarchar(150),
	@PreguntaIngles nvarchar(50),
	@CalificacionMax Int
AS
	UPDATE [dbo].[C_Preguntas Cuestionario]
	SET [Tipo Preunta] = @TipoPregunta,
	Pregunta = @Pregunta,
	[Pregunta Ingles] = @PreguntaIngles,
	[Calificacion Maxima] =@CalificacionMax
	WHERE Corporativo = @Corporativo
	AND Hotel = @Hotel
	AND [Tipo Cuestionario] = @TipoCuestionario
	AND [No Pregunta] = @NoPregunta
RETURN 0
