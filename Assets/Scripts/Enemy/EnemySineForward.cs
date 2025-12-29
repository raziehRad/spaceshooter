using UnityEngine;

public class EnemySineForward : EnemyBase
{
    [SerializeField] private float frequency = 2f;
    [SerializeField] private float magnitude = 1.5f;

    private float startX;
    private float time;

    private void OnEnable()
    {
        startX = transform.position.x;
        time = 0;
    }

    //move in sin direction to player
    public override void Move()
    {
        time += Time.deltaTime;
        float xOffset = Mathf.Sin(time * frequency) * magnitude;
        float x = startX + xOffset;

        transform.position = new Vector3(x, transform.position.y,
            transform.position.z - Data.speed * Time.deltaTime);

        if (transform.position.z <= -10)
            GameManager.Instance.EnemySpawner.ReturnToPool(this);
    }
}