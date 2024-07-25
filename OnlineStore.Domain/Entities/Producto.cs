

namespace OnlineStore.Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Precio { get; set; }

       // public Producto() { } // Constructor sin parámetros necesario para EF Core

        
        public Producto(int id, string nombre, int precio)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
        }
    }
}
