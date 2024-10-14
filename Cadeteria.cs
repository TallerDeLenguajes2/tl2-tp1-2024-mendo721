
namespace cadeteria;

    public class Cadeteria
    {
        private string nombre;
        private string tel;
        private List<Cadete> listadoCadetes;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Tel { get => tel; set => tel = value; }
        public List<Cadete> ListadoCadetes {get => listadoCadetes; set => listadoCadetes = value; }
        public Cadeteria(string nombre, string telefono)
        {
            this.Nombre = nombre;
            this.Tel = telefono;
            this.listadoCadetes = new List<Cadete>();
        }

        public void agregarCadete(Cadete cadete){
            listadoCadetes.Add(cadete);
        }
        public void eliminarCadete(Cadete cadete){
            listadoCadetes.Remove(cadete);
        }
        public void asignarPedido(Pedido pedido, Cadete cadete){
            cadete.agregarPedido(pedido);
        }
        public void ReasignarPedido(Cadete anterior, Cadete nuevo, Pedido pedido){
        anterior.eliminarPedido(pedido);
        nuevo.agregarPedido(pedido);
    }
    }