
namespace cadeteria;

    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string tel;
        

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Tel { get => tel; set => tel = value; }
        public Cadete(int id, string nombre, string direccion, string telefono)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Tel = telefono;
        }
        /*
        public void agregarPedido(Pedido pedido){
            listaPedidos.Add(pedido);
        }
        public void eliminarPedido(Pedido pedido){
            listaPedidos.Remove(pedido);
        }
        public void cambiarEstadoPedido(int nroPedido, Estado nuevoEstado)
        {
            var pedido = listaPedidos.FirstOrDefault(p => p.Nro == nroPedido);
            if (pedido != null)
            {
                pedido.cambiarEstado(nuevoEstado);
            }
        }
        public void ListarPedidos()
        {
            foreach (var pedido in listaPedidos)
            {
                pedido.mostrarPedido();
            }
        }
        */
    }
