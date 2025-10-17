using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int health;

    private int maxHealth;

    public event EventHandler OnDamageTaken;

    private void Awake()
    {
        maxHealth = health;
    }

    public void TakeDamage(int damageAmount, bool isPlayer)
    {
        health -= damageAmount;
        OnDamageTaken?.Invoke(this, EventArgs.Empty);

        if(health <= 0)
        {
            if (isPlayer)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            else
            {
                Destroy(gameObject);
            }
        }

    }


    public void RestoreHP()
    {
        health = maxHealth;

    }

    public float GetHealthNormalized()
    {
        return (float)health / maxHealth;
    }

   
}
