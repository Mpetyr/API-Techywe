namespace API_Tecnywe.Entities
{
    public class Customer
    {
        /// <summary>
        /// Identificador único del cliente.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Nombre completo del cliente,
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Correo electrónico del cliente.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Lista de pedidos realizados por el cliente.
        /// </summary>
        public List<Order> Orders { get; set; } = new();
    }
}
