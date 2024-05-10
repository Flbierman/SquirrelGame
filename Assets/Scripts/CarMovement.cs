// Script controls car movement

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CarMovement : MonoBehaviour

{
    Rigidbody m_rigidbody; // Physics interaction
    float m_speed; // Holds speed of the car

    private void Start()

    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_speed = 25f; // Set speed of car

    }

    private void Update()
    {
        m_rigidbody.velocity = transform.forward * m_speed; // Moves the car forward
    }
}
