namespace TP3;

public abstract class Persona{
    
    public int Id { get; private set; }

    public string Nombre { get; private set; }   

    public string Direccion { get; private set; }

    public long Telefono { get; private set; }

    public string DatosReferencia { get; private set; } 

    public Persona (int id, string nombre, string direccion, long telefono){
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
    }
    

}