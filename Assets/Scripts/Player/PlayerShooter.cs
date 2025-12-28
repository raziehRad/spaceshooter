using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
   [SerializeField]private Bullet[] bulletPrefab;
   [SerializeField]private Transform firePoint;
   [SerializeField]private float fireRate=0.3f;

   private float nextFireTime;
   private ObjectPool<Bullet> bulletPool;
   private void Start()
    {
        bulletPool=new  ObjectPool<Bullet>(bulletPrefab,20,null);
    }

    // Update is called once per frame
   private void Update()
    {
    
        if(Time.time>= nextFireTime && GameManager.Instance.EnemySpawner.HasEnemy())
        {
            Shoot();
            nextFireTime=Time.time+ fireRate;
        }
    }
    //player shoot when hasenemy in scene
    private void Shoot()
    {
         Bullet bullet=bulletPool.Get();
         bullet.transform.position=firePoint.position;
         bullet.transform.rotation=firePoint.rotation;
         bullet.Init(bulletPool);
    }
}
