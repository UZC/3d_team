using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    int damage;
    Health target;
    float attackCooldown;
    bool isAbleToAttack;

    float beforeAttackTime;

    public void InitAttack(int dm, Health tr, float at_cd, float bf_at_tm)
    {
        isAbleToAttack = true;
        this.damage = dm;
        this.target = tr;
        this.attackCooldown = at_cd;
        this.beforeAttackTime = bf_at_tm;
    }
    public void DoAttack()
    {
        if (isAbleToAttack)
        {
            isAbleToAttack = false;
            this.GetComponent<Movement>().Lock();
            StartCoroutine(BeforeAttackCD());
        }
    }
    protected IEnumerator Cooldown()
    {
        if (this.transform.GetChild(0).GetComponent<EnemyInside>().CanBeAttacked())
        {
            target.TakeDamage(damage);
            Debug.Log(target.GetHealth());
        }
        this.GetComponent<Movement>().Unlock();
        yield return new WaitForSeconds(attackCooldown);
        isAbleToAttack = true;
    }
    protected IEnumerator BeforeAttackCD()
    {
        yield return new WaitForSeconds(beforeAttackTime);
        StartCoroutine(Cooldown());
    }

    public IEnumerator SlowEnemy(float slowTime, float slowValue)
    {
        float startMovSpeed = target.GetComponent<Movement>().speed;
        float startRotSpeed = target.GetComponent<Movement>().rotateSpeed;

        target.GetComponent<Movement>().speed *= (1 - slowValue);
        target.GetComponent<Movement>().rotateSpeed *= (1 - slowValue);

        yield return new WaitForSeconds(slowTime);
        target.GetComponent<Movement>().speed = startMovSpeed;
        target.GetComponent<Movement>().rotateSpeed = startRotSpeed;
    }
}
