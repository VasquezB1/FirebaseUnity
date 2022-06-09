using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatosLibros : MonoBehaviour
{

    public Text nombres;
    //public Text nombres;

    DatabaseReference mDatabaseRef;
    // Start is called before the first frame update
    void Start()
    {
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        ListarInfor();
    }

    // Update is called once per frame
    void Update()
    {
        ListarInfor();
    }

    public void ListarInfor()
    {
        mDatabaseRef.Child("Libros").OrderByChild("libroID").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("Data no found");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                // Debug.Log(snapshot.GetRawJsonValue());
                nombres.text = snapshot.GetRawJsonValue();
            }
        });


    }
}
