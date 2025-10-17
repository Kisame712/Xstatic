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
    }

    private void UpdateHealthBar()
    {
        healthImage.fillAmount = healthSystem.GetHealthNormalized();
    }

    private void HealthSystem_OnDamageTaken(object sender, EventArgs e)
    {
        UpdateHealthBar();
    }
}
