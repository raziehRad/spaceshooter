using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyBase[] enemyPrefab;
    [SerializeField] private int poolSize=10;
    [SerializeField] private Vector2 moveLimit;
    private ObjectPool<EnemyBase> enemyPool;
    private List<EnemyBase> activeEnemies =new List<EnemyBase>();
    private bool isLastWave;
    private int waveCount;
    private  void Awake()
    {
        enemyPool= new  ObjectPool<EnemyBase>(enemyPrefab,poolSize,transform);
    }

    private void Start()
    {
        InvokeRepeating(nameof(Spawn),1f,1.5f);
    }
    //spawn enemy repeatly
    private void Spawn()
    {
        if(GameManager.Instance.CheckWave(waveCount))
         { 
             return;
             CancelInvoke(nameof(Spawn));
             isLastWave=true;
         }
         var enemy= enemyPool.Get();
         if(enemy==null)return;
         enemy.transform.position=new Vector3( Random.Range(moveLimit.x,moveLimit.y),0f,10f);
         activeEnemies.Add(enemy);
     }
     //check if there is any enemy
    public bool HasEnemy()
    {
         return activeEnemies.Count>0;
    }
     //enemy killed happen
    public void OnEnemyKilled(EnemyBase enemy)
    {
         activeEnemies.Remove(enemy);
         enemyPool.Return(enemy);
         waveCount++;
         if(GameManager.Instance.CheckWave(waveCount)) GameManager.Instance.WinAction();
         GameManager.Instance.HUDManager.SetWave(waveCount);
    }
    // Update is called once per frame

    public void ReturnToPool(EnemyBase enemy)
    {
         enemyPool.Return(enemy);
    }
}
