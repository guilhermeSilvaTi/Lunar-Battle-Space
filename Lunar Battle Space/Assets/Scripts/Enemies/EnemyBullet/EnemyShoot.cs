using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;

    float time;
    [SerializeField]
    float timeShootCount =1;

    [SerializeField]
    BulletManager bulletManager;

    void Update()
    {
        time += Time.deltaTime;
        if(time >= timeShootCount)
        {
            bulletManager.ShootActive(new Vector2(transform.position.x, transform.position.y));
            time = 0;
        }
    }
}
