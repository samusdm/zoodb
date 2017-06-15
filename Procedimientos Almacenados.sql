-- PROCEDIMIENTO ALMACENADO PARA OBTENER TODOS LOS DATOS DE LA TABLA TIPOSANIMALES
CREATE PROCEDURE GetTiposAnimales
AS
BEGIN
    SELECT idTipoAnimal, denominacion
    FROM TiposAnimal
END

-- PROCEDIMIENTO PARA OBTENER LOS DATOS POR ID DE LA TABLA TIPOSANIMALES
ALTER PROCEDURE GetTiposAnimalesPorId
	@idTipoAnimal bigint
AS
BEGIN
    SELECT denominacion, idTipoAnimal
    FROM TiposAnimal
    WHERE TiposAnimal.idTipoAnimal = @idTipoAnimal
END

-- PROCEDIMIENTO PARA INSERTAR UN NUEVO TIPOANIMAL
ALTER PROCEDURE AgregarTipoAnimal
	@denominacion nvarchar(50)
AS
BEGIN
	INSERT INTO TiposAnimal(denominacion) VALUES (@denominacion)
END


-- PROCEDIMIENTO PARA ACTUALIZAR LOS DATOS DEL TIPOANIMAL
ALTER PROCEDURE ActualizarTiposAnimales
	@id bigint
	,@denominacion nvarchar(50)
AS
BEGIN
	UPDATE TiposAnimal SET 
		denominacion = @denominacion
		WHERE idTipoAnimal = @id
END

-- PROCEDIMIENTO PARA ELIMINAR UN TIPOANIMAL
ALTER PROCEDURE EliminarTipoAnimal
	@id bigint
AS
BEGIN
	DELETE FROM TiposAnimal WHERE idTipoAnimal = @id
END

-- PROCEDIMIENTO OBTENER TODOS LOS DATOS DE LA TABLA CLASIFICACION
ALTER PROCEDURE GetClasificacion
AS
BEGIN
    SELECT idClasificacion, denominacion
    FROM Clasificacion
END

-- PROCEDIMIENTO OBTENER TODOS LOS DATOS DE LA TABLA CLASIFICACION POR ID
ALTER PROCEDURE GetClasificacionPorId
	@idClasificacion bigint
AS
BEGIN
    SELECT denominacion, idClasificacion
    FROM Clasificacion
    WHERE Clasificacion.idClasificacion = @idClasificacion
END

-- PROCEDIMIENTO PARA INSERTAR UNA NUEVA CLASIFICACION
ALTER PROCEDURE AgregarClasificacion
	@denominacion nvarchar(50)
AS
BEGIN
	INSERT INTO Clasificacion(denominacion) VALUES (@denominacion)
END


-- PROCEDIMIENTO PARA ACTUALIZAR LOS DATOS DE CLASIFICION
ALTER PROCEDURE ActualizarClasificacion
	@id bigint
	,@denominacion nvarchar(50)
AS
BEGIN
	UPDATE Clasificacion SET 
		denominacion = @denominacion
		WHERE idClasificacion = @id
END

-- PROCEDIMIENTO PARA ELIMINAR UNA CLASIFICACION
ALTER PROCEDURE EliminarClasificacion
	@id bigint
AS
BEGIN
	DELETE FROM Clasificacion WHERE idClasificacion = @id
END

-- PROCEDIMIENTO OBTENER TODOS LOS DATOS DE LA TABLA ESPECIES
ALTER PROCEDURE GetSoloEspecies
AS
	BEGIN
		SELECT idEspecie, idClasificacion, idTipoAnimal, nombre, nPatas, esMascota
		FROM Especie
END

-- PROCEDIMIENTO ALMACENADO UNIENDO CONTENIDO DE TODAS LAS TABLAS
ALTER PROCEDURE GetEspecies
AS
BEGIN
	SELECT  
	Especie.idEspecie 
	, Especie.nombre as NombreEspecie
	, Especie.idClasificacion 
	, Clasificacion.denominacion as Clasificacion
	, Especie.idTipoAnimal
	, TiposAnimal.denominacion as TipoAnimal
	, Especie.nPatas
	, Especie.esMascota
	FROM Clasificacion
		INNER JOIN Especie ON Clasificacion.idClasificacion = Especie.idClasificacion
		INNER JOIN TiposAnimal ON Especie.idTipoAnimal = TiposAnimal.idTipoAnimal
	ORDER BY Especie.nombre
END

-- PROCEDIMIENTO OBTENER TODOS LOS DATOS DE LA TABLA ESPECIES POR ID
ALTER PROCEDURE GetEspeciesPorId
	@idEspecie bigint
AS
BEGIN
	SELECT  
	Especie.idEspecie 
	, Especie.nombre as NombreEspecie
	, Especie.idClasificacion 
	, Clasificacion.denominacion as Clasificacion
	, Especie.idTipoAnimal
	, TiposAnimal.denominacion as TipoAnimal
	, Especie.nPatas
	, Especie.esMascota
	FROM Clasificacion
		INNER JOIN Especie ON Clasificacion.idClasificacion = Especie.idClasificacion
		INNER JOIN TiposAnimal ON Especie.idTipoAnimal = TiposAnimal.idTipoAnimal
	WHERE Especie.idEspecie = @idEspecie
	ORDER BY Especie.nombre
END

-- PROCEDIMIENTO PARA INSERTAR UNA NUEVA ESPECIE
ALTER PROCEDURE AgregarEspecie
	@nombre nvarchar(50)
AS
BEGIN
	INSERT INTO Especie(nombre) VALUES (@nombre)
END

-- PROCEDIMIENTO PARA ACTUALIZAR LOS DATOS DE ESPECIE
ALTER PROCEDURE ActualizarEspecie
	@id bigint
	,@nombre nvarchar(50)
AS
BEGIN
	UPDATE Especie SET 
		nombre = @nombre
		WHERE idEspecie = @id
END

-- PROCEDIMIENTO PARA ELIMINAR UNA ESPECIE
ALTER PROCEDURE EliminarEspecie
	@id bigint
AS
BEGIN
	DELETE FROM Especie WHERE idEspecie = @id
END