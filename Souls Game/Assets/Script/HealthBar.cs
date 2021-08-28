using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Souls
{
    public class HealthBar : MonoBehaviour
    {
        public float maxHealth = 100;
        private float currentHealth;
        Slider slider;

        private void Awake()
        {
            slider = GetComponent<Slider>();
        }

        private void Start()
        {
            slider.maxValue = PlayerStats.playerStats.healthSystem.GetHealth();
            slider.value = slider.maxValue;
        }

        private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
        {
            float changeHealth = PlayerStats.playerStats.healthSystem.GetHealth();
            slider.value = Mathf.Lerp(currentHealth, changeHealth, 1f);
        }

        private void Update()
        {
            PlayerStats.playerStats.healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                PlayerStats.playerStats.healthSystem.Damage(100);
            }
        }
    }
}
