CREATE PROCEDURE [dbo].[Upd_Respuestas]
	@Corporativo  bigint,
	@Hotel nvarchar(10),
	@TipoCuestinario nvarchar(5),
	@NoPregunta int,
	@NoRespuesta int,
	@Respuesta nvarchar(100),
	@RespuestaIngles nvarchar(100),
	@RespuestaAbierta bit

AS
	UPDATE  [dbo].[C_Respuestas Cuestionario] 
	SET Respuesta =	@Respuesta,
	[Respuesta Ingles] =@RespuestaIngles,
	[Respuesta Abierta] = @RespuestaAbierta 
	WHERE Corporativo = @Corporativo
	AND Hotel = @Hotel
	AND [Tipo Cuestionrio] = @TipoCuestinario
	AND [No Pregunta] = @NoPregunta
	AND [No Respuesta] = @NoRespuesta
	
RETURN 0
