namespace TP3;

public class Cadete : Persona
{

    public const int PrecioPorPedido = 300;

    public readonly List<Pedido> Pedidos;

    public Cadete(int id, string nombre, string direccion, long telefono, List<Pedido> pedidos) : base(id, nombre, direccion, telefono)
    {
        Pedidos = pedidos;
    }

    public void ListadoPedidos()
    {
        foreach (var pedido in Pedidos)
        {
            Console.WriteLine("Número: " + pedido.Numero);
            Console.WriteLine("Observación: " + pedido.Observacion);
        }
    }

    public float JornadaACobrar()
    {
        return Pedidos.Where(x => x.Estado == Estado.Entregado).ToList().Count * PrecioPorPedido;
    }
}