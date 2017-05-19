CREATE PROCEDURE [dbo].[Ins_TiposCuestionario]
	@Corporativo  bigint,
	@Hotel nvarchar(10),
	@TipoCuestionario nvarchar(5),
	@Descripcion nvarchar (50),
	@DescripcionIngles nvarchar (50)
AS
	INSERT INTO [dbo].[C_Tipos Cuestionario] VALUES (
	@Corporativo,
	@Hotel,
	@TipoCuestionario,
	@Descripcion,
	@DescripcionIngles

	)
RETURN 0
