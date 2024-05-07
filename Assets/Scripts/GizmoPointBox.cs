using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a simple script to attach to a box trigger that we use to show points, it will render the collider when in the game editor, but not include the code at all in compile or play.
/// </summary>
public class GizmoPointBox : MonoBehaviour
{
    //This is a compiler conditional that will only have this code active in the editor
    #if UNITY_EDITOR
    private void OnDrawGizmos(){
        Collider collider = GetComponent<Collider>();
        if (collider != null){
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(collider.bounds.center, collider.bounds.size);
        }
    }
    #endif
}
