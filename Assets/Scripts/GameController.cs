using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameController Entity for persisting Data between scenes
/// </summary>
public class GameController : MonoBehaviour
{

    public static GameController Instance;

    //Add properties to track on a global scale here, do not make them static, we only need the GC itself to be static, everything else will be accessesing the static instance.
    //Access the properties via GameController.Instance.<propertyName>
    //With this structure we can persist data between scenes. 
    public String fooBar = "FoooooooooooBar!";

    private void Awake(){
        //Prevent multiple GameControllers from spawning
        if (Instance != null){
            Destroy(gameObject);
            return;
        }
        //Assign the first instance of the gameController to do not destroy for persistence.
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //FUTURE REFACTOR
    //I believe that this is where persistence between game sessions should go as well, that is for a future code push
}
