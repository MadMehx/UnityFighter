using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int MaxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int attackDamage = 5)
    {
        currentHealth -= attackDamage;
        //play hurt animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public int getHealth()
    {
        return currentHealth;
    }

    void Die()
    {
        Debug.Log("The man is down!!");
    }
}
