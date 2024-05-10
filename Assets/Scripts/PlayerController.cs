using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private CharacterController controller;
    [Space]
    [SerializeField] public float speed = 6f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    public bool grounded = false;
    //States
    private float turnSmoothVelocity;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private bool isInvincible = false;
    public void IncreaseSpeed(float amount)
    {
        speed += amount;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Goal other = collision.gameObject.GetComponent<Goal>();
        if (other != null)
        {
            //TODO: Do something on reaching goal
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        grounded = controller.isGrounded;
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontalMove, 0, verticalMove).normalized;

        // gravity physics make player stick to ground
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Jump button
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }



        if (direction.magnitude >= 0.1f)
        {
            //These lines make the PC face the direction that it is moving  When using another camera setup, remove cam.eulterAngles.y
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //Another camera line, remove when different camera is in existence
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //This line actually moves the controller revert moveDirection >> direction for replacing temp camera
            controller.Move(speed * Time.deltaTime * moveDirection.normalized);
        }
        

        //apply gravity to player
        velocity.y += gravity * Time.deltaTime;
        //move controller with gravity
        controller.Move(velocity * Time.deltaTime);

    }
}
