CREATE PROCEDURE [dbo].[Ins_Respuestas]
@Corporativo  bigint,
@Hotel nvarchar(10),
@TipoCuestinario nvarchar(5),
@NoPregunta int,
@NoRespuesta int,
@Respuesta nvarchar(100),
@RespuestaIngles nvarchar(100),
@RespuestaAbierta bit

AS
	INSERT INTO [dbo].[C_Respuestas Cuestionario] VALUES (
	@Corporativo,
	@Hotel,
	@TipoCuestinario,
	@NoPregunta,
	@NoRespuesta,
	@Respuesta,
	@RespuestaIngles,
	@RespuestaAbierta 
	)
RETURN 0


