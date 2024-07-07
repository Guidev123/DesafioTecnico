using System.Text.Json.Serialization;

namespace DesafioTec.API.Request
{
    public class PedidoRequest
    {
        [JsonIgnore]
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
