using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearUltimate : MonoBehaviour
{
    public int damage;
    [SerializeField]
    protected Health target;
    public float attackCooldown;

    public float beforeAttackTime;
    public float slowDuration;
    public float slowValue;
    Attack ob;
    void Start()
    {
        ob = this.gameObject.AddComponent<Attack>();
        ob.InitAttack(damage, target, attackCooldown, beforeAttackTime);
    }

    public void BearUlti()
    {
        ob.DoAttack();
        StartCoroutine(ob.SlowEnemy(slowDuration, slowValue));
    }
    
}
