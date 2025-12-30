using UnityEngine;

public class KillCountSystem : MonoBehaviour
{
    [SerializeField] private int killCountToWin = 30;
    private int killCount;

    private void OnEnable()
    {
        GameEvents.OnEnemyKilled += OnEnemyKilled;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyKilled -= OnEnemyKilled;
    }

    private void OnEnemyKilled(EnemyBase enemy)
    {
        killCount++;
        GameEvents.OnKillCountChanged?.Invoke(killCount, killCountToWin);

        if (killCount >= killCountToWin)
            GameManager.Instance.SetState(GameState.Win);
    }
}