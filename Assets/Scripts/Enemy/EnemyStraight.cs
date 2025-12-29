using UnityEngine;

public class EnemyStraight : EnemyBase
{

    [SerializeField] private float moveRange=3f;
    [SerializeField] private float moveLimit;

    private float startX;
    private int direction=1;
 
    private void OnEnable()
    {
         startX=transform.position.x;
    }
    public override void Move()
    {
         transform.Translate(Vector3.right*direction * Data.speed *Time.deltaTime );
         if(transform.position.x>=moveLimit ||transform.position.x<=-moveLimit )  direction*=-1;
    }

}
