using Proyecto2_Noticias.CapaDatos;
using Proyecto2_Noticias.CapaDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace Proyecto2_Noticias.CapaNegocio
{
    public class CategoryService
    {
        public List<Categoria> Listar() //este método devuelve una lista de todas las categorías
        {
            try
            {
                using (var context = new NoticieroContext()) 
                {
                    context.Database.Log = s => Debug.WriteLine(s);


                    return context.Categorias
                    .Include(c => c.Noticias)
                    .ToList();
                }
            }
            catch (Exception ex)
            {
                string realMessage = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
                throw new Exception("Listar error: " + realMessage, ex);
            }
        }
        public Categoria BuscarPorId(int id) // este método busca una categoría por su ID y devuelve el objeto Categoria correspondiente o null si no se encuentra
        {
            try
            {
                using (var context = new NoticieroContext())
                {
                    return context.Categorias
                    .Include(c => c.Noticias)
                    .FirstOrDefault(c => c.IdCategoria == id);
                }
            }
            catch (Exception ex)
            {
                string realMessage = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
                throw new Exception("BuscarPorId error: " + realMessage, ex);
            }
        }
        public void Insertar(Categoria categoria) // este método inserta una nueva categoría en la base de datos
        {
            try
            {
                using (var context = new NoticieroContext())
                {
                    context.Categorias.Add(categoria);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string realMessage = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
                throw new Exception("Insertar error: " + realMessage, ex);
            }
        }
        public void Actualizar(Categoria categoria) //este método actualiza una categoría existente en la base de datos
        {
            try
            {
                using (var context = new NoticieroContext())
                {
                    context.Entry(categoria).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string realMessage = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
                throw new Exception("Actualizar error: " + realMessage, ex);
            }
        }
        public void Eliminar(int id) // este método elimina una categoría de la base de datos por su ID
        {
            try
            {
                using (var context = new NoticieroContext())
                {
                    var categoria = context.Categorias.Find(id);
                    if (categoria != null)
                    {
                        context.Categorias.Remove(categoria);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                string realMessage = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
                throw new Exception("Eliminar error: " + realMessage, ex);
            }
        }
    }
}