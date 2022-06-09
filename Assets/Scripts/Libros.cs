using Firebase.Database;
using System;
using System.Collections;
public class Libros
{

    public string libroID;

    public string nombreLibro;
    public string editorialLibro;
    public string fechadepublicacion;
    public string numero_paginas;
    public string codigo_autor;


    // Start is called before the first frame update
    public Libros()
    {

    }
        
    public Libros(string libroID, string nombreLibro, string editorialLibro, string fechadepublicacion, string numero_paginas, string codigo_autor)
    {
        this.libroID = libroID;
        this.nombreLibro = nombreLibro;
        this.editorialLibro = editorialLibro;
        this.fechadepublicacion = fechadepublicacion;
        this.numero_paginas = numero_paginas;
        this.codigo_autor = codigo_autor;
    }

}
