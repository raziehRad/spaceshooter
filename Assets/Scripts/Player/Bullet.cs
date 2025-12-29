using UnityEngine;

public class Bullet : MonoBehaviour
{
   [SerializeField]private float speed;
   [SerializeField]private ObjectPool<Bullet> pool;
   public void Init( ObjectPool<Bullet> pool)
   {
       this.pool=pool;
   }

   private void Update()
   {
      transform.Translate(Vector3.forward * speed*Time.deltaTime);
      if(transform.position.z>10)
      {
          pool.Return(this);
      }
   }
   //damage to enemy
   private void OnTriggerEnter(Collider other)
   {
     if(other.gameObject.CompareTag("Enemy"))
     { 
          var enemy=  other.GetComponent<EnemyBase>();
          enemy.TakeDamage(1);
          GameManager.Instance.HUDManager.SetScore(enemy.Data.Score);
          pool.Return(this);
     }
   }
}
