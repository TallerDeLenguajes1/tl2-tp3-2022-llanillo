namespace TP3;

public class Cliente : Persona {
    
    public string DatosReferencia { get; private set; }

    public Cliente(int id, string nombre, string direccion, int telefono, string datosReferencia) : base(id, nombre, direccion, telefono){
        DatosReferencia = datosReferencia;
    }
}