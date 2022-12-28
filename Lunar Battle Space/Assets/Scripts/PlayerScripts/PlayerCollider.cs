using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField]
    Player player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BulletEnemy"))
            player.GetDamage(5);

        if (collision.gameObject.CompareTag("Enemy"))
            player.GetDamage(10);
    }
}
