using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
   public CharacterController controller;
    public Transform cam;

    public float jumpForce = 10;
    public float gravity = -9.81f;
    float velocity;

   public float speed = 6f;

   

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1)
        {
<<<<<<< Updated upstream
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.EulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
=======
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
>>>>>>> Stashed changes

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; 
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        velocity += gravity * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity = jumpForce;
        }
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    }
}