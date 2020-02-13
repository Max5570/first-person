using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Transform healthBar;

    public void Start()
    {
        ChangeHealth(0);
    }

    public void ChangeHealth(int value)
    {
        health += value;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0)
        {
            health = 0;
            healthBar.localScale = new Vector3(health / maxHealth, 1f);
            
        }
        healthBar.localScale = new Vector3(health / maxHealth, 1f);

    }

}
