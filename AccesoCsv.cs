
namespace cadeteria;

public class AccesoCsv : AccesoDatos
{
        public List<Cadete> LeerCadetes(string archivoCsvCadete)
    {
        List<Cadete> listaCadetes = new List<Cadete>();

        string[] lineasCadete = File.ReadAllLines(archivoCsvCadete);
        foreach (string linea in lineasCadete.Skip(1)) // saltar encabezado
        {
            string[] campos = linea.Split(',');
            Cadete cadete = new Cadete(
                int.Parse(campos[0]),
                campos[1],
                campos[2],
                campos[3]
            );
            listaCadetes.Add(cadete);
        }


        return listaCadetes;
    }
    public Cadeteria LeerCadeteria(string archivoCsvCadeteria)
    {
        Cadeteria cadeteria = null;
        // Cargar datos de la cadetería
        string[] lineasCadeteria = File.ReadAllLines(archivoCsvCadeteria);
        string[] encabezados = lineasCadeteria[0].Split(',');
        string[] datos = lineasCadeteria[1].Split(',');
        cadeteria = new Cadeteria(datos[0], datos[1]);
        return cadeteria;
    }


}