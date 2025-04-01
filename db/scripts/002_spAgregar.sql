CREATE PROCEDURE spAgregar(@Nombre VARCHAR(255), @Descripcion VARCHAR(255))
AS
BEGIN
    DECLARE @Code INT;
    DECLARE @Message NVARCHAR(4000)
    BEGIN TRY
        INSERT INTO tblExamen (Nombre, Descripcion) VALUES (@Nombre, @Descripcion);
		SET @Code = 0;
		SET @Message = 'Registro insertado satisfactoriamente';
    END TRY
    BEGIN CATCH
        SET @Code = ERROR_NUMBER();
		SET @Message = ERROR_MESSAGE();
    END CATCH
	SELECT @Code AS Code, @Message AS Message;
END;
