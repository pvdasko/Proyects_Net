CREATE PROCEDURE [dbo].[Upd_TiposCuestionario]
	@Corporativo  bigint,
	@Hotel nvarchar(10),
	@TipoCuestionario nvarchar(5),
	@Descripcion nvarchar (50),
	@DescripcionIngles nvarchar (50)
AS
	UPDATE [dbo].[C_Tipos Cuestionario] 	
	SET Descripcion = @Descripcion,
	[Descripcion Ingles] = @DescripcionIngles
	WHERE Corporativo = @Corporativo
	AND Hotel = @Hotel
	AND [Tipo Cuestionario]=@TipoCuestionario
RETURN 0
