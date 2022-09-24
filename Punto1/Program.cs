namespace TP3;

public class Program
{
    private static readonly string[] Nombres = { "Pepe", "Juan", "Josué" };
    private static readonly string[] Direcciones = { "Chile 34", "Avellaneda 45" };
    private static readonly string[] Descripciones = { "Bonito", "Feo", "Sabroso" };

    private const int MaximoPedidos = 5;
    private const int MinimoPedidos = 2;
    private const int MaximoTelefono = 9999999;

    private static string NombreCadeteria = "CadeteríaJoderMacho";
    private static long TelefonoCadeteria = 53457349;
    private static Random Random = new Random();

    public static void Main(string[] args)
    {
        var cadetes = new List<Cadete>();
        var clientes = new List<Cliente>();
        var pedidos = new List<Pedido>();
        var cadeteria = new Cadeteria(NombreCadeteria, TelefonoCadeteria, cadetes);

        /*
         * Crea automáticamente N pedidos y N clientes, cada  5 iteraciones crea un cadete
         * con pedidos aleatorios creados hasta ese moemnto
         */
        for (var i = 0; i < Random.Next(MinimoPedidos, MaximoPedidos); i++)
        {
            var cliente = new Cliente(i, Nombres[Random.Next(Nombres.Length)],
                Direcciones[Random.Next(Direcciones.Length)], Random.Next(MaximoTelefono), "");
            var pedido = new Pedido(i, Descripciones[Random.Next(Descripciones.Length)], Estado.Comprado, cliente);
            pedidos.Add(pedido);

            if (i % 5 != 0) continue;
            var cadete = new Cadete(i, Nombres[Random.Next(Nombres.Length)],
                Direcciones[Random.Next(Direcciones.Length)], Random.Next(MaximoTelefono), pedidos);
            cadeteria.Cadetes.Add(cadete);
        }

        try
        {
            foreach (var pedido in pedidos)
            {
                Console.WriteLine("--- Pedido : " + pedido + " ---");
                Console.WriteLine(
                    "Desea cambiar el estado del pedido? (0 - No, 1 - Comprado, 2 - Entregado, 3 - En camino");
                pedido.Estado = (Estado)Convert.ToInt32(Console.ReadLine());

                Console.WriteLine( "¿Desea cambiar el cadete del pedido? (0 - No, 1 - Si (Se escogerá uno aleatorio porque me da flojera)");
                if (Convert.ToInt32(Console.ReadLine()) != 1) continue;
                cadeteria.Cadetes.ForEach(x => x.Pedidos.Remove(pedido));
                cadeteria.Cadetes.ElementAt(Random.Next(cadetes.Count)).Pedidos.Add(pedido);
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex);
        }

        Console.WriteLine("\n--- Pedidos finales ---");
        pedidos.ForEach(x => Console.WriteLine(x));

        Console.WriteLine("--- Total ganado por la cadetería: " + cadeteria.Cadetes.Sum(x => x.JornadaACobrar()) + " ---");
        cadeteria.Cadetes.ForEach(x => Console.WriteLine(" Enviós totales del cadete: " + x.Nombre +
                                                         " es " + x.Pedidos.Count +
                                                         " Total ganado: " + x.JornadaACobrar()));
        Console.WriteLine("Envío promedios por cadete: " + cadeteria.Cadetes.Average(x => x.Pedidos.Count));

    }
}