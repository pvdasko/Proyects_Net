CREATE PROCEDURE [dbo].[Ins_Respuestas_Huesped]
	@Corporativo  bigint,
	@Hotel nvarchar(10),
	@TipoCuestinario nvarchar(5),
	@NoPregunta int,
	@Id nvarchar(20),
	@NoRespuesta int,
	@Calificacion int,
	@Texo nvarchar (250)
AS
	INSERT INTO [dbo].[O_Respuestas Cuestionario Huespedes] VALUES (
	@Corporativo,
	@Hotel,
	@TipoCuestinario,
	@NoPregunta,
	@Id,
	@NoRespuesta,
	@Calificacion,
	@Texo 
	)
RETURN 0
