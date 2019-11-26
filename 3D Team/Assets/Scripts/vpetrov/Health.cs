using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{ 
    public int currentHealth;
    private bool isDead;
    [SerializeField]
    Pause pauseMenu;
        
    void Start()
    {
        isDead = false;
        currentHealth = 100;
    }


    private void OnDeath()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            Invoke("PlaceHolder", 0.1f);
        }
    }
    private void PlaceHolder()
    {
        pauseMenu.StopAndReload();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        OnDeath();
    }       

    public void TakeHeal(int heal)
    {
        currentHealth += heal;
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
    }
    public int GetHealth()
    {
        return currentHealth;
    }
    public bool IsDead()
    {
        return isDead;
    }
}

