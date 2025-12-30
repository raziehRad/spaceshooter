using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpTxt;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI waveTxt;
    [SerializeField] private Slider hpHealth;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject pausePanel;

    private void OnEnable()
    {
        GameEvents.OnScoreChanged += SetScore;
        GameEvents.OnGameStateChanged += HandleGameState;
        GameEvents.OnHealthChanged += SetHp;
        GameEvents.OnKillCountChanged += Setkill;
        GameEvents.OnPlayerDead += HandlePlayerDead;
    }

    private void OnDisable()
    {
        GameEvents.OnScoreChanged -= SetScore;
        GameEvents.OnGameStateChanged -= HandleGameState;
        GameEvents.OnHealthChanged -= SetHp;
        GameEvents.OnKillCountChanged -= Setkill;
        GameEvents.OnPlayerDead -= HandlePlayerDead;
    }

    private void HandleGameState(GameState state)
    {
        winPanel.SetActive(state == GameState.Win);
        losePanel.SetActive(state == GameState.Lose);
        pausePanel.SetActive(state == GameState.Paused);
    }

    private void SetHp(int value)
    {
        if (value < 0) value = 0;
        hpTxt.text = value.ToString();
        hpHealth.value = value;
    }

    private void SetScore(int value)
    {
        scoreTxt.text = value.ToString();
    }

    public void Setkill(int current, int target)
    {
        waveTxt.text = $"{current}/{target}";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        GameManager.Instance.SetState(GameState.Playing);
    }

    private void HandlePlayerDead()
    {
        GameManager.Instance.SetState(GameState.Lose);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        startPanel.SetActive(false);
        GameManager.Instance.SetState(GameState.Playing);
    }

    public void PauseGame()
    {
        GameManager.Instance.SetState(GameState.Paused);
    }
}