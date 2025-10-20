using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int health;

    private int maxHealth;

    public event EventHandler OnDamageTaken;
    public event EventHandler OnRestoreHP;

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
                CheckpointManager.Instance.RespawnPlayer();
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
        OnRestoreHP?.Invoke(this, EventArgs.Empty);

    }

    public float GetHealthNormalized()
    {
        return (float)health / maxHealth;
    }

   
}
