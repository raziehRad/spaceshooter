using System;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public EnemyModel Data;
    private int health;

    public abstract void Move();

    private void OnEnable()
    {
        health=Data.hp;
    }

    private void FixedUpdate()
    {
        Move();
    }

    //take damage to enemy
    public void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0)
            Die();
    }

    private void Die()
    {
        GameEvents.OnEnemyKilled?.Invoke(this);
        gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BackToPool"))
        {
            GameEvents.EnemyReturnToPool?.Invoke(this);
        }
    }
}