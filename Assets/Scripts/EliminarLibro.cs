using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EliminarLibro : MonoBehaviour
{

    public InputField libroID;
    public Text nombreLibro;
    public Text editorialLibro;
    public Text fecha_publicacion;
    public Text numeropaginas;


    public Text codigoAutorinvisible;
    [SerializeField]
    public Text mensajeExito;
    private bool activarMensaje;
    public Text nombreAutor;

    DatabaseReference mDatabaseRef;

    // Start is called before the first frame update
    void Start()
    {
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        mensajeExito.gameObject.SetActive(false);
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

    // Update is called once per frame
    void Update()
    {
        
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
            codigoAutorinvisible.ToString();
            codigoAutorinvisible.text = autorcod;
        }));

        /*StartCoroutine(GetNombre((string nombre) =>
        {
            nombreAutor.ToString();
            nombreAutor.text = nombre;
        }));*/

    }

    public void MostrarMensajeExito()
    {
        activarMensaje = true;
        mensajeExito.text = "El libro fue eliminado correctamente";
        mensajeExito.gameObject.SetActive(true);
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
        nombreLibro.text = "";
        editorialLibro.text = "";
        fecha_publicacion.text = "";
        numeropaginas.text = "";
        codigoAutorinvisible.text = "";
    }

    //Metodo para limpiar mensajes en pantalla
    private void LimpiarMensaje()
    {
        activarMensaje = false;
        mensajeExito.gameObject.SetActive(false);
    }
    public void eliminarDatos()
    {
        var usuarioID = mDatabaseRef.Child("Libros").Child(libroID.text).Child("libroID").GetValueAsync();
        // yield return new WaitUntil(predicate: () => usuarioID.IsCompleted);
        Libros lib = new Libros(libroID.text, " ", " ", " ", " ","");
        string json = JsonUtility.ToJson(lib);
        mDatabaseRef.Child("Libros").Child(libroID.text).SetRawJsonValueAsync(json);
        MostrarMensajeExito();
    }
}
