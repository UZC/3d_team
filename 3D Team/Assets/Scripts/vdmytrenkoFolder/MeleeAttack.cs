using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int damage;
    public float attackRange;
    Health target;
    public float attackCooldown;
    bool isAbleToAttack;
    void Start()
    {
        target = this.GetComponent<EnemyDistance>().GetEnemy();
        isAbleToAttack = true;
    }

    
    void Update()
    {
        
    }

    public void DoAttack()
    {
        if (this.GetComponent<EnemyDistance>().GetDistance() <= attackRange && isAbleToAttack && LookAtEnemy())
        {
            target.TakeDamage(damage);
            StartCoroutine(Cooldown());
            Debug.Log(target.GetHealth());
        }
    }
    private IEnumerator Cooldown()
    {
        isAbleToAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        isAbleToAttack = true;
    }
    private bool LookAtEnemy()
    {
        RaycastHit hit;
        Ray ray = new Ray(this.transform.position, this.transform.forward);

        Physics.Raycast(ray, out hit);

        if (hit.collider != null && (hit.collider.tag == "Player" || hit.collider.tag == "Player2"))
            return true;
        else return false;
        
    }
}
