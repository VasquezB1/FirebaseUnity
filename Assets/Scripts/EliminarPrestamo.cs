using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EliminarPrestamo : MonoBehaviour
{
    public InputField codigoPrestamo;
    public Text numero_prestamo;
    public Text fecha_prestamo;
    public Text cedula_prestamista;

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

    public IEnumerator GetNumeroPrestamo(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Prestamos").Child(codigoPrestamo.text).Child("numeroPrestamo").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);

        if (userNombre != null)
        {

            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }

    }

    public IEnumerator GetFecha(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Prestamos").Child(codigoPrestamo.text).Child("fechaPrestamo").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);

        if (userNombre != null)
        {

            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }

    }

    public IEnumerator GetCedula(Action<string> onCallBack)
    {
        var userNombre = mDatabaseRef.Child("Prestamos").Child(codigoPrestamo.text).Child("cedulaPrestamista").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNombre.IsCompleted);

        if (userNombre != null)
        {

            DataSnapshot datos = userNombre.Result;
            onCallBack.Invoke(datos.Value.ToString());

        }

    }

    public void ListarPrestamos()
    {
        //MostrarMensajeError();

        StartCoroutine(GetNumeroPrestamo((string numero) =>
        {
            numero_prestamo.ToString();
            numero_prestamo.text = numero;
        }));

        StartCoroutine(GetFecha((string fecha) =>
        {
            fecha_prestamo.ToString();
            fecha_prestamo.text = fecha;
        }));

        StartCoroutine(GetCedula((string cedula) =>
        {
            cedula_prestamista.ToString();
            cedula_prestamista.text = cedula;
        }));
    }

    public void ElimiarDatos()
    {
        Prestamo prestamo = new Prestamo(codigoPrestamo.text, "", "", "", "");
        string json = JsonUtility.ToJson(prestamo);
        mDatabaseRef.Child("Prestamos").Child(codigoPrestamo.text).SetRawJsonValueAsync(json);
       // MostrarMensajeExito();
    }
}
