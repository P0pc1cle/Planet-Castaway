using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    private float speed = 10f;
    private float jumpforce = 8f;
    private float gravity = 10f;
    private Vector3 moveDir = Vector3.zero;


    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
    CharacterController controller = gameObject.GetComponent<CharacterController> ();

        if (controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            moveDir = transform.TransformDirection(moveDir);

            moveDir *= speed;

            if (Input.GetButtonDown("Jump"))
            {
                moveDir.y = jumpforce;
            }
        }

        moveDir.y -= gravity * Time.deltaTime;

        float targetAngle = Mathf.Atan2(moveDir.x, moveDir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

        controller.Move (moveDir * Time.deltaTime);

    }
}
