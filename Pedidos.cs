using cliente;
namespace pedidos
{
    public enum Estado
    {
        procesamiento,
        enCamino,
        perdido,
        entregado
    }
    public class Pedido
    {
        private int numero;
        private string observacion;
        private Cliente cliente;
        private Estado estado;

        public Pedido(int Numero, string Observacion, Cliente Cliente, Estado Estado)
        {
            this.numero = Numero;
            this.observacion = Observacion;
            this.cliente = Cliente;
            this.estado = Estado;
        }

        

        public int Nro { get => numero; set => numero = value; }
        public string Obs { get => observacion; set => observacion = value; }
        public string verDireccionCliente(){
            return cliente.Direccion;
        }
        public void VerDatosClientes(){
            Console.WriteLine("Los datos del cliente: ");
            Console.WriteLine($"Nombre: {cliente.Nombre}");
            Console.WriteLine($"Telefono: {cliente.Telefono}");
            Console.WriteLine($"Direccion: {cliente.Direccion}");
            Console.WriteLine($"Referencia:", cliente.Referencia);
        }
        public void cambiarEstado(Estado Estado){
            this.estado = Estado;
        }
        public void mostrarPedido()
    {
        Console.WriteLine($"Nro: {numero}");
        Console.WriteLine($"Obs: {observacion}");
        Console.WriteLine($"Cliente: {cliente.VerDatosCliente()}");
        Console.WriteLine($"Estado: {estado}");
    }
    }
}