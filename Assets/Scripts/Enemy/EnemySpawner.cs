using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyBase[] enemyPrefab;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private Vector2 moveLimit;
    
    private ObjectPool<EnemyBase> enemyPool;
    private List<EnemyBase> activeEnemies = new List<EnemyBase>();

    private void Awake()
    {
        enemyPool = new ObjectPool<EnemyBase>(enemyPrefab, poolSize, transform);
    }

    private void OnEnable()
    {
        GameEvents.OnEnemyKilled += OnEnemyKilled;
        GameEvents.EnemyReturnToPool += ReturnToPool;
    }
    private void OnDisable()
    {
        GameEvents.OnEnemyKilled -= OnEnemyKilled;
        GameEvents.EnemyReturnToPool -= ReturnToPool;
    }
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, 1.5f);
    }

    //spawn enemy repeatly
    private void Spawn()
    {
        var enemy = enemyPool.Get();
        enemy.transform.position = new Vector3(Random.Range(moveLimit.x, moveLimit.y), 0f, 10f);
      
        activeEnemies.Add(enemy);
        GameEvents.OnEnemyPresenceChanged?.Invoke(activeEnemies.Count > 0);
    }
    //enemy killed happen
    private void OnEnemyKilled(EnemyBase enemy)
    {
        activeEnemies.Remove(enemy);
        enemyPool.Return(enemy);
        
        GameEvents.OnEnemyPresenceChanged?.Invoke(activeEnemies.Count > 0);
    }
    // Update is called once per frames

    private void ReturnToPool(EnemyBase enemy)
    {
        enemyPool.Return(enemy);
        activeEnemies.Remove(enemy);
    }
}