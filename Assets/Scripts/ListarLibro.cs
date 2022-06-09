using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListarLibro : MonoBehaviour
{
    public InputField codigoLibro;
    public InputField nombrelibro;
    public InputField fecha_publicado;
    public InputField editorial;
    public InputField num_paginas;

    public Text codigo_autor;
    public Text nombre_autor;
    public Text codigo_autor_invisible;

    DatabaseReference mDatabaseRef;
    // Start is called before the first frame update
    void Start()
    {
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
      
        
    }

    public IEnumerator GetID(Action<string> onCallBack)
    {
        var usuarioID = mDatabaseRef.Child("Libros").Child(codigoLibro.text).Child("libroID").GetValueAsync();
        yield return new WaitUntil(predicate: () => usuarioID.IsCompleted);


        if (usuarioID != null)
        {
            DataSnapshot datos = usuarioID.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }
    }

    public IEnumerator GetNombre(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Libros").Child(codigoLibro.text).Child("nombreLibro").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);

        if (userNombre != null)
        {

            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }

    }

    public IEnumerator GetEditorialLibro(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Libros").Child(codigoLibro.text).Child("editorialLibro").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);

        if (userNombre != null)
        {

            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }
    }

    public IEnumerator GetFecha(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Libros").Child(codigoLibro.text).Child("fechadepublicacion").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);

        if (userNombre != null)
        {

            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }
    }

    public IEnumerator GetNumero(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Libros").Child(codigoLibro.text).Child("numero_paginas").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);

        if (userNombre != null)
        {

            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }
    }



    public IEnumerator GetIDAutor(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Libros").Child(codigoLibro.text).Child("codigo_autor").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);

        if (userNombre != null)
        {

            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }
    }

    public IEnumerator GetIDusuario(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Usuarios").Child(codigoLibro.text).Child("userID").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);

        if (userNombre != null)
        {

            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }
    }

    public IEnumerator GetNombreAutor(Action<string> onCallBack)
    {
        
            var userNombre = mDatabaseRef.Child("Usuarios").Child(codigoLibro.text).Child("nombre").GetValueAsync();
            yield return new WaitUntil(predicate: () => userNombre.IsCompleted);

            if (userNombre != null)
            {
                DataSnapshot datos = userNombre.Result;
                onCallBack.Invoke(datos.Value.ToString());
            }
       
    }




        public void ListarLibros()
    {
        //MostrarMensajeError();

        StartCoroutine(GetNombre((string nombre) =>
        {
            nombrelibro.ToString();
            nombrelibro.text = nombre;
        }));

        StartCoroutine(GetEditorialLibro((string edilibro) =>
        {
            editorial.ToString();
            editorial.text = edilibro;
        }));

        StartCoroutine(GetFecha((string fecha) =>
        {
            fecha_publicado.ToString();
            fecha_publicado.text = fecha;
        }));

        StartCoroutine(GetNumero((string numero) =>
        {
            num_paginas.ToString();
            num_paginas.text = numero;
        }));

        StartCoroutine(GetIDAutor((string ida) =>
        {
            codigo_autor.ToString();
            codigo_autor.text = ida;
        }));


        StartCoroutine(GetNombreAutor((string nomb) =>
        {
            codigo_autor_invisible.ToString();
            nombre_autor.text = nomb;
        }));
    }

 

    // Update is called once per frame
    void Update()
    {
        
    }
}
