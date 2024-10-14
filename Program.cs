﻿using cadeteria;
class Program
{
    static void Main(string[] args)
    {

        var cadeteria = new Cadeteria();
        var archivoJson = new AccesoJson();
        var archivoCvs = new AccesoCsv();
        Console.WriteLine("elija como cargar los datos\n1:Json\n2:CVS");
        int opcionArchivo = int.Parse(Console.ReadLine());
        if (opcionArchivo == 1){
            cadeteria = archivoJson.LeerCadeteria("cadeteria.json");
            cadeteria.ListadoCadetes = archivoJson.LeerCadetes("cadetes.json");

        }
        if (opcionArchivo == 2){
            cadeteria = archivoCvs.LeerCadeteria("cadeteria.csv");
            cadeteria.ListadoCadetes = archivoCvs.LeerCadetes("cadetes.csv");
        } 

        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("Sistema de Gestión de Pedidos");
            Console.WriteLine("1. Dar de alta un pedido");
            Console.WriteLine("2. Asignar cadete a un pedido");
            Console.WriteLine("3. Cambiar estado de un pedido");
            Console.WriteLine("4. Reasignar un cadete a otro pedido");
            Console.WriteLine("5. Mostrar informe al finalizar la jornada");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    DarDeAltaPedido(cadeteria);
                    break;
                case "2":
                    AsignarPedido(cadeteria);
                    break;
                case "3":
                    CambiarEstadoPedido(cadeteria);
                    break;
                case "4":
                    ReasignarPedido(cadeteria);
                    break;
                case "5":
                    MostrarInforme(cadeteria);
                    break;
                case "6":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Presione Enter para continuar.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void DarDeAltaPedido(Cadeteria cadeteria)
    {
        Console.WriteLine("Dar de alta un pedido");

        Console.Write("Ingrese el número del pedido: ");
        int nro = int.Parse(Console.ReadLine());

        Console.Write("Ingrese las observaciones del pedido: ");
        string obs = Console.ReadLine();

        Console.Write("Ingrese el nombre del cliente: ");
        string nombreCliente = Console.ReadLine();

        Console.Write("Ingrese la dirección del cliente: ");
        string direccionCliente = Console.ReadLine();

        Console.Write("Ingrese el teléfono del cliente: ");
        string telefonoCliente = Console.ReadLine();

        Console.Write("Ingrese los datos de referencia de la dirección del cliente: ");
        string datosReferencia = Console.ReadLine();

        Cliente cliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferencia);
        Pedido pedido = new Pedido(nro, obs, cliente, Estado.procesamiento);

        cadeteria.ListadoPedidos.Add(pedido);
        Console.WriteLine("Pedido creado exitosamente. Presione Enter para continuar.");
        Console.ReadLine();
    }

    static void AsignarPedido(Cadeteria cadeteria)
    {
        Console.WriteLine("Asignar un cadete a un pedido");

        Console.Write("Ingrese el número del pedido: ");
        int nroPedido = int.Parse(Console.ReadLine());

        Console.WriteLine("Cadetes disponibles:");
        foreach (var cadete in cadeteria.ListadoCadetes)
        {
            Console.WriteLine($"{cadete.Id}: {cadete.Nombre}");
        }

        Console.Write("Ingrese el ID del cadete: ");
        int idCadete = int.Parse(Console.ReadLine());

        cadeteria.AsignarCadeteAPedido(idCadete, nroPedido);
        Console.WriteLine("Presione Enter para continuar.");
        Console.ReadLine();
    }

    static void ReasignarPedido(Cadeteria cadeteria)
    {
        Console.WriteLine("Reasignar un cadete a otro pedido");

        Console.Write("Ingrese el número del pedido a reasignar: ");
        int nroPedido = int.Parse(Console.ReadLine());

        Console.WriteLine("Cadetes disponibles:");
        foreach (var cadete in cadeteria.ListadoCadetes)
        {
            Console.WriteLine($"{cadete.Id}: {cadete.Nombre}");
        }

        Console.Write("Ingrese el ID del nuevo cadete: ");
        int idNuevoCadete = int.Parse(Console.ReadLine());

        cadeteria.ReasignarCadeteAPedido(nroPedido, idNuevoCadete);
        Console.WriteLine("Presione Enter para continuar.");
        Console.ReadLine();
    }

    static void CambiarEstadoPedido(Cadeteria cadeteria)
    {
        Console.WriteLine("Cambiar estado de un pedido");

        Console.Write("Ingrese el número del pedido: ");
        int nroPedido = int.Parse(Console.ReadLine());

        Console.WriteLine("Estados disponibles:");
        foreach (var estado in Enum.GetValues(typeof(Estado)))
        {
            Console.WriteLine($"{(int)estado}: {estado}");
        }
        Console.Write("Ingrese el nuevo estado: ");
        Estado nuevoEstado = (Estado)int.Parse(Console.ReadLine());

        foreach (var cadete in cadeteria.ListadoCadetes)
        {
            var pedido = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Nro == nroPedido);
            if (pedido != null)
            {
                pedido.cambiarEstado(nuevoEstado);
                Console.WriteLine("Estado del pedido cambiado exitosamente. Presione Enter para continuar.");
                return;
            }
        }

        Console.WriteLine("Pedido no encontrado. Presione Enter para continuar.");
        Console.ReadLine();
    }



    static void MostrarInforme(Cadeteria cadeteria)
    {
        Console.WriteLine("Informe de pedidos al finalizar la jornada");

        var informeCadetes = cadeteria.ListadoCadetes.Select(c => new
        {
            Cadete = c,
            CantidadEnvios = cadeteria.ListadoPedidos.Count,
            MontoGanado = cadeteria.ListadoPedidos.Count * 100 // Supongamos que cada pedido genera 100 unidades de ganancia
        }).ToList();

        foreach (var item in informeCadetes)
        {
            Console.WriteLine($"Cadete: {item.Cadete.Nombre}, Cantidad de envíos: {item.CantidadEnvios}, Monto ganado: {item.MontoGanado}");
        }

        var totalEnvios = informeCadetes.Sum(x => x.CantidadEnvios);
        var totalGanado = informeCadetes.Sum(x => x.MontoGanado);
        var promedioEnvios = totalEnvios / (double)informeCadetes.Count;

        Console.WriteLine($"Total de envíos: {totalEnvios}");
        Console.WriteLine($"Monto total ganado: {totalGanado}");
        Console.WriteLine($"Promedio de envíos por cadete: {promedioEnvios}");

        Console.WriteLine("Presione Enter para continuar.");
        Console.ReadLine();
    }
}