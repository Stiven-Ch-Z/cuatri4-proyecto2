using Proyecto2_Noticias.CapaDatos;
using Proyecto2_Noticias.CapaDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;


namespace Proyecto2_Noticias.CapaNegocio
{
    public class AutorService
    {
        public List<Autor> Listar() //este método devuelve una lista de todos los autores
        {
            try
            {
                using (var context = new NoticieroContext()) // crea una instancia del contexto de la base de datos
                {
                    context.Database.Log = s => Debug.WriteLine(s);


                    return context.Autores // se accede al conjunto de Autores en la tabla de la base de datos
                    .OrderBy(a => a.Nombre) //se ordenan por nombre 
                    .ToList(); // y se convierten en una lista que se devuelve
                }
            }
            catch (Exception ex) // captura cualquier excepción que ocurra durante la operación de base de datos
            {
                string realMessage = ex.InnerException?.InnerException?.Message
                ?? ex.InnerException?.Message //verifica si hay excepciones internas para obtener el mensaje más específico
                ?? ex.Message;


                Debug.WriteLine("Error Listar Autores: " + realMessage); // escribe el mensaje de error en la salida de depuración
                throw new Exception("Listar autores error: " + realMessage, ex);
            }
        }
        public Autor BuscarPorId(int id) // este mwtodo busca un autor por su ID y devuelve el objeto Autor correspondiente o null si no se encuentra
        {
            try // primero intenta ejecutar el bloque de código dentro del try
            {
                using (var context = new NoticieroContext()) 
                {
                    context.Database.Log = s => Debug.WriteLine(s);


                    return context.Autores
                    .FirstOrDefault(a => a.IdAutor == id);
                }
            }
            catch (Exception ex) //si no puede ejecutar el bloque de código dentro del try, tira la excepción
            {
                string realMessage = ex.InnerException?.InnerException?.Message
                ?? ex.InnerException?.Message
                ?? ex.Message;


                Debug.WriteLine("Error BuscarPorId Autor: " + realMessage);
                throw new Exception("BuscarPorId error: " + realMessage, ex);
            }
        }
        public void Insertar(Autor autor) // este método inserta un nuevo autor en la base de datos
        {
            try
            {
                using (var context = new NoticieroContext())
                {
                    context.Database.Log = s => Debug.WriteLine(s);


                    context.Autores.Add(autor); // se agrega el autor al conjunto de Autores la tabal de la base de datos
                    context.SaveChanges(); //se guardan los cambios
                }
            }
            catch (Exception ex)
            {
                string realMessage = ex.InnerException?.InnerException?.Message
                ?? ex.InnerException?.Message
                ?? ex.Message;


                Debug.WriteLine("Error Insertar Autor: " + realMessage);
                throw new Exception("Insertar error: " + realMessage, ex);
            }
        }
        public void Actualizar(Autor autor) // este método actualiza un autor existente en la base de datos
        {
            try
            {
                using (var context = new NoticieroContext())
                {
                    context.Database.Log = s => Debug.WriteLine(s);


                    context.Entry(autor).State = EntityState.Modified; //marca la entidad autor como modificada en el contexto de la base de datos
                    context.SaveChanges(); //y se guardan los cambios realizados
                }
            }
            catch (Exception ex)
            {
                string realMessage = ex.InnerException?.InnerException?.Message
                ?? ex.InnerException?.Message
                ?? ex.Message;


                Debug.WriteLine("Error Actualizando Autor: " + realMessage);
                throw new Exception("Actualizar error: " + realMessage, ex);
            }
        }
        public void Eliminar(int id) // este método elimina un autor de la base de datos por su ID
        {
            try
            {
                using (var context = new NoticieroContext())
                {
                    context.Database.Log = s => Debug.WriteLine(s);


                    var autor = context.Autores.Find(id);//se busca el autor por su ID
                    if (autor != null) //si se encuentra el autor, se elimina de la base de datos
                    {
                        context.Autores.Remove(autor);
                        context.SaveChanges(); //y se guardan los cambios
                    }
                }
            }
            catch (Exception ex)
            {
                string realMessage = ex.InnerException?.InnerException?.Message
                ?? ex.InnerException?.Message
                ?? ex.Message;


                Debug.WriteLine("Error Eliminar Autor: " + realMessage);
                throw new Exception("Eliminar error: " + realMessage, ex);
            }
        }
    }
}