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
    public SkillCooldown sc;

    bool isAbleToCharge;
    bool isCharging;
    float startY;
    void Start()
    {
        isAbleToCharge = true;
        isCharging = false;
        startY = this.transform.position.y;
    }

    void FixedUpdate()
    {
        if (isCharging)
        {
            if (Vector3.Distance(this.transform.position, enemy.position) >= stopDistance)
            {
                this.transform.position += transform.forward * speed * Time.deltaTime;
                this.transform.position = new Vector3(this.transform.position.x, startY, this.transform.position.z);
            }
            else
            {
                isCharging = false;
            }
        }
    }

    public void ChargeSkill()
    {
        if (Vector3.Distance(this.transform.position, enemy.position) <= minDistance && isAbleToCharge)
        {
            this.transform.LookAt(new Vector3(enemy.position.x, this.transform.position.y, enemy.position.z));
            isCharging = true;
            isAbleToCharge = false;
            sc.StartCooldown(coolDown);
            StartCoroutine(CoolDown());
        }
    }

    public IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDown);
        isAbleToCharge = true;
    }
}
