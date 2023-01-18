using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //VARIABLES
    [SerializeField] private float sensHorizontal;
    [SerializeField] private float sensVertical;

    //REFERENCES
    private Transform parent;

    private void Start()
    {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensHorizontal * Time.deltaTime;

        float mouseY = Input.GetAxis("Mouse Y") * sensVertical * Time.deltaTime;

        parent.Rotate(Vector3.up, mouseX);

        transform.Rotate(new Vector3(-mouseY * sensVertical, 0, 0));

        if(Camera.main.transform.localEulerAngles.x == 90f)
        {
            print("STOOOOOP");
        }

    }

}
