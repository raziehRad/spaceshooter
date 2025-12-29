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
        if (health <= 0) Die();
    }

    private void Die()
    {
        GameManager.Instance.EnemySpawner.OnEnemyKilled(this);
        gameObject.SetActive(false);
    }

    public void SetHealth()
    {
        health = Data.hp;
    }
}