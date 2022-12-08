using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
   public CharacterController controller;
    public Transform cam;

    int jumpHeight = 10;
    int jumpCount = 0;

   float velocity;
   public float speed = 6f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; 
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && jumpCount == 0)
        {
            GetComponent<Character Controller>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            jumpCount = 1;
        }
   
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag ("Floor"))
        {
            jumpCount = 0;
        }
    }
}
