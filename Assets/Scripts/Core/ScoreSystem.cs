using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int score;

    private void OnEnable()
    {
        GameEvents.OnEnemyKilled += AddScore;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyKilled -= AddScore;
    }

    private void AddScore(EnemyBase enemy)
    {
        score += enemy.Data.Score;
        GameEvents.OnScoreChanged?.Invoke(score);
    }
}