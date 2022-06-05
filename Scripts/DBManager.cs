//Librerias Necesarias
using Firebase;
using Firebase.Database;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DBManager : MonoBehaviour
{
    DatabaseReference mDatabaseRef;

    public InputField userID; //Valor de cedula

    public InputField nombre;
    public InputField apellido;
    public InputField telefono;
    public InputField email;

    public Text nombreListado;
    public Text apellidoListado;
    public Text telefonoListado;
    public Text emailListado;

    [SerializeField]
    public Text mensajeExito;


    private bool activarMensaje;
    //private string userID;
    // Start is called before the first frame update
    void Start()
    {
        // userID = SystemInfo.deviceUniqueIdentifier;
        IniciarDB();
        CrearUsuario();
        ListarUsuarios();

        mensajeExito.gameObject.SetActive(false);
    }

    //Iniciamos nuestra base de datos
    private void IniciarDB()
    {
        // Referencia a la basa de datos
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    //Metodo para creacion de Usuarios
    public void CrearUsuario()
    {
        Usuario user = new Usuario(nombre.text, apellido.text, telefono.text, email.text);
        string json = JsonUtility.ToJson(user);
        mDatabaseRef.Child("Usuarios").Child(userID.text).SetRawJsonValueAsync(json);
        MostrarMensajeExito();
       
    }

    //Metodo que permite mostrar mensajes de exito
    public void MostrarMensajeExito()
    {
        activarMensaje = true;
        mensajeExito.text = "Su usuario fue creado con exito";
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
        nombre.text = "";
        apellido.text = "";
        telefono.text = "";
        email.text = "";
    }

    //Metodo para limpiar mensajes en pantalla
    private void LimpiarMensaje()
    {
        activarMensaje = false;
        mensajeExito.gameObject.SetActive(false);
    }

    //obtenemos los datos de la base de datos

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
            nombreListado.text = "Nombre del usuario es: " +  nombre;
        }));

        StartCoroutine(GetApellido((string apellido) =>
        {
            apellidoListado.text = "Apellido del usuario es: " + apellido;
        }));

        StartCoroutine(GetTelefono((string telefono) =>
        {
            telefonoListado.text = "Telefono del usuario es: " + telefono;
        }));

        StartCoroutine(GetEmail((string email) =>
        {
            emailListado.text = "Email del usuario es: " + email;
        }));
    }


}
