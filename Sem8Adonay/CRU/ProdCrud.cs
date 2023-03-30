using Sem8Adonay.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem8Adonay.CRU
{
    internal class ProdCrud
    {
        public void AgregueProduct(Producto ParametroProducto)
        {
            using (AlmacenContext BaseDeDatos = new AlmacenContext())
            {
                Producto product = new Producto();
                product.Nombre = ParametroProducto.Nombre;
                product.Descripcion = ParametroProducto.Descripcion;
                product.Precio = ParametroProducto.Precio;
                product.Stock = ParametroProducto.Stock;
                BaseDeDatos.Add(product);
                BaseDeDatos.SaveChanges();

            }
        }
        public Producto ProductoIndividual(int id)
        {
            using (AlmacenContext db = new AlmacenContext())
            {

                var buscar = db.Productos.FirstOrDefault(x => x.Id == id);

                return buscar;
            }
        }
        public void ActualizarProducto(Producto ParamentroProducto, int Lector)
        {
            using (AlmacenContext db =
                new AlmacenContext())
            {

                var buscar = ProductoIndividual(ParamentroProducto.Id);
                if (buscar == null)
                {
                    Console.WriteLine("El id no existe");
                }
                else
                {
                    if (Lector == 1)
                    {
                        buscar.Nombre = ParamentroProducto.Nombre;
                    }
                    if (Lector == 2)
                    {
                        buscar.Descripcion = ParamentroProducto.Descripcion;
                    }
                    if (Lector == 3)
                    {
                        buscar.Precio = ParamentroProducto.Precio;
                    }
                    else
                    {
                        buscar.Stock = ParamentroProducto.Stock;
                    }

                    db.Update(buscar);
                    db.SaveChanges();
                }
            }
        }
        public string EliminarProducto(int id)
        {
            using (AlmacenContext db =
                    new AlmacenContext())
            {
                var buscar = ProductoIndividual(id);
                if (buscar == null)
                {
                    return "El producto no existe";
                }
                else
                {
                    db.Productos.Remove(buscar);
                    db.SaveChanges();
                    return "El Producto se elimino";
                }

            }
        }
        public List<Producto> ListarProductos()
        {
            using (AlmacenContext db =
                   new AlmacenContext())
            {
                return db.Productos.ToList();
            }

        }

    }
}