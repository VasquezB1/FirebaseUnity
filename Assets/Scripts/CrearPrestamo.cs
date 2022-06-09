using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrearPrestamo : MonoBehaviour
{
    public InputField PrestamoID;
    public InputField numeroPrestamo;
    public InputField fechaPrestamo;
    public InputField cedulaPrestamista;
    public InputField codigoLibro;

    public Text codigo_libroinvisible;
    public Text nombre_libro_invisible;

   

    DatabaseReference mDatabaseRef;
    [SerializeField]
    public Text error;
    private bool activarMensaje;
    public Text exito;


    void Start()
    {
        
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        error.gameObject.SetActive(false);
        exito.gameObject.SetActive(false);

    }

    public void MostrarMensajeError()
    {
        activarMensaje = true;
        error.text = "El Libro no existe";
        error.gameObject.SetActive(true);
    }

    public void MostrarMensajeExito()
    {
        activarMensaje = true;
        exito.text = "Fue Creado Exitosamente";
        exito.gameObject.SetActive(true);
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
        PrestamoID.text = "";
        numeroPrestamo.text = "";
        fechaPrestamo.text = "";
        cedulaPrestamista.text = "";
        codigoLibro.text = "";
        codigo_libroinvisible.text = "";
        nombre_libro_invisible.text = "";
       
    }

    private void LimpiarMensaje()
    {
        activarMensaje = false;
        exito.gameObject.SetActive(false);
        error.gameObject.SetActive(false);
    }



    public void CrearPrestamos()
    {

        if (codigo_libroinvisible.text == codigoLibro.text)
        {
            Prestamo prestamo = new Prestamo(PrestamoID.text, numeroPrestamo.text, fechaPrestamo.text, cedulaPrestamista.text, codigoLibro.text);
            string json = JsonUtility.ToJson(prestamo);
            mDatabaseRef.Child("Prestamos").Child(PrestamoID.text).SetRawJsonValueAsync(json);
            MostrarMensajeExito();
        }
        else
        {
           MostrarMensajeError();
        }


    }



    // Update is called once per frame
    void Update()
    {
        //CrearPrestamos();
    }
}
