using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    int damage;
    Health target;
    float attackCooldown;
    bool isAbleToAttack;
    GameObject particle;
    float beforeAttackTime;
    SkillCooldown cooldown;

    public void InitAttack(int dm, Health tr, float at_cd, float bf_at_tm, GameObject particle, SkillCooldown cooldown)
    {
        isAbleToAttack = true;
        this.damage = dm;
        this.target = tr;
        this.attackCooldown = at_cd;
        this.beforeAttackTime = bf_at_tm;
        this.particle = particle;
        particle.gameObject.SetActive(false);
        this.cooldown = cooldown;
    }
    public void InitAttack(int dm, Health tr, float at_cd, float bf_at_tm, GameObject particle)
    {
        isAbleToAttack = true;
        this.damage = dm;
        this.target = tr;
        this.attackCooldown = at_cd;
        this.beforeAttackTime = bf_at_tm;
        this.particle = particle;
        particle.gameObject.SetActive(false);
    }
    public void DoAttack()
    {
        if (isAbleToAttack)
        {
            particle.gameObject.SetActive(true);
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
        if(cooldown != null)
            cooldown.StartCooldown(attackCooldown);
        particle.gameObject.SetActive(false);
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
