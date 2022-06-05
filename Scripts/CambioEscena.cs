using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public bool pasarEscena;
    public int numeroEscena;

    // Start is called before the first frame update
    void Start()
    {
        IniciarDB();
        
    }

    private void IniciarDB()
    {
        // Referencia a la basa de datos

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {
        if (pasarEscena)
        {
            CambiarEscena(numeroEscena);
        }
        
    }


    public void CambiarEscena(int numero)
    {
        SceneManager.LoadScene(numero);
    }
}
