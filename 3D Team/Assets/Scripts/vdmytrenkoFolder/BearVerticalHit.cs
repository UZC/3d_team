using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearVerticalHit : MonoBehaviour
{

    public int damage;
    [SerializeField]
    protected Health target;
    public float attackCooldown;
    public GameObject particle;
    public float beforeAttackTime;
    Attack ob;
    public SkillCooldown sc;
    private void Start()
    {
        ob = this.gameObject.AddComponent<Attack>();
        ob.InitAttack(damage, target, attackCooldown, beforeAttackTime, particle, sc);
    }

    public void DoVerticalAttack()
    {
        ob.DoAttack();
    }

}
