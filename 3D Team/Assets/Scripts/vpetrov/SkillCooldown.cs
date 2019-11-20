using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooldown : MonoBehaviour
{
    public List<Skill> skills;
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(skills[0].currentCooldown>=skills[0].cooldown)
            {
                skills[0].currentCooldown = 0;
            }        
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (skills[1].currentCooldown >= skills[1].cooldown)
            {
                skills[1].currentCooldown = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (skills[2].currentCooldown >= skills[2].cooldown)
            {
                skills[2].currentCooldown = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (skills[3].currentCooldown >= skills[3].cooldown)
            {
                skills[3].currentCooldown = 0;
            }
        }
    }
    void Update()
    { 
        foreach(Skill s in skills)
        {
            if (s.currentCooldown >= s.cooldown)
            {
                s.cooldownIcon.fillAmount = 0;
                s.cooldownText.text = s.cooldown.ToString();
            }
            if (s.currentCooldown < s.cooldown)
            {
                s.currentCooldown += Time.deltaTime;
                s.cooldownIcon.fillAmount = s.currentCooldown / s.cooldown;
                s.cooldownText.text = (s.cooldown-s.currentCooldown).ToString();
            }
            
        }
    }
}

[System.Serializable]
public class Skill
{
    public float cooldown;
    public Image cooldownIcon;
    public Text cooldownText;
    [HideInInspector]
    public float currentCooldown;
}
