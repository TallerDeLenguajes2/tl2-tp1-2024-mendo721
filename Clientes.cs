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
    }
}