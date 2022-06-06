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


    //private string userID;
    // Start is called before the first frame update
    void Start()
    {
        // userID = SystemInfo.deviceUniqueIdentifier;
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        mDatabaseRef.KeepSynced(true);
    }
}
