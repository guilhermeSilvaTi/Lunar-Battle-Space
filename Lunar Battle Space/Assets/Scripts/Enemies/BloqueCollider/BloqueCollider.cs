
using UnityEngine;

public class BloqueCollider : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HorizonBoard") || collision.gameObject.CompareTag("Bloque"))
            enemy.SetFaceRight();
    }
}
