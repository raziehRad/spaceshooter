using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyBase[] enemyPrefab;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private Vector2 moveLimit;
    private ObjectPool<EnemyBase> enemyPool;
    private List<EnemyBase> activeEnemies = new List<EnemyBase>();
    private int killCount;

    private void Awake()
    {
        enemyPool = new ObjectPool<EnemyBase>(enemyPrefab, poolSize, transform);
    }

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, 1.5f);
    }

    //spawn enemy repeatly
    private void Spawn()
    {
        if (GameManager.Instance.Checkkills(killCount))
        {
            CancelInvoke(nameof(Spawn));
            return;
        }

        var enemy = enemyPool.Get();
        if (enemy == null) return;
        enemy.transform.position = new Vector3(Random.Range(moveLimit.x, moveLimit.y), 0f, 10f);
        enemy.SetHealth();
        activeEnemies.Add(enemy);
    }

    //check if there is any enemy
    public bool HasEnemy()
    {
        return activeEnemies.Count > 0;
    }

    //enemy killed happen
    public void OnEnemyKilled(EnemyBase enemy)
    {
        activeEnemies.Remove(enemy);
        enemyPool.Return(enemy);
        killCount++;
        if (GameManager.Instance.Checkkills(killCount)) GameManager.Instance.WinAction();
        GameManager.Instance.HUDManager.Setkill(killCount);
    }
    // Update is called once per frame

    public void ReturnToPool(EnemyBase enemy)
    {
        enemyPool.Return(enemy);
    }
}