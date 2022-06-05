using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualizarPersona : MonoBehaviour
{

    public InputField userID; //Valor de cedula

    public InputField nombrePersona;
    public InputField apellidoPersona;
    public InputField telefonoPersona;
    public InputField emailPersona;

    DatabaseReference mDatabaseRef;



    // Start is called before the first frame update
    void Start()
    {
        IniciarDB();
        actualizarPersona();

    }

    private void IniciarDB()
    {
        // Referencia a la basa de datos
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void actualizarPersona()
    {
        ListarUsuarios();
    }


    public IEnumerator GetNombre(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Usuarios").Child(userID.text).Child("nombre").GetValueAsync();

        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);


        if (userNombre != null)
        {

            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());
        }

    }

    public IEnumerator GetApellido(Action<string> onCallBack)
    {
        var userApellido = mDatabaseRef.Child("Usuarios").Child(userID.text).Child("apellido").GetValueAsync();

        yield return new WaitUntil(predicate: () => userApellido.IsCompleted);


        if (userApellido != null)
        {

            DataSnapshot datos = userApellido.Result;
            onCallBack.Invoke(datos.Value.ToString());
        }

    }

    public IEnumerator GetTelefono(Action<string> onCallBack)
    {
        var userTelefono = mDatabaseRef.Child("Usuarios").Child(userID.text).Child("telefono").GetValueAsync();

        yield return new WaitUntil(predicate: () => userTelefono.IsCompleted);


        if (userTelefono != null)
        {

            DataSnapshot datos = userTelefono.Result;
            onCallBack.Invoke(datos.Value.ToString());
        }

    }

    public IEnumerator GetEmail(Action<string> onCallBack)
    {
        var userEmail = mDatabaseRef.Child("Usuarios").Child(userID.text).Child("email").GetValueAsync();

        yield return new WaitUntil(predicate: () => userEmail.IsCompleted);


        if (userEmail != null)
        {
            DataSnapshot datos = userEmail.Result;
            onCallBack.Invoke(datos.Value.ToString());
        }

    }



    public void ListarUsuarios()
    {
        StartCoroutine(GetNombre((string nombre) =>
        {
            nombrePersona.ToString();
            nombrePersona.text = nombre;
        }));

        StartCoroutine(GetApellido((string apellido) =>
        {
            apellidoPersona.ToString();
            apellidoPersona.text = apellido;
        }));

        StartCoroutine(GetTelefono((string telefono) =>
        {
            telefonoPersona.ToString();
            telefonoPersona.text = telefono;
        }));

        StartCoroutine(GetEmail((string email) =>
        {
            emailPersona.ToString();
            emailPersona.text = email;
        }));

    }
}
