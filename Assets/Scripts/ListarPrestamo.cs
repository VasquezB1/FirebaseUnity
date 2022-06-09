using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListarPrestamo : MonoBehaviour
{
    public InputField PrestamoID;
    public InputField numeroPrestamo;
    public InputField fechaPrestamo;
    public InputField cedulaPrestamista;
    public InputField codigoLibro;

    DatabaseReference mDatabaseRef;

    [SerializeField]
    public Text mensajeExito;
    private bool activarMensaje;
    // Start is called before the first frame update
    void Start()
    {
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        mensajeExito.gameObject.SetActive(false);
    }

    public void MostrarMensajeExito()
    {
        activarMensaje = true;
        mensajeExito.text = "Se actualizo los datos";
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

    public void LimpiarDatos()
    {
        PrestamoID.text = "";
        numeroPrestamo.text = "";
        fechaPrestamo.text = "";
        cedulaPrestamista.text = "";
        codigoLibro.text = "";
    }


    private void LimpiarMensaje()
    {
        activarMensaje = false;
        mensajeExito.gameObject.SetActive(false);
    }


    public IEnumerator GetID(Action<string> onCallBack)
    {
        var prestamoID = mDatabaseRef.Child("Prestamos").Child(PrestamoID.text).Child("prestamoID").GetValueAsync();
        yield return new WaitUntil(predicate: () => prestamoID.IsCompleted);


        if (prestamoID != null)
        {
            DataSnapshot datos = prestamoID.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }
    }

    public IEnumerator GetNumeroPrestamo(Action<string> onCallBack)
    {
        var prestamoID = mDatabaseRef.Child("Prestamos").Child(PrestamoID.text).Child("numeroPrestamo").GetValueAsync();
        yield return new WaitUntil(predicate: () => prestamoID.IsCompleted);


        if (prestamoID != null)
        {
            DataSnapshot datos = prestamoID.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }
    }

    public IEnumerator GetFechaPrestamo(Action<string> onCallBack)
    {
        var prestamoID = mDatabaseRef.Child("Prestamos").Child(PrestamoID.text).Child("fechaPrestamo").GetValueAsync();
        yield return new WaitUntil(predicate: () => prestamoID.IsCompleted);


        if (prestamoID != null)
        {
            DataSnapshot datos = prestamoID.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }
    }

    public IEnumerator GetCedulaPrestamista(Action<string> onCallBack)
    {
        var prestamoID = mDatabaseRef.Child("Prestamos").Child(PrestamoID.text).Child("cedulaPrestamista").GetValueAsync();
        yield return new WaitUntil(predicate: () => prestamoID.IsCompleted);


        if (prestamoID != null)
        {
            DataSnapshot datos = prestamoID.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }
    }

    public IEnumerator GetLibroID(Action<string> onCallBack)
    {
        var prestamoID = mDatabaseRef.Child("Prestamos").Child(PrestamoID.text).Child("codigo_libro").GetValueAsync();
        yield return new WaitUntil(predicate: () => prestamoID.IsCompleted);

        if (prestamoID != null)
        {
            DataSnapshot datos = prestamoID.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }
    }


    public void ListarPrestamos()
    {
        StartCoroutine(GetNumeroPrestamo((string numeroPrestamo2) =>
        {
            numeroPrestamo.ToString();
            numeroPrestamo.text = numeroPrestamo2;
        }));

        StartCoroutine(GetFechaPrestamo((string fecha) =>
        {
            fechaPrestamo.ToString();
            fechaPrestamo.text = fecha;
        }));

        StartCoroutine(GetCedulaPrestamista((string cedula) =>
        {
            cedulaPrestamista.ToString();
            cedulaPrestamista.text = cedula;
        }));

        StartCoroutine(GetLibroID((string libro) =>
        {
            codigoLibro.ToString();
            codigoLibro.text = libro;
        }));
    }

    public void actualizarDatos()
    {
        var usuarioID = mDatabaseRef.Child("Prestamos").Child(PrestamoID.text).Child("prestamoID").GetValueAsync();
        // yield return new WaitUntil(predicate: () => usuarioID.IsCompleted);
        Prestamo prestamo = new Prestamo(PrestamoID.text,numeroPrestamo.text, fechaPrestamo.text, cedulaPrestamista.text,codigoLibro.text);
        string json = JsonUtility.ToJson(prestamo);
        mDatabaseRef.Child("Prestamos").Child(PrestamoID.text).SetRawJsonValueAsync(json);
        MostrarMensajeExito();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
