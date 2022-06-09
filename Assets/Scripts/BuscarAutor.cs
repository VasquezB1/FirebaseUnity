using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuscarAutor : MonoBehaviour
{
    public Text codigo_autor;
    public Text nombre_autor;

    DatabaseReference mDatabaseRef;
    // Start is called before the first frame update
    void Start()
    {
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public IEnumerator GetNombre(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Usuarios").Child(codigo_autor.text).Child("nombre").GetValueAsync();

        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);


        if (userNombre != null)
        {

            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());
        }

    }

    public void ListarUsuarios()
    {
        StartCoroutine(GetNombre((string nombre) =>
        {
            nombre_autor.ToString();
            nombre_autor.text = nombre;
        }));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
