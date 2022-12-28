using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody2DEnemy;

    [SerializeField]
    private Enemy enemy;

    private void FixedUpdate()
    {
        if (enemy.GetFaceRight())
            rigidbody2DEnemy.velocity = new Vector2(enemy.GetVelocity() * Time.fixedDeltaTime, rigidbody2DEnemy.velocity.y);
        else
            rigidbody2DEnemy.velocity = new Vector2(-enemy.GetVelocity() * Time.fixedDeltaTime, rigidbody2DEnemy.velocity.y);
    }
}
