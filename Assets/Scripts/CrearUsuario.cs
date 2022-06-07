using Firebase;
using Firebase.Database;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CrearUsuario : MonoBehaviour
{

    public InputField userID; //Valor de cedula

    public InputField nombre;
    public InputField apellido;
    public InputField telefono;
    public InputField email;

    public Text usuarioIDListado;
    public Text nombreListado;
    public Text apellidoListado;
    public Text telefonoListado;
    public Text emailListado;

    [SerializeField]
    public Text mensajeExito;
    private bool activarMensaje;

    DatabaseReference mDatabaseRef;
    // Start is called before the first frame update
    void Start()
    {
        
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        //agregarUsuario();
        ListarUsuarios();
        mensajeExito.gameObject.SetActive(false);
    }

    void update()
    {
        agregarUsuario();
    }

    
    public void agregarUsuario()
    {
       /* Usuario user = new Usuario();

        user.nombre = nombre.text;
        user.apellido = apellido.text;*/
 
        //var usuarioID = mDatabaseRef.Child("Usuarios").Child(userID.text).Child("userID").GetValueAsync();
        // yield return new WaitUntil(predicate: () => usuarioID.IsCompleted);
        Usuario user = new Usuario(userID.text, nombre.text, apellido.text, telefono.text, email.text);
        //Usuario user = new Usuario("1", "Juan", "Carlos", "0978563423", "juan@gmail.com");
        string json = JsonUtility.ToJson(user);
        mDatabaseRef.Child("Usuarios").Child(userID.text).SetRawJsonValueAsync(json);
        //mDatabaseRef.Push();
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

    public IEnumerator GetID(Action<string> onCallBack)
    {
        var usuarioID = mDatabaseRef.Child("Usuarios").Child(userID.text).Child("userID").GetValueAsync();

        yield return new WaitUntil(predicate: () => usuarioID.IsCompleted);

        if (usuarioID != null)
        {
            DataSnapshot datos = usuarioID.Result;
            onCallBack.Invoke(datos.Value.ToString());
        }
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

        StartCoroutine(GetID((string usuarioID) =>
        {
            usuarioIDListado.text = "El ID del usuario es: " + usuarioID;
        }));

        StartCoroutine(GetNombre((string nombre) =>
        {
            nombreListado.text = "Nombre del usuario es: " + nombre;
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
