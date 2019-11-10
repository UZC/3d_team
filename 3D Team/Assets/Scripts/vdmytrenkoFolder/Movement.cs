using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidBody;
    public float speed;
    public float rotateSpeed;
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("JoystickHorizontal1"), 0.0f, Input.GetAxis("JoystickVertical1"));
        Move(movement);
        Rotate(rotateSpeed, movement);
        if (Input.GetButtonDown("Xbut1"))
        {
            Debug.Log("X");
        }
        if (Input.GetButtonDown("Sqbut1"))
        {
            Debug.Log("S");
        }
        if (Input.GetButtonDown("Cbut1"))
        {
            Debug.Log("C");
        }
        if (Input.GetButtonDown("Tbut1"))
        {
            Debug.Log("T");
        }
    }
    public void Move(Vector3 direction)
    {
        rigidBody.velocity = direction * speed;
    }
    public void Rotate(float speed, Vector3 movement)
    {
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), speed);
        }
    }

}
