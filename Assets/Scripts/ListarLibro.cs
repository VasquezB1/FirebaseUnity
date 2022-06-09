using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListarLibro : MonoBehaviour
{
    public InputField codigoLibro;
    public Text codigo_libro_invisible;
    public Text nombreLibrovisible;

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

    public void ListarLibros()
    {
        //MostrarMensajeError();

        StartCoroutine(GetID((string autorID) =>
        {
            codigo_libro_invisible.ToString();
            codigo_libro_invisible.text = autorID;
        }));

        StartCoroutine(GetNombre((string nombre) =>
        {
            nombreLibrovisible.ToString();
            nombreLibrovisible.text = nombre;
        }));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
