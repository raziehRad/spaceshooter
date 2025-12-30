using System;

public static class GameEvents
{
    // Enemy
    public static Action<EnemyBase> OnEnemyKilled;
    public static Action<bool> OnEnemyPresenceChanged;
    public static  Action<EnemyBase> EnemyReturnToPool;
    
    // Score & Kill
    public static Action<int> OnScoreChanged;
    public static Action<int, int> OnKillCountChanged;

    // Player
    public static Action<int> OnHealthChanged;
    public static Action OnPlayerDead;

    // Game
    public static Action<GameState> OnGameStateChanged;
  
}