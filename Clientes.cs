namespace cliente
{
    public class Cliente
    {
        private string nombre;
        private string telefono;
        private string direccion;
        private string referencia;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Referencia { get => referencia; set => referencia = value; }
        public Cliente(string Nombre, string Telefono, string Direccion, string Referencia){
            this.nombre = Nombre;
            this.telefono = Telefono;
            this.direccion = Direccion;
            this.referencia = Referencia;
        }
        public string VerDatosCliente()
        {
            return $"Nombre: {Nombre}, Dirección: {Direccion}, Teléfono: {Telefono}, Datos de referencia: {Referencia}";
        }
    }
}