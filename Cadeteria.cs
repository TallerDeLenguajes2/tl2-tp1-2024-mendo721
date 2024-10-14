
namespace cadeteria;

    public class Cadeteria
    {
        private string nombre;
        private string tel;
        private List<Cadete> listadoCadetes;

        private List<Pedido> listadoPedidos;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => tel; set => tel = value; }

        public List<Cadete> ListadoCadetes {get => listadoCadetes; set => listadoCadetes = value; }
        public List<Pedido> ListadoPedidos {get => listadoPedidos; set => listadoPedidos = value; }
        public Cadeteria(string nombre, string telefono)
        {
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.listadoCadetes = new List<Cadete>();
            this.listadoPedidos = new List<Pedido>();
        }
        public Cadeteria (){

        }
        public string AgregarCadete(Cadete cadete)
            {
                ListadoCadetes.Add(cadete);
                return $"Cadete {cadete.Nombre} agregado exitosamente.";
            }

    public string EliminarCadete(int idCadete)
        {
            Cadete cadete = ListadoCadetes.FirstOrDefault(c => c.Id == idCadete);
            if (cadete == null)
            {
                return "Cadete no encontrado.";
            }
            ListadoCadetes.Remove(cadete);
            return $"Cadete {cadete.Nombre} eliminado exitosamente.";
        }

        public int JornalACobrar(int idCadete)
        {
            Cadete cadeteSeleccionado = ListadoCadetes.FirstOrDefault(c => c.Id == idCadete);

            if (cadeteSeleccionado == null)
            {
                return 0;  // Retornamos 0 si no se encuentra el cadete
            }

            List<Pedido> pedidosDelCadete = ListadoPedidos
                .Where(p => p.Cadete != null && p.Cadete.Id == idCadete)
                .ToList();

            return pedidosDelCadete.Count * 500;
        }
        public string AsignarCadeteAPedido(int idCadete, int idPedido)
        {
            Cadete cadeteSeleccionado = ListadoCadetes.FirstOrDefault(c => c.Id == idCadete);
            if (cadeteSeleccionado == null)
            {
                return "Cadete no encontrado.";
            }

            Pedido pedidoSeleccionado = ListadoPedidos.FirstOrDefault(p => p.Nro == idPedido);
            if (pedidoSeleccionado == null)
            {
                return "Pedido no encontrado.";
            }

            pedidoSeleccionado.Cadete = cadeteSeleccionado;
            return $"El cadete {cadeteSeleccionado.Nombre} ha sido asignado al pedido {pedidoSeleccionado.Nro}.";
        }
        public string ReasignarCadeteAPedido(int nroPedido, int idNuevoCadete)
        {
            Pedido pedido = ListadoPedidos.FirstOrDefault(p => p.Nro == nroPedido);
            if (pedido == null)
            {
                return "Pedido no encontrado.";
            }

            Cadete nuevoCadete = ListadoCadetes.FirstOrDefault(c => c.Id == idNuevoCadete);
            if (nuevoCadete == null)
            {
                return "Cadete no encontrado.";
            }

            string mensaje = $"El pedido {pedido.Nro} estaba asignado al cadete {pedido.Cadete?.Nombre ?? "ninguno"}. Reasignando al nuevo cadete {nuevoCadete.Nombre}...";
            pedido.Cadete = nuevoCadete;
            return $"{mensaje} Pedido {pedido.Nro} reasignado al cadete {nuevoCadete.Nombre} exitosamente.";
        }
        
    }