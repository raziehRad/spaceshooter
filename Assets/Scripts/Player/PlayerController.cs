using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private Vector2 limitX = new Vector2(-4f, 4f);
    [SerializeField] private Vector2 limitZ = new Vector2(-4f, 4f);
    [SerializeField] private Joystick joystick;

    private PlayerHealth playerHealth;
    private float nextFireTime;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        Debug.Log("playerHealth");
        playerHealth.StartGame();
    }

    private void Update()
    {
        Move();
    }

    //playermovement with direction from joystick
    private void Move()
    {
        var direction = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
        transform.Translate(direction * Time.deltaTime * speed, Space.World);
        ClampPosition();
    }

    //limit movement 
    private void ClampPosition()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, limitX.x, limitX.y);
        pos.z = Mathf.Clamp(pos.z, limitZ.x, limitZ.y);
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            EnemyBase enemy = other.transform.GetComponent<EnemyBase>();
            if (enemy != null)
                playerHealth.TakeDamage(enemy.Data.damage);
        }
    }

    public void SetHealth()
    {
        playerHealth.SetHealth();
    }
}