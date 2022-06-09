using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrearLibro : MonoBehaviour
{

    public InputField libroID;
    public InputField nombreLibro;
    public InputField editorialLibro;
    public InputField fecha_publicacion;
    public InputField numeropaginas;


    public InputField codigoAutor;

    public Text codigoAutor_Invisible;
    public Text nombre_autor_visible;

    public Text nombreAutorListar;

    DatabaseReference mDatabaseRef;

    

    [SerializeField]
    public Text error;
    private bool activarMensaje;
    public Text exito;

    // Start is called before the first frame update
    void Start()
    {
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        ListarUsuarios();
        error.gameObject.SetActive(false);
        exito.gameObject.SetActive(false);

    }


    public void MostrarMensajeError()
    {
        activarMensaje = true;
        error.text = "El Autor no existe";
        error.gameObject.SetActive(true);
    }

    public void MostrarMensajeExito()
    {
        activarMensaje = true;
        exito.text = "Fue Creado Exitosamente";
        exito.gameObject.SetActive(true);
    }

    public IEnumerator GetID(Action<string> onCallBack)
    {
        var usuarioID = mDatabaseRef.Child("Usuarios").Child(codigoAutor.text).Child("userID").GetValueAsync();
        yield return new WaitUntil(predicate: () => usuarioID.IsCompleted);


        if (usuarioID != null)
        {
            DataSnapshot datos = usuarioID.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }
    }

    public IEnumerator GetNombreAutor(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Usuarios").Child(codigoAutor.text).Child("nombre").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);

        if (userNombre != null)
        {
            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }

    }
    public void ListarUsuarios()
    {
        //MostrarMensajeError();

        StartCoroutine(GetID((string autorID) =>
        {
            codigoAutor_Invisible.ToString();
            codigoAutor_Invisible.text = autorID;
        }));

        StartCoroutine(GetNombreAutor((string nombre) =>
        {
            nombre_autor_visible.ToString();
            nombre_autor_visible.text = nombre;
        }));
    }

    private void OnGUI()
    {
        if (activarMensaje)
        {
            if (Input.anyKeyDown)
            {
                LimpiarMensaje();
                LimpiarDatos();
            }
        }

    }

    //Metodo para limpiar datos
    public void LimpiarDatos()
    {
        libroID.text = "";
        nombreLibro.text = "";
        editorialLibro.text = "";
        fecha_publicacion.text = "";
        numeropaginas.text = "";
        codigoAutor.text = "";
        nombre_autor_visible.text = "";
    }

    private void LimpiarMensaje()
    {
        activarMensaje = false;
        exito.gameObject.SetActive(false);
        error.gameObject.SetActive(false);
    }

    public void CrearLibros()
    {

        if(codigoAutor.text == codigoAutor.text)
        {
            Libros libro = new Libros(libroID.text, nombreLibro.text, editorialLibro.text, fecha_publicacion.text, numeropaginas.text, codigoAutor.text);
            //Usuario user = new Usuario("1", "Juan", "Carlos", "0978563423", "juan@gmail.com");
            string json = JsonUtility.ToJson(libro);
            mDatabaseRef.Child("Libros").Child(libroID.text).SetRawJsonValueAsync(json);
            MostrarMensajeExito();
        }
        else
        {
            MostrarMensajeError();
        }

        
    }

    public IEnumerator GetNombreLibro(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Libros").Child(libroID.text).Child("nombreLibro").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);

        if (userNombre != null)
        {

            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }
    }

    public IEnumerator GetEditorialLibro(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Libros").Child(libroID.text).Child("editorialLibro").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);

        if (userNombre != null)
        {

            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }
    }

    public IEnumerator GetFecha(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Libros").Child(libroID.text).Child("fechadepublicacion").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);

        if (userNombre != null)
        {

            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }
    }

    public IEnumerator GetNumero(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Libros").Child(libroID.text).Child("numero_paginas").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);

        if (userNombre != null)
        {

            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }
    }

    public IEnumerator GetCodigoAutor(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Libros").Child(libroID.text).Child("codigo_autor").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);

        if (userNombre != null)
        {

            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }
    }

    public void MostrarNombreLibro()
    {
        StartCoroutine(GetNombreLibro((string nombrelibro) =>
        {
            nombreLibro.ToString();
            nombreLibro.text = nombrelibro;
        }));

        StartCoroutine(GetEditorialLibro((string edilibro) =>
        {
            editorialLibro.ToString();
            editorialLibro.text = edilibro;
        }));

        StartCoroutine(GetFecha((string fecha) =>
        {
            fecha_publicacion.ToString();
            fecha_publicacion.text = fecha;
        }));

        StartCoroutine(GetNumero((string numero) =>
        {
            numeropaginas.ToString();
            numeropaginas.text = numero;
        }));

        StartCoroutine(GetCodigoAutor((string autorcod) =>
        {
            codigoAutor.ToString();
            codigoAutor.text = autorcod;
        }));

    }

    // Update is called once per frame
    void Update()
    {
        //CrearLibros();
    }
}
