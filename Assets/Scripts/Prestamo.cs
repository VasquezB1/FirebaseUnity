
public class Prestamo 
{
    public string prestamoID;

    public string numeroPrestamo;
    public string fechaPrestamo;
    public string cedulaPrestamista;
    public string codigo_libro;

    //Constructor de nuestra clase
    public Prestamo()
    {
    }

    public Prestamo(string prestamoID, string numeroPrestamo, string fechaPrestamo, string cedulaPrestamista, string codigo_libro)
    {
        this.prestamoID = prestamoID;
        this.numeroPrestamo = numeroPrestamo;
        this.fechaPrestamo = fechaPrestamo;
        this.cedulaPrestamista = cedulaPrestamista;
        this.codigo_libro = codigo_libro;
    }

}
