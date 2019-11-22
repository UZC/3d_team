using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInside : MonoBehaviour
{
    private bool canBeAttacked;
    public string tag;
    void Start()
    {
        canBeAttacked = false;
    }


    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tag)
        {
            canBeAttacked = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == tag)
            canBeAttacked = false;
    }

    public bool CanBeAttacked()
    {
        return canBeAttacked;
    }
}
