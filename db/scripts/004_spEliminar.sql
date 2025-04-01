CREATE PROCEDURE spEliminar(@Id INT)
AS
BEGIN
    DECLARE @Code INT;
    DECLARE @Message NVARCHAR(4000)
    BEGIN TRY
        DELETE FROM tblExamen WHERE idExamen = @Id;
        SET @Code = 0;
        SET @Message = 'Registro eliminado satisfactoriamente';
    END TRY
    BEGIN CATCH
        SET @Code = ERROR_NUMBER();
        SET @Message = ERROR_MESSAGE();
    END CATCH
    SELECT @Code AS Code, @Message AS Message;
END;
