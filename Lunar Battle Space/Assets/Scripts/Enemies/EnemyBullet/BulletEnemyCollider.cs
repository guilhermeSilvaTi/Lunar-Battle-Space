using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shoot") || collision.gameObject.CompareTag("Player"))
            this.gameObject.SetActive(false);
    }
}
