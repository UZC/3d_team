using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{ 
        public Image healthBar;
        public float currentHealth;
        void Start()
        {
            currentHealth = 1f;
        }

        void Update()
        {
        healthBar.fillAmount = currentHealth;
        if (currentHealth > 1f)
            {
                currentHealth = 1f;
            }
        if (currentHealth < 0)
            {
                currentHealth = 0;
            Death();
            }
        }

        void Death()
        {

        }
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
        }

        public void TakeHeal(float heal)
        {
            currentHealth += heal;
        }
}

