using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPos : MonoBehaviour
{
    //movement speed in units per second
    [SerializeField] private float movementSpeed = 5f;

    void Update()
    {
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        //update the position
        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0, verticalInput * movementSpeed * Time.deltaTime);

        //output to log the position change
        Debug.Log(transform.position);
    }
}
