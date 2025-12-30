using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHp = 5;
    private int currentHp;

    public void StartGame()
    {
        currentHp = maxHp;
        SetHealth();
    }


    public void TakeDamage(int value)
    {
        currentHp -= value;
        if (currentHp <= 0)
            GameEvents.OnPlayerDead?.Invoke();
        SetHealth();
    }

    public void SetHealth()
    {
        GameEvents.OnHealthChanged?.Invoke(currentHp);
    }
}