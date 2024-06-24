**SP para agregar articulo con metodo agregarConSP()**
CREATE PROCEDURE storedAltaArticulo
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(50),
@idmarca int,
@idcategoria int,
@imagenUrl varchar(300),
@precio money
as
insert into ARTICULOS values(@codigo, @nombre, @descripcion, @idmarca, @idcategoria, @imagenUrl, @precio)
**-----------------**
