namespace cadeteria;
public interface AccesoDatos 
{
    List<Cadete> LeerCadetes(string nombreArchivo);
    Cadeteria LeerCadeteria(string nombreArchivo);
}