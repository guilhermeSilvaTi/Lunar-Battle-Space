using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    Transform[] pointStartShoot;

    [SerializeField]
    GameObject[] shootGetObject;

    [SerializeField]
    List<Shoot> shootList;

    int valueShoot;

    bool activeShoot;

    [SerializeField]
    float timeShootCount = 0.4f;

    int countFire;

    float time;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Player player;

    [Header("Sons Armas")]
    [SerializeField]
    AudioSource[] gunsSound;
    int soundGunUsing;

    [SerializeField]
    Transform target;
    [SerializeField]
    Transform assistantTarget;
    public void ActiveShoot(bool valueActive) { activeShoot = valueActive; }

    private void Start()
    {
        shootGetObject = GameObject.FindGameObjectsWithTag("Shoot");

        for (int i = 0; i < shootGetObject.Length; i++)
        {
            shootList.Add(shootGetObject[i].GetComponent<Shoot>());
            shootGetObject[i].SetActive(false);
        }
    }

    void Update()
    {
        if (player.GetPlayerIsActive())
        {
            RotationWeapon();
            if(Input.GetMouseButton(0))
            ShootingActive();
        }
    }

    void RotationWeapon()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        target.position = new Vector2(direction.x, direction.y);

        transform.right = direction;

        if (mousePosition.x < transform.position.x)
            spriteRenderer.flipY = true;
        else
            spriteRenderer.flipY = false;

    }
   

    private void ShootingActive()
    {
        if (activeShoot)
        {
            time += Time.deltaTime;

            if (time >= timeShootCount)
            {
                Fire();
                time = 0;
            }

        }
    }
    private void Fire()
    {
 
            if (player.GetAtaqueValue() == shootList[valueShoot].GetDamage())
            {
                shootList[valueShoot].transform.position = new Vector2(pointStartShoot[countFire].transform.position.x, pointStartShoot[countFire].transform.position.y);
                shootList[valueShoot].transform.up = pointStartShoot[countFire].up;
                shootList[valueShoot].CallShootStats(true, transform,target, assistantTarget);
                gunsSound[soundGunUsing].Play();
             //   countFire++;
            }

            if (valueShoot < shootList.Count - 1)
                valueShoot++;
            else
                valueShoot = 0;

        countFire = 0;
    }
}
