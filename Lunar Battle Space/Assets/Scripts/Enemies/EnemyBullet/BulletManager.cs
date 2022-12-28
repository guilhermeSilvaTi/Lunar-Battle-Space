using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    int currentBullet;

    [SerializeField]
    GameObject[] bulletGroup;

    private void Start()
    {
        bulletGroup = GameObject.FindGameObjectsWithTag("BulletEnemy");
        Clean();
    }

    private void Clean()
    {
        foreach (var item in bulletGroup)
            item.SetActive(false);
    }

    public void ShootActive(Vector2 newPosition)
    {
        bulletGroup[currentBullet].transform.position = new Vector2(newPosition.x, newPosition.y);
        bulletGroup[currentBullet].SetActive(true);

        if (currentBullet < bulletGroup.Length - 1)
            currentBullet++;
        else
            currentBullet = 0;
    }
}
