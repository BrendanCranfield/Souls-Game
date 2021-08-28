using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int healthLevel = 10;
    public int maxHealth;
    public int currenthealth;

    public HealthSystem healthSystem;

    public static PlayerStats playerStats;

    private void Awake()
    {
        playerStats = this;
    }

    void Start()
    {
        healthSystem = new HealthSystem(maxHealth);
        currenthealth = healthSystem.GetHealth();
    }

    private void Update()
    {
        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
        healthSystem.OnDead += HealthSystem_OnDead;
    }

    private void HealthSystem_OnDead(object sender, System.EventArgs e)
    {
        Debug.Log("Player is dead");
    }

    private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        currenthealth = healthSystem.GetHealth();
    }
}
