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

   

    DatabaseReference mDatabaseRef;

    
    void Start()
    {
        
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
       
        
    }

    public void CrearPrestamos()
    {

        if (codigo_libroinvisible.text == codigoLibro.text)
        {
            Prestamo prestamo = new Prestamo(PrestamoID.text, numeroPrestamo.text, fechaPrestamo.text, cedulaPrestamista.text, codigoLibro.text);
            string json = JsonUtility.ToJson(prestamo);
            mDatabaseRef.Child("Prestamos").Child(PrestamoID.text).SetRawJsonValueAsync(json);
           // MostrarMensajeExito();
        }
        else
        {
           // MostrarMensajeError();
        }


    }



    // Update is called once per frame
    void Update()
    {
        CrearPrestamos();
    }
}
