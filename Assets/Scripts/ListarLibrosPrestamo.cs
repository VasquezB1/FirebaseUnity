using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListarLibrosPrestamo : MonoBehaviour
{

    public InputField codigolibro;

    public Text nombreLibro;

    public Text listarLibrosinvisible;


    DatabaseReference mDatabaseRef;
    // Start is called before the first frame update
    void Start()
    {
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GetID(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Libros").Child(codigolibro.text).Child("libroID").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);

        if (userNombre != null)
        {

            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }

    }

    public IEnumerator GetNombre(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Libros").Child(codigolibro.text).Child("nombreLibro").GetValueAsync();
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
            nombreLibro.ToString();
            nombreLibro.text = nombre;
        }));

        StartCoroutine(GetID((string nombre) =>
        {
            listarLibrosinvisible.ToString();
            listarLibrosinvisible.text = nombre;
        }));
    }


}
