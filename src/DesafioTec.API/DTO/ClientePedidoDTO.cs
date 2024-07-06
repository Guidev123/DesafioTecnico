namespace DesafioTec.API.DTO
{
    public class ClientePedidoDTO
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<PedidoDTO> Pedidos { get; set; } = [];
    }
}
