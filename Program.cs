﻿using cadeteria;


class Program
{
    static void Main(string[] args)
    {
        // Esta parte puede ser gestionada por un controlador o servicio web
        var cadeteria = new Cadeteria();
        var archivoJson = new AccesoJson();
        var archivoCvs = new AccesoCsv();

        // Ejemplo de cómo se manejarían las entradas
        // Esta lógica estaría en controladores o servicios externos
    }

    // Métodos adaptados para recibir parámetros y devolver resultados

    static string DarDeAltaPedido(Cadeteria cadeteria, int nro, string obs, string nombreCliente, string direccionCliente, string telefonoCliente, string datosReferencia)
    {
        Cliente cliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferencia);
        Pedido pedido = new Pedido(nro, obs, cliente, Estado.procesamiento);

        cadeteria.ListadoPedidos.Add(pedido);
        return "Pedido creado exitosamente.";
    }

    static string AsignarPedido(Cadeteria cadeteria, int nroPedido, int idCadete)
    {
        string resultado = cadeteria.AsignarCadeteAPedido(idCadete, nroPedido);
        return resultado;
    }

    static string ReasignarPedido(Cadeteria cadeteria, int nroPedido, int idNuevoCadete)
    {
        string resultado = cadeteria.ReasignarCadeteAPedido(nroPedido, idNuevoCadete);
        return resultado;
    }

    static string CambiarEstadoPedido(Cadeteria cadeteria, int nroPedido, int nuevoEstadoInt)
    {
        Estado nuevoEstado = (Estado)nuevoEstadoInt;
        var pedido = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Nro == nroPedido);
        if (pedido != null)
        {
            pedido.cambiarEstado(nuevoEstado);
            return "Estado del pedido cambiado exitosamente.";
        }
        return "Pedido no encontrado.";
    }

    static List<object> MostrarInforme(Cadeteria cadeteria)
    {
        var informeCadetes = cadeteria.ListadoCadetes.Select(c => new
        {
            Cadete = c.Nombre,
            CantidadEnvios = cadeteria.ListadoPedidos.Count,
            MontoGanado = cadeteria.ListadoPedidos.Count * 100 // Ajustar el cálculo de ganancia por pedido
        }).ToList();

        return informeCadetes.Cast<object>().ToList();
    }

    // Métodos de carga de archivos (pueden estar en controladores o servicios)
    static Cadeteria CargarDesdeJson(string cadeteriaPath, string cadetesPath)
    {
        var archivoJson = new AccesoJson();
        var cadeteria = archivoJson.LeerCadeteria(cadeteriaPath);
        cadeteria.ListadoCadetes = archivoJson.LeerCadetes(cadetesPath);
        return cadeteria;
    }

    static Cadeteria CargarDesdeCsv(string cadeteriaPath, string cadetesPath)
    {
        var archivoCvs = new AccesoCsv();
        var cadeteria = archivoCvs.LeerCadeteria(cadeteriaPath);
        cadeteria.ListadoCadetes = archivoCvs.LeerCadetes(cadetesPath);
        return cadeteria;
    }
}