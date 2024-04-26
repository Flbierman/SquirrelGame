using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;
/// <summary>
/// Two things that will contact must both have a collider, the attack should be a collider set to isTrigger, and one must have a rigidbody. The player has a rigid body and characterController (that counts a trigger) for this purpose. When you attach the attack, make sure to add an isTrigger collider
/// </summary>
public class HitPoints : MonoBehaviour
{
    public int maxHP = 3;
    public int currentHP = 3;
    private bool isDead = false;
    private UnityEngine.Vector3 spawnPoint; //spawnPoint is captured as the player characters starting position as the level loads, can be updated throguh code later
    private UnityEngine.Vector3 originalScale;
    private MeshRenderer rendererB;
    private Color originalColor;
    private CharacterController characterController;

    //Our logic is handled a bit backwards here, if the HP owning object touches something with an attack, this object takes damage
    private void OnTriggerEnter(Collider collision)
    {
        //TODO: This should be changed to a tryget pattern durring refactor.
        Attack other = collision.gameObject.GetComponent<Attack>();
        if (other != null)
        {
            currentHP -= other.damage;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rendererB = GetComponentInChildren<MeshRenderer>();
        originalColor = rendererB.material.color;
        originalScale = transform.localScale;
        characterController = GetComponent<CharacterController>();
        spawnPoint = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!isDead)
        {
            //turning off player control and flag dead
            characterController.enabled = false;
            isDead = true;
            //Death animation
            rendererB.material.color = Color.red;
            transform.localScale = new UnityEngine.Vector3(originalScale.x, 0.1f, originalScale.z);

            //TODO: when adding a death screen, some logic might go here
            //Send player died flag
            //leave room for level reset or UI logic

            //time delay
            //place player back at level start/other save point?
            StartCoroutine(RespawnAfterDelay(2.0f));
        }
    }

    //This method resets the character after a given amount of time, can probably be refactored into a single method to make sure everything is set back to default.
    IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.localScale = originalScale;
        transform.position = spawnPoint;
        characterController.enabled = true;
        currentHP = maxHP;
        isDead = false;
        rendererB.material.color = originalColor;
    }
}
