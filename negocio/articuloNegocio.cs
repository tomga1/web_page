using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Security.Cryptography.X509Certificates;

namespace negocio
{
    public class articuloNegocio
    {

        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.ImagenUrl, a.Precio, m.Descripcion AS Marcas, c.Descripcion AS Categorias FROM ARTICULOS a INNER JOIN MARCAS m ON a.IdMarca = m.Id INNER JOIN CATEGORIAS c ON a.IdCategoria = c.Id";
                comando.Connection = conexion;  

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)lector["Id"];
                    aux.codigo = (string)lector["Codigo"];
                    aux.nombre = (string)lector["Nombre"];
                    aux.descripcion = (string)lector["Descripcion"];
                    aux.precio = (decimal)lector["Precio"];
                    if (!(lector["ImagenUrl"] is DBNull))
                        aux.imagenurl = (string)lector["ImagenUrl"];

                    Marca marca = new Marca();  
                    marca.marca = (string)lector["Marcas"];
                    marca.id = (int)lector["Id"];
                    aux.marca = marca; 
                    
                    
                    Categoria categoria = new Categoria();
                    categoria.categoria = (string)lector["Categorias"];
                    categoria.id = (int)lector["Id"];
                    aux.categoria = categoria; 
                    //aux.categoria = (string)lector["Categorias"];

                   
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { 
                conexion.Close();   
            }

        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();  

            try
            {
                //datos.setearConsulta("insert into articulos(Codigo,Descripcion,Proveedor,Stock) values(" + nuevo.codigo + ",'" + nuevo.descripcion + ",'" + nuevo.proveedor + ",'" + nuevo.stock)";
                datos.setearConsulta($"insert into ARTICULOS(Codigo,Nombre,Descripcion,IdMarca, IdCategoria, Precio, ImagenUrl) values('{nuevo.codigo}', '{nuevo.nombre}', '{nuevo.descripcion}', '{nuevo.idmarca}', '{nuevo.idcategoria}',{nuevo.precio}, '{nuevo.imagenurl}')");
                datos.ejecutarAccion();      
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion(); 
            }

        }
        public void modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, Precio = @precio, ImagenUrl = @imagenurl where Id = @id");
                datos.setearParametro("@codigo", art.codigo);
                datos.setearParametro("@nombre", art.nombre);
                datos.setearParametro("@descripcion", art.descripcion);
                datos.setearParametro("@precio", art.precio);
                datos.setearParametro("@imagenurl", art.imagenurl);
                datos.setearParametro("@id", art.id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminar(int id)
        {

            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
                
                
                
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select Id, Codigo, Nombre, Descripcion,IdMarca, IdCategoria, ImagenUrl, Precio from ARTICULOS where ";


                if(campo == "Codigo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Codigo like '" + filtro + "%'   ";
                            break;

                        case "Termina con":
                            consulta += "Codigo like  '%" + filtro + "'"  ;
                            break;
                        default:
                            consulta += "Codigo like '%" + filtro + "%'";
                            break;  
                    }
                }
                else if(campo == "Nombre")
                {
                    switch (criterio)
                    {

                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%'   ";
                            break;

                        case "Termina con":
                            consulta += "Nombre like  '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch(criterio)
                    {
                        case "Comienza con":
                            consulta += "Descripcion like '" + filtro + "%'   ";
                            break;

                        case "Termina con":
                            consulta += "Descripcion like  '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Descripcion like '%" + filtro + "%'";
                            break;
                    }

                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    //aux.descripcion = (string)datos.Lector["IdCategoria"];  
                    //aux.stock = (int)datos.Lector["Stock"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.imagenurl = (string)datos.Lector["ImagenUrl"];
                    aux.precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            
        }

        public List<Marca> ListarMarca()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select * from MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.marca = (string)datos.Lector["Descripcion"];
                    aux.id = (int)datos.Lector["Id"];


                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public List<Categoria> ListarCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select * from CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.categoria = (string)datos.Lector["Descripcion"];
                    aux.id = (int)datos.Lector["Id"];


                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
