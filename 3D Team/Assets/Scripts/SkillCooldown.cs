using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooldown : MonoBehaviour
{
    float cooldown;
    float currentCooldown;
    public Image cooldownIcon;
    public Text cooldownText;
    bool flagStart;
    void Update()
    {
        if (flagStart)
        {
            if (currentCooldown >= cooldown)
            {
                cooldownIcon.fillAmount = 0;
                cooldownText.text = cooldown.ToString();
                flagStart = false;
            }
            if (currentCooldown < cooldown)
            {
                currentCooldown += Time.deltaTime;
                cooldownIcon.fillAmount = currentCooldown / cooldown;
                cooldownText.text = (cooldown - currentCooldown).ToString();

            }
        }
    }
    public void StartCooldown(float cooldown)
    {
        cooldown = this.cooldown;
        flagStart = true;
    }
}



