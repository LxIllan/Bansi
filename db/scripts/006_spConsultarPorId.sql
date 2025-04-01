CREATE PROCEDURE spConsultarPorId(@Id INT)
AS
BEGIN
    SELECT * FROM tblExamen WHERE  idExamen = @Id;
END;
