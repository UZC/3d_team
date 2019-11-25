using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    [SerializeField]
    Transform enemy;

    public float speed;
    public float coolDown;
    public float minDistance;
    public float stopDistance;

    bool isAbleToCharge;
    bool isCharging;
    void Start()
    {
        isAbleToCharge = true;
        isCharging = false;
    }

    void Update()
    {
        if (isCharging)
        {
            if (Vector3.Distance(this.transform.position, enemy.position) >= stopDistance)
            {
                this.transform.position += transform.forward * speed * Time.deltaTime;
                Debug.Log("doing");
            }
            else
            {
                Debug.Log("done");
                isCharging = false;
            }
        }
    }

    public void ChargeSkill()
    {
        if (Vector3.Distance(this.transform.position, enemy.position) <= minDistance && isAbleToCharge)
        {
            Debug.Log("here");
            this.transform.LookAt(new Vector3(enemy.position.x, this.transform.position.y, enemy.position.z));
            isCharging = true;
            //isAbleToCharge = false;
        }
    }
}
