
using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    float velocity = 10;

    [SerializeField]
    Player player;

    [SerializeField]
    Rigidbody2D rigidbody2DShoot;

    [SerializeField]
   private int damage;

    private bool active;

    [SerializeField]
    private float force = 20;
    public bool GetActiveShoot() { return active; }
    public int GetDamage() { return damage; }

    [SerializeField]
    Transform orientationVector;

    [SerializeField] float firingAngle = 45.0f;
    [SerializeField] float gravity = 6.8f;

    private void Start()
    {
       Physics2D.IgnoreLayerCollision(6, 6, true);
    }

    public void CallShootStats(bool value, Transform orientationVector, Transform target,Transform assistantTarget)
    {

        this.gameObject.SetActive(value);
        rigidbody2DShoot.velocity = Vector2.zero;
        float target_Distance = Vector2.Distance(transform.position, target.position);
        assistantTarget.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);
        float elapse_time = 50;

        assistantTarget.transform.Translate(0, (Vy - (gravity * elapse_time)) * 0.0588632f, Vx * 0.0588632f);

        rigidbody2DShoot.AddForce(-assistantTarget.transform.position * force);
    }
    public void DisabledShoot()
    {
        this.gameObject.SetActive(false);
        active = false;
    }

    void OnCollisionEnter2D(Collision2D collPlay)
    {
        if (collPlay.gameObject.CompareTag("Enemy") || collPlay.gameObject.CompareTag("EndBoard"))
        {
            DisabledShoot();
        }
    }
}
