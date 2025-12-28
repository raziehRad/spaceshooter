using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Model", menuName = "Enemy Model")]
public class EnemyModel : ScriptableObject
{
    public int hp = 3;            // Health of the enemy
    public float speed = 3f;      // Speed of the enemy
    public int damage = 1;        // Damage dealt by the enemy (default value set to 1)
    public int Score = 1;         //score you get with kill the enemy
}
