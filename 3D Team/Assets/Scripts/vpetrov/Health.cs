using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{ 
        public Image healthBar;
        public decimal currentHealth;
        public bool isDead;
        void Start()
        {
            currentHealth = 100;
            isDead = false;
        }

        void Update()
        {
        healthBar.fillAmount = (float)currentHealth/100;
      
        
        }

        public void OnDeath()
        {
            isDead = true;
        }
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            OnDeath();
        }
    }

        public void TakeHeal(int heal)
        {
            currentHealth += heal;
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
    }
}

