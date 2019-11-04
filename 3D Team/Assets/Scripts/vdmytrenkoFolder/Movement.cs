using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidBody;
    public float speed;
    public float rotationSpeed;
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        
    }
    public void Move(Vector3 direction)
    {
        rigidBody.velocity = direction * speed;
    }

    public void Rotate(Vector3 rotation)
    {
        this.transform.Rotate(rotation * rotationSpeed);
    }
}
