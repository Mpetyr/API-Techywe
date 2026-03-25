namespace API_Tecnywe.Entities
{
    public class Order
    {
        /// <summary>
        /// Identificador único del pedido.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Identificador del cliente que realizó el pedido.
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// Suma de todos los productos incluidos en el pedido.
        /// </summary>
        public decimal Total { get; set; }
        /// <summary>
        /// Fecha y hora en que se creó el pedido.
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Cliente del pedido.
        /// </summary>
        public Customer Customer { get; set; }
        /// <summary>
        /// Lista de detalles del pedido.
        /// </summary>
        public List<OrderDetail> OrderDetails { get; set; } = new();

    }
}
