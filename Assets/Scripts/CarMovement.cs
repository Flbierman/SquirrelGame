using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CarMovement : MonoBehaviour

{
    Rigidbody m_rigidbody;
    float m_speed;

    private void Start()

    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_speed = 25f;

    }

    private void Update()
    {
        m_rigidbody.velocity = transform.forward * m_speed;

        }
    }

