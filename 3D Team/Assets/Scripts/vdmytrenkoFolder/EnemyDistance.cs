using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistance : MonoBehaviour
{

    [SerializeField]
    private GameObject enemy;
    void Start()
    {

    }

    
    void Update()
    {
        
    }

    public float GetDistance()
    {
        return Vector3.Distance(this.transform.position, enemy.transform.position);
    }
    public Health GetEnemy()
    {
        return enemy.GetComponent<Health>();
    }
}
