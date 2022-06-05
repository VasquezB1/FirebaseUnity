public class Usuario
{
    //public string cedula;
    public string nombre;
    public string apellido;
    public string telefono;
    public string email;

    public Usuario()
    {
    }

    public Usuario(string nombre, string apellido, string telefono, string email)
    {
       // this.cedula = cedula;
        this.nombre = nombre;
        this.apellido = apellido;
        this.telefono = telefono;
        this.email = email;
    }
}
