using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private Transform hitEffect;
    [SerializeField] private Transform deadEffect;
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
        Instantiate(hitEffect, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);

        if(health <= 0)
        {
            if (isPlayer)
            {
                CheckpointManager.Instance.RespawnPlayer();
            }

            else
            {
                Instantiate(deadEffect, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
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
