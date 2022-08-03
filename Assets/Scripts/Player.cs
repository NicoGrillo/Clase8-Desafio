using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] [Range(1f, 10f)] float speed = 3F;
    [SerializeField] [Range(0.1f, 1f)] float rotateSpeed = 0.1f;
    [SerializeField] float cameraAxisX = 0f;

    void Update()
    {
        RotatePlayer();

        if (Input.GetKey(KeyCode.W))
        {
            Movement(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Movement(Vector3.back);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Movement(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Movement(Vector3.right);
        }

    }
    private void Movement(Vector3 value)
    {
        transform.Translate(value * speed * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        cameraAxisX += Input.GetAxis("Mouse X");
        //transform.rotation = Quaternion.Euler(0, cameraAxisX * rotateSpeed, 0);
        Quaternion newRotation = Quaternion.Euler(0, cameraAxisX * rotateSpeed, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2f * Time.deltaTime);
    }
}
