using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EliminarLector : MonoBehaviour
{

    public InputField userID; //Valor de cedula

    public Text nombrePersona;
    public Text apellidoPersona;
    public Text telefonoPersona;
    public Text emailPersona;

    DatabaseReference mDatabaseRef;

    [SerializeField]
    public Text mensajeExito;
    private bool activarMensaje;


    // Start is called before the first frame update
    void Start()
    {

        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        ObtenerDatos();

        mensajeExito.gameObject.SetActive(false);

    }

    public void MostrarMensajeExito()
    {
        activarMensaje = true;
        mensajeExito.text = "El lector fue eliminado correctamente";
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
        nombrePersona.text = "";
        apellidoPersona.text = "";
        telefonoPersona.text = "";
        emailPersona.text = "";
    }

    //Metodo para limpiar mensajes en pantalla
    private void LimpiarMensaje()
    {
        activarMensaje = false;
        mensajeExito.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

    }


    public void ObtenerDatos()
    {
        ListarUsuarios();
    }

    public void eliminarDatos()
    {
        var usuarioID = mDatabaseRef.Child("Usuarios").Child(userID.text).Child("userID").GetValueAsync();
        // yield return new WaitUntil(predicate: () => usuarioID.IsCompleted);
        Usuario user = new Usuario(userID.text, " ", " ", " ", " ");
        string json = JsonUtility.ToJson(user);
        mDatabaseRef.Child("Usuarios").Child(userID.text).SetRawJsonValueAsync(json);
        MostrarMensajeExito();
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
