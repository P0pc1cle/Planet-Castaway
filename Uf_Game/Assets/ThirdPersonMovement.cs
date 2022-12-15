using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public float speed = 8.0f;
    public Camera followCamera;
    public float rotationSpeed = 360f;
    public float jumpSpeed = 10f;

    private Rigidbody m_Rb;
    private Vector3 m_CameraPos;
    private float jumpCount = 0;

    // Start is called before the first frame update
    void Awake()
    {
        m_Rb = GetComponent<Rigidbody>();
        m_CameraPos = followCamera.transform.position - transform.position;
        
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

        
        if (Input.GetKeyDown("Jump") && jumpCount == 0)
        {
            m_Rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            jumpCount = 1;
        }
      
        if(hit.gameObject.tag == "Floor")
        {
            jumpCount = 0;
        }  

        if (movement == Vector3.zero)
        {
            return;
        }

       
        

        Quaternion targetRotation = Quaternion.LookRotation(movement);
        targetRotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.fixedDeltaTime);

        m_Rb.MovePosition(m_Rb.position + movement * speed * Time.fixedDeltaTime);
        m_Rb.MoveRotation(targetRotation);
    }

    

    private void LateUpdate()
    {
        followCamera.transform.position = m_Rb.position + m_CameraPos;
    }


}