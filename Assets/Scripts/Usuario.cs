//Declaramos la Clase Usuario la cual sera una de nuestras primeras clases

public class Usuario
{
    //Parametros que usaremos

    public string userID;

    public string nombre;
    public string apellido;
    public string telefono;
    public string email;

    //Constructor de nuestra clase
    public Usuario()
    {
    }

    public Usuario(string userID, string nombre, string apellido, string telefono, string email)
    {
        this.userID = userID;
        this.nombre = nombre;
        this.apellido = apellido;
        this.telefono = telefono;
        this.email = email;
    }


}
