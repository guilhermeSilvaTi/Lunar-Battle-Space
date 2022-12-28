using System.Collections;
using UnityEngine;

public class EnemyColider : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HorizonBoard"))
            enemy.SetFaceRight();

        if (collision.gameObject.CompareTag("Shoot"))
            enemy.DamageEnemy();
        if (collision.gameObject.CompareTag("Player"))
          enemy.TouchPlayer();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bloque"))
            enemy.TouchBloque();

    }
}
