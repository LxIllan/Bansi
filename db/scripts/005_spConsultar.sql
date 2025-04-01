CREATE PROCEDURE spConsultar(@Nombre VARCHAR(255), @Descripcion VARCHAR(255))
AS
BEGIN
    SELECT * FROM tblExamen WHERE
        (@Nombre IS NULL OR Nombre LIKE '%' + @Nombre + '%')
        OR (@Descripcion IS NULL OR Descripcion LIKE '%' + @Descripcion + '%')
END;
