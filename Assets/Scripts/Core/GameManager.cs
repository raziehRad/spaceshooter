using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]private HUDManager hudManager;
    [SerializeField]private EnemySpawner enemySpawner;
    [SerializeField]private int waveCountToWin=30;

    public HUDManager HUDManager=>hudManager;
    public EnemySpawner EnemySpawner=>enemySpawner;
    private void Start()
    {
        Instance=this;
    }
    //check if player killed enemy enough to win
    public bool Checkkills(int waveCount){
        if(waveCount==waveCountToWin)return true;
        return false;
    }
    // pause the game and open win panel 
    public void WinAction(){

        hudManager.ActiveWinPanel();
    }
}
