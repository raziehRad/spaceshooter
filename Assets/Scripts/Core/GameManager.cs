using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState CurrentState { get; private set; }
    private int killCount;
   

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        Time.timeScale =0f;
    }

    private void Pause()
    {
        Time.timeScale = CurrentState == GameState.Playing ? 1f : 0f;
    }
    public void SetState(GameState newState)
    {
        CurrentState = newState;
        Pause();
        GameEvents.OnGameStateChanged?.Invoke(newState);
    }
}

public enum GameState
{
    Playing,
    Paused,
    Win,
    Lose
}