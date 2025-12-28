using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
   public EnemyModel Data;
   
   public abstract void Move();
  
    private void FixedUpdate()
    {
        Move();
    }
    //take damage to enemy
    public void TakeDamage(int value)
    {
        Data.hp-=value;
        if( Data.hp<=0)Die();
    }
    //die if hp was 0
    private void Die()
    {
       GameManager.Instance.EnemySpawner.OnEnemyKilled(this);
       gameObject.SetActive(false);
    }
}
