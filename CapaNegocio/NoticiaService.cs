using Proyecto2_Noticias.CapaDatos;
using Proyecto2_Noticias.CapaDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;              

namespace Proyecto2_Noticias.CapaNegocio
{
    public class NoticiaService
    {
        public List<Noticia> Listar() //este método devuelve una lista de todas las noticias
        {
            try
            {
                using (var context = new NoticieroContext())
                {
                    return context.Noticias
                        .Include(n => n.Autor)
                        .Include(n => n.Categoria)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException?.InnerException?.Message ??
                             ex.InnerException?.Message ??
                             ex.Message;

                throw new Exception("Listar Noticias error: " + msg);
            }
        }

        public Noticia BuscarPorId(int id) //este metodo busca una noticia por su ID y devuelve el objeto Noticia correspondiente o null si no se encuentra
        {
            try
            {
                using (var context = new NoticieroContext())
                {
                    return context.Noticias
                        .Include(n => n.Autor)
                        .Include(n => n.Categoria)
                        .FirstOrDefault(n => n.IdNoticia == id);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException?.InnerException?.Message ??
                             ex.InnerException?.Message ??
                             ex.Message;

                throw new Exception("BuscarPorId error: " + msg);
            }
        }

        public void Insertar(Noticia noticia) //este método inserta una nueva noticia en la base de datos
        {
            try
            {
                using (var context = new NoticieroContext())
                {
                    context.Noticias.Add(noticia);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException?.InnerException?.Message ??
                             ex.InnerException?.Message ??
                             ex.Message;

                throw new Exception("Insertar error: " + msg);
            }
        }

        public void Actualizar(Noticia noticia) //este método actualiza una noticia existente en la base de datos
        {
            try
            {
                using (var context = new NoticieroContext())
                {
                    context.Entry(noticia).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException?.InnerException?.Message ??
                             ex.InnerException?.Message ??
                             ex.Message;

                throw new Exception("Actualizar error: " + msg);
            }
        }

        public void Eliminar(int id) //este método elimina una noticia de la base de datos por su ID
        {
            try
            {
                using (var context = new NoticieroContext())
                {
                    var noticia = context.Noticias.Find(id);
                    if (noticia != null)
                    {
                        context.Noticias.Remove(noticia);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException?.InnerException?.Message ??
                             ex.InnerException?.Message ??
                             ex.Message;

                throw new Exception("Eliminar error: " + msg);
            }
        }
    }
}
