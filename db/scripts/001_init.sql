CREATE DATABASE BdiExamen;

CREATE TABLE tblExamen
(
    idExamen INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(255),
    Descripcion VARCHAR(255)
);
