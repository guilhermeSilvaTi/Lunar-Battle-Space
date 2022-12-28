using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Rigidbody2D rigidbody2DEnemy;
    [SerializeField]
    private BoxCollider2D boxCollider2D;

    [SerializeField]
    private int life = 100;
    private int maxLife = 100;

    [SerializeField]
    private bool active = false;

    [SerializeField]
    private int level = 1;
    [SerializeField]
    private float yPosition;


    private bool faceRight;

    [SerializeField]
    private float velocity = 10;

    [SerializeField]
    EnemiesManager enemiesManager;
  
    [SerializeField]
    int point = 10;

    public bool GetFaceRight() { return faceRight; }

    public float GetVelocity() { return velocity; }
    public float GetYPosition() { return yPosition; }
    public bool IsActive() { return active; }
    public int GetLEvel() { return level; }

    private void Start()
    {
        maxLife = life;
        Physics2D.IgnoreLayerCollision(7, 7, true);

        enemiesManager = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemiesManager>();
    }
    internal void DamageEnemy()
    {
        CheckDamage();
        StartCoroutine(ColorDamage());
        if (life <= 0)
         StartCoroutine(DisabledEnemy());
    }

    private IEnumerator ColorDamage()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
    private void CheckDamage()
    {
        life -= player.GetAtaqueValue();

        switch (life)
        {
            case <= 25: { animator.SetInteger("Enemy", 3); break; }
            case <= 50: { animator.SetInteger("Enemy", 2); break; }
            case <= 75: { animator.SetInteger("Enemy", 1); break; }
        }

        if (life <= 0)
         enemiesManager.GetValuePoint(point, new Vector2(transform.position.x, transform.position.y));
    }

    public void TouchPlayer()
    {
        StartCoroutine(DisabledEnemy());
    }
    public IEnumerator DisabledEnemy()
    {
        animator.SetInteger("Enemy", 4);
        rigidbody2DEnemy.isKinematic = true;
        boxCollider2D.enabled = false;
        yield return new WaitForSeconds(0.8f);
        OnHoldEnemy();
    }
    public void OnHoldEnemy()
    {
        active = false;
        transform.position = new Vector2(-12.41f, -0.27f);
        this.gameObject.SetActive(false);
    }
    internal void TouchBloque()
    {
        if (transform.position.x < player.transform.position.x)
        {
            rigidbody2DEnemy.velocity = new Vector2(GetVelocity() * Time.fixedDeltaTime, rigidbody2DEnemy.velocity.y);
            faceRight = true;
        }
        else
        {
            rigidbody2DEnemy.velocity = new Vector2(-GetVelocity() * Time.fixedDeltaTime, rigidbody2DEnemy.velocity.y);
            faceRight = false;
        }
    }
    public void EnabledEnemy(Vector2 NewPosition)
    {
        this.gameObject.SetActive(true);
        transform.position = NewPosition;
        rigidbody2DEnemy.isKinematic = false;
        active = true;
        animator.SetInteger("Enemy", 0);
        boxCollider2D.enabled = true;
        life = maxLife;
    }
    public void SetFaceRight()
    {
        if (faceRight)
            faceRight = false;
        else
            faceRight = true;
    }
}
