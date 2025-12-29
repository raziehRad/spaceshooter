using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]private HUDManager hudManager;
    [SerializeField]private EnemySpawner enemySpawner;
    [SerializeField]private PlayerController playerController;
    [SerializeField]private int killCountToWin=30;

    public HUDManager HUDManager=>hudManager;
    public EnemySpawner EnemySpawner=>enemySpawner;
    public int KillCountToWin=>killCountToWin;
    private void Start()
    {
        Instance=this;
        playerController.SetHealth();
    }
    //check if player killed enemy enough to win
    public bool Checkkills(int killCount)
    {
        if(killCount==killCountToWin)return true;
        return false;
    }
    // pause the game and open win panel 
    public void WinAction()
    {
        hudManager.ActiveWinPanel();
    }
}
