using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class HUDManager : MonoBehaviour
{
     [SerializeField]private TextMeshProUGUI  hpTxt;
     [SerializeField]private TextMeshProUGUI  scoreTxt;
     [SerializeField]private TextMeshProUGUI  waveTxt;
     [SerializeField]private GameObject winPanel;
     [SerializeField]private GameObject losePanel;
     [SerializeField]private GameObject startPanel;  
int score;

    void Start(){
         Pause(false);
    }
    public void Pause(bool value){
        value=!value;
       Time.timeScale = value ? 0 : 1;
    }
    public void SetHp(int value)
    {
        if(value<0)value=0;
        hpTxt.text=value.ToString();
    }
    public void SetScore(int value)
    {
        score+=value;
        scoreTxt.text=value.ToString();
    }
      public void SetWave(int value)//kill count
    {
        waveTxt.text=value.ToString();
    }
    public void ActiveWinPanel(){
          Pause(false);
        winPanel.SetActive(true);
    }
     public void ActiveLosePanel(){
          Pause(false);
        losePanel.SetActive(true);
    }
    public void RestartGame(){
        SceneManager.LoadScene(0);
              Pause(true);
    }
    public void Exit(){
        Application.Quit();
    }
    public void PlayGame(){
        startPanel.SetActive(false);
          Pause(true);
    }
}
