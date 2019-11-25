using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class AddForce : MonoBehaviour
{
    
    [SerializeField] private float pushForce;

    private Rigidbody rb;
    
    private void Awake() // Start is called before the first frame update
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Push();
    }


    private void Push()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            rb.AddForce(Vector3.forward * pushForce, ForceMode.Impulse);
        }

    }
}
