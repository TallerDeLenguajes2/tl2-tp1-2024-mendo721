using cliente;
namespace pedidos
{
    enum Estado
    {
        procesamiento,
        enCamino,
        perdido,
        entregado
    }
    public class Pedido
    {
        private int nro;
        private string obs;
        private Cliente cliente;

        public Pedido(string nombre, string telefono, string direccion, string referencia)
        {
            this.cliente = new Cliente(){Nombre = nombre, Telefono = telefono, Direccion = direccion, Referencia = referencia };
        }

        private enum Estado;

        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        public string verDireccionCliente(){
            return cliente.Direccion;
        }
    }
}