namespace API_Tecnywe.Entities
{
    public class OrderDetail
    {
        /// <summary>
        /// Identificador único del detalle del pedido.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Identificador del pedido al que pertenece el detalle del pedido.
        /// </summary>
        public string OrderId{ get; set; }
        /// <summary>
        /// Identificador del producto incluido en el detalle del pedido.
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// Cantidad del producto incluida en el detalle del pedido.
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Precio unitario del producto incluido en el detalle del pedido.
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// Subtotal del detalle del pedido, calculado como la multiplicación de la cantidad por el precio unitario del producto incluido en el detalle del pedido.
        /// </summary>
        public decimal Subtotal { get; set; }
        /// <summary>
        /// order al que pertenece el detalle del pedido.
        /// </summary>
        public Order Order { get; set; }
        /// <summary>
        /// Producto incluido en el detalle del pedido.
        /// </summary>
        public Product Product { get; set; }
    }
}
