using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualizarLibro : MonoBehaviour
{

    public InputField libroID; //Valor de cedula

    public InputField nombreLibrocampo;
    public InputField editorialLibro;
    public InputField fechaPublicacion;
    public InputField numeroPaginas;

    DatabaseReference mDatabaseRef;

    public InputField codigoAutorinvisible;

    [SerializeField]
    public Text mensajeExito;
    
    public Text autorNombre;
    private bool activarMensaje;
    // Start is called before the first frame update
    void Start()
    {
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        
        mensajeExito.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void actualizarDatos()
    {
        var librosID = mDatabaseRef.Child("Libros").Child(libroID.text).Child("libroID").GetValueAsync();
        //yield return new WaitUntil(predicate: () => libroID.IsCompleted);
        Libros libro = new Libros(libroID.text, nombreLibrocampo.text, editorialLibro.text, fechaPublicacion.text, numeroPaginas.text, codigoAutorinvisible.text);
        string json = JsonUtility.ToJson(libro);
        mDatabaseRef.Child("Libros").Child(libroID.text).SetRawJsonValueAsync(json);
        MostrarMensajeExito();
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
        nombreLibrocampo.text = "";
        editorialLibro.text = "";
        fechaPublicacion.text = "";
        numeroPaginas.text = "";
        autorNombre.text = "";
    }


    private void LimpiarMensaje()
    {
        activarMensaje = false;
        mensajeExito.gameObject.SetActive(false);
    }

}
