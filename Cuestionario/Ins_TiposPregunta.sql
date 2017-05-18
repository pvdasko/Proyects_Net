CREATE PROCEDURE [dbo].[Ins_TiposPregunta]
	@Corporativo  bigint,
	@Hotel nvarchar(10),
	@TipoCuestionario nvarchar(5),
	@Descripcion nvarchar (50),
	@DescripcionIngles nvarchar (50)
AS
	INSERT INTO [dbo].[C_Tipos Pregunta Cuestionario] VALUES (
	@Corporativo,
	@Hotel,
	@TipoCuestionario,
	@Descripcion,
	@DescripcionIngles

	)
RETURN 0
