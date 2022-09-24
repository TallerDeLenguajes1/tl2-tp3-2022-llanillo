namespace TP3;

public class Cadeteria{
    
    public string Nombre { get; private set; }

    public long Telefono { get; private set; }

    public readonly List<Cadete> Cadetes;

    public Cadeteria (string nombre, long telefono, List<Cadete> cadetes){
        Nombre = nombre;
        Telefono = telefono;
        Cadetes = cadetes;
    }
}