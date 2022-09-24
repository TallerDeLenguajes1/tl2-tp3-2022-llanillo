namespace TP3;

public class Pedido{

    public int Numero { get; private set; }

    public string Observacion { get; private set; }

    public Estado Estado { get; set; }
    
    public Cliente Cliente { get; private set; }

    public Pedido(int numero, string observacion, Estado estado, Cliente cliente)
    {
        Numero = numero;
        Observacion = observacion;
        Estado = estado;
        Cliente = cliente;
    }

    public override string? ToString()
    {
        return "Número: " + Numero + " Cliente: " + Cliente.Nombre + " Estado: " + (Estado);
    }
}