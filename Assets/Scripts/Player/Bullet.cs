using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private ObjectPool<Bullet> pool;

    public void Init(ObjectPool<Bullet> pool)
    {
        this.pool = pool;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    //damage to enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyBase>();
            enemy.TakeDamage(enemy.Data.damage);
            pool.Return(this);
        }
        if (other.CompareTag("BackToPool"))
        {
            pool.Return(this);
        }
    }
}