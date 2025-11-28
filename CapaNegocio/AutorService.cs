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
        public List<Autor> Listar()
        {
            try
            {
                using (var context = new NoticieroContext())
                {
                    context.Database.Log = s => Debug.WriteLine(s);


                    return context.Autores
                    .OrderBy(a => a.Nombre)
                    .ToList();
                }
            }
            catch (Exception ex)
            {
                string realMessage = ex.InnerException?.InnerException?.Message
                ?? ex.InnerException?.Message
                ?? ex.Message;


                Debug.WriteLine("Error Listar Autores: " + realMessage);
                throw new Exception("Listar autores error: " + realMessage, ex);
            }
        }
        public Autor BuscarPorId(int id)
        {
            try
            {
                using (var context = new NoticieroContext())
                {
                    context.Database.Log = s => Debug.WriteLine(s);


                    return context.Autores
                    .FirstOrDefault(a => a.IdAutor == id);
                }
            }
            catch (Exception ex)
            {
                string realMessage = ex.InnerException?.InnerException?.Message
                ?? ex.InnerException?.Message
                ?? ex.Message;


                Debug.WriteLine("Error BuscarPorId Autor: " + realMessage);
                throw new Exception("BuscarPorId error: " + realMessage, ex);
            }
        }
        public void Insertar(Autor autor)
        {
            try
            {
                using (var context = new NoticieroContext())
                {
                    context.Database.Log = s => Debug.WriteLine(s);


                    context.Autores.Add(autor);
                    context.SaveChanges();
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
        public void Actualizar(Autor autor)
        {
            try
            {
                using (var context = new NoticieroContext())
                {
                    context.Database.Log = s => Debug.WriteLine(s);


                    context.Entry(autor).State = EntityState.Modified;
                    context.SaveChanges();
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
        public void Eliminar(int id)
        {
            try
            {
                using (var context = new NoticieroContext())
                {
                    context.Database.Log = s => Debug.WriteLine(s);


                    var autor = context.Autores.Find(id);
                    if (autor != null)
                    {
                        context.Autores.Remove(autor);
                        context.SaveChanges();
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