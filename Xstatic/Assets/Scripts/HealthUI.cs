using UnityEngine;
using UnityEngine.UI;
using System;
public class HealthUI : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private Image healthImage;


    private void Start()
    {
        UpdateHealthBar();
        healthSystem.OnDamageTaken += HealthSystem_OnDamageTaken;
        healthSystem.OnRestoreHP += HealthSystem_OnRestoreHP;
    }

    private void UpdateHealthBar()
    {
        healthImage.fillAmount = healthSystem.GetHealthNormalized();
    }

    private void HealthSystem_OnDamageTaken(object sender, EventArgs e)
    {
        UpdateHealthBar();
    }

    private void HealthSystem_OnRestoreHP(object sender, EventArgs e)
    {
        UpdateHealthBar();
    }
}
