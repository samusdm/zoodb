-- PROCEDIMIENTOS ALMACENADOS

ALTER PROCEDURE GET_TipoAnimales
AS
BEGIN
	SELECT idTipoAnimal, denominacion
	FROM TiposAnimal
END

ALTER PROCEDURE GET_Clasificacion
AS
BEGIN
	SELECT idClasificacion, denominacion
	FROM Clasificacion
END


ALTER PROCEDURE GET_Especie
AS
BEGIN
	SELECT idEspecie, idClasificacion, idTipoAnimal, nombre, nPatas, esMascota
	FROM Especie
END


ALTER PROCEDURE GetTiposAnimalesPorId
	@idTipoAnimal bigint
AS
BEGIN
	SELECT denominacion, idTipoAnimal
	FROM TiposAnimal
	WHERE TiposAnimal.idTipoAnimal = @idTipoAnimal
END

ALTER PROCEDURE GetEspecies
AS
BEGIN
    SELECT  
    Especie.idEspecie 
    , Especie.nombre as Nombre
    , Especie.idClasificacion 
    , Clasificacion.denominacion as Clasificacion
    , Especie.idTipoAnimal
    , TiposAnimal.denominacion as Tipo
    , Especie.nPatas
    , Especie.esMascota
    FROM Clasificacion
        INNER JOIN Especie ON Clasificacion.idClasificacion = Especie.idClasificacion
        INNER JOIN TiposAnimal ON Especie.idTipoAnimal = TiposAnimal.idTipoAnimal
    ORDER BY Especie.nombre
END