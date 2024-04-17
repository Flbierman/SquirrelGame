using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Two things that will contact must both have a collider, the attack should be a collider set to isTrigger, and one must have a rigidbody. The player has a rigid body and characterController (that counts a trigger) for this purpose. When you attach the attack, make sure to add an isTrigger collider
/// </summary>
public class HitPoints : MonoBehaviour
{
    public int maxHP = 3;
    public int currentHP = 3;

    private void OnTriggerEnter(Collider collision){
        Attack other = collision.gameObject.GetComponent<Attack>();
        if(other != null){
            currentHP -= other.damage;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
