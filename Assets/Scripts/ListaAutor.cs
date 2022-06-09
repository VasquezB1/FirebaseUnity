using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListaAutor : MonoBehaviour
{
    public InputField codigoautor;

    public Text codigoautor_invisible;

    public Text nombreAutor;

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

    public IEnumerator GetNombre(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Usuarios").Child(codigoautor.text).Child("nombre").GetValueAsync();

        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);


        if (userNombre != null)
        {

            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());
        }

    }

    public IEnumerator GetID(Action<string> onCallBack)
    {
        var usuarioID = mDatabaseRef.Child("Usuarios").Child(codigoautor.text).Child("userID").GetValueAsync();
        yield return new WaitUntil(predicate: () => usuarioID.IsCompleted);


        if (usuarioID != null)
        {
            DataSnapshot datos = usuarioID.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }
    }

    public void ListarUsuarios()
    {
        StartCoroutine(GetNombre((string nombre) =>
        {
            nombreAutor.ToString();
            nombreAutor.text = nombre;
        }));

        StartCoroutine(GetID((string id) =>
        {
            codigoautor_invisible.ToString();
            codigoautor_invisible.text = id;
        }));
    }
}
