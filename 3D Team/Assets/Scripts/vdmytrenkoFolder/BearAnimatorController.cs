using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAnimatorController : MonoBehaviour
{
    public Animator anim;
    public AnimationClip attack;
    public AnimationClip reverseAttack;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Running()
    {
        anim.SetBool("Run", true);
    }
    public void IsNotRunning()
    {
        anim.SetBool("Run", false);
    }
    public void Attack()
    {
        anim.SetBool("Attack", true);
        StartCoroutine(WaitForAttack());
    }


    public void RoundAttack()
    {
        anim.SetBool("round attack", true);
        StartCoroutine(WaitForRoundAttack());
    }
    public IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(attack.length / 2);
        anim.SetBool("Attack", false);
    }

    public IEnumerator WaitForRoundAttack()
    {
        yield return new WaitForSeconds(reverseAttack.length);
        anim.SetBool("round attack", false);
    }
}
