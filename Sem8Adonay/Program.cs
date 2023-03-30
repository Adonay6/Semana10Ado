//using Sem8Adonay.Models;

//using AlmacenContext db = new AlmacenContext();

//Producto product = new Producto();

//Console.Write("Ingrese el nombre del producto -> ");
//product.Nombre = Console.ReadLine();

//Console.Write("Ingrese una descripcion del producto -> ");
//product.Descripcion = Console.ReadLine();

//Console.Write("Ingrese el precio del producto -> ");
//product.Precio = Convert.ToDecimal(Console.ReadLine());

//Console.Write("Ingrese la cantidad de productos existentes -> ");
//product.Stock = Convert.ToInt32(Console.ReadLine());

//db.Productos.Add(product);
//db.SaveChanges();

//var ListProductos = db.Productos.ToList();

//foreach (var i in ListProductos)
//{
//    Console.WriteLine($"\nNombre: {i.Nombre}");
//    Console.WriteLine($"Descripcion: {i.Descripcion}");
//    Console.WriteLine($"Precio: ${i.Precio}");
//    Console.WriteLine($"Stock {i.Stock}");
//}

using Sem8Adonay.Models;
using Sem8Adonay.CRU;

ProdCrud CrudProducto = new ProdCrud();
Producto product = new Producto();

bool continuar = true;
while (continuar)
{

    Console.WriteLine("Menu");
    Console.WriteLine("pulse 1 para insertar un nuevo producto");
    Console.WriteLine("pulse 2 para Actuliazar un producto");
    Console.WriteLine("pulse 3 para eliminar un producto");
    Console.WriteLine("pulse 4 para listar los productos");

    var Menu = Convert.ToInt32(Console.ReadLine());

    switch (Menu)
    {

        case 1:
            int bucle = 1;
            while (bucle == 1)
            {
                Console.WriteLine("ingresa el nombre del producto");
                product.Nombre = Console.ReadLine();
                Console.WriteLine("ingrese la descripcion del producto");
                product.Descripcion = Console.ReadLine();
                Console.WriteLine("ingrese el precio del producto 00.00");
                product.Precio = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("ingrese la cantidad en stock");
                product.Stock = Convert.ToInt32(Console.ReadLine());
                CrudProducto.AgregueProduct(product);
                Console.WriteLine("El producto se agrego correctamente ");
                Console.WriteLine("pulsa 1 para agregar otro producto");
                Console.WriteLine("pulsa 0 para salir");
                bucle = Convert.ToInt32(Console.ReadLine());
            }
            break;

        case 2:
            Console.WriteLine("actualizar datos");
            Console.WriteLine("ingrese el ID a actualizar");
            var ProductoIndividual = CrudProducto.ProductoIndividual(Convert.ToInt32(Console.ReadLine()));
            if (ProductoIndividual == null)
            {
                Console.WriteLine("el producto no extiste");
            }
            else
            {

                Console.WriteLine($"Nombre {ProductoIndividual.Nombre},Descripcion {ProductoIndividual.Descripcion}, Precio {ProductoIndividual.Precio}, Stock{ProductoIndividual.Stock}");
                Console.WriteLine("para actualizar nombre coloca 1");
                Console.WriteLine("para actualizar el apellido coloca el numero 2 ");
                Console.WriteLine("para actualizar la edad presione 3");

                var Lector = Convert.ToInt32(Console.ReadLine());
                if (Lector == 1)
                {
                    Console.WriteLine("ingrese el nombre");
                    ProductoIndividual.Nombre = Console.ReadLine();
                }
                if (Lector == 2)
                {
                    Console.WriteLine("ingrese descripcion");
                    ProductoIndividual.Descripcion = Console.ReadLine();
                }
                if (Lector == 3)
                {
                    Console.WriteLine("Ingrese el precio");
                    ProductoIndividual.Precio = Convert.ToDecimal(Console.ReadLine());
                }
                
                else
                {
                    Console.WriteLine("ingrese el Stock");
                    ProductoIndividual.Stock = Convert.ToInt32(Console.ReadLine());
                }
                CrudProducto.ActualizarProducto(ProductoIndividual, Lector);
            }

            break;
        case 3:
            Console.WriteLine("Ingresa el ID del producto a eliminar");
            var ProductoIndividualD = CrudProducto.ProductoIndividual(Convert.ToInt32(Console.ReadLine()));
            if (ProductoIndividualD == null)
            {
                Console.WriteLine("Este producto no existe");
            }
            else
            {
                Console.WriteLine("Eliminar producto");
                Console.WriteLine($"Nombre {ProductoIndividualD.Nombre},Descripcion{ProductoIndividualD.Descripcion},Precio{ProductoIndividualD.Precio},Stock{ProductoIndividualD.Stock}");
                Console.WriteLine("El producto encontrado es el correcto? Presione 1 para eliminarlo");
                var Lector = Convert.ToInt32(Console.ReadLine());
                if (Lector == 1)
                {
                    var Id = Convert.ToInt32(ProductoIndividualD.Id);
                    Console.WriteLine(CrudProducto.EliminarProducto(Id));
                }
                else
                {
                    Console.WriteLine("Inicia nuevamente");
                }

            }
            break;
            case 4:
            Console.WriteLine("Lista de productos");
            var ListarProductos = CrudProducto.ListarProductos();
            foreach (var iteracionProductos in ListarProductos)
            {
                Console.WriteLine($"{iteracionProductos.Id},{iteracionProductos.Nombre},{iteracionProductos.Descripcion},{iteracionProductos.Precio},{iteracionProductos.Stock}");
            }
            break;


    }



    Console.WriteLine("desea continuar? Presione S para Si N para NO");
    var cont = Console.ReadLine();
    if (cont.Equals("N"))
    {
        continuar = false;
    }
}