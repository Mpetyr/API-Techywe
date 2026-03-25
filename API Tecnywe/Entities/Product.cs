namespace API_Tecnywe.Entities
{
    public class Product
    {
        /// <summary>
        /// Identificador único del producto.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Nombre del producto, utilizado para identificarlo y mostrarlo a los usuarios.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Valor del producto
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Cantidad disponible del producto en el inventario, utilizada para gestionar el stock y evitar ventas de productos agotados.
        /// </summary>
        public int Stock { get; set; }
        /// <summary>
        /// Lista de detalles del pedido.
        /// </summary>
        public List<OrderDetail> OrderDetails { get; set; } = new();
    }
}
