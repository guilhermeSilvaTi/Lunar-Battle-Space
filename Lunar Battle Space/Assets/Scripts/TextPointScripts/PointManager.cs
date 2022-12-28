using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] pointGroup;

    int currentPoint;
    void Start()
    {
        HydrateGroup();
    }

    private void HydrateGroup()
    {
        pointGroup = GameObject.FindGameObjectsWithTag("Point");
        foreach (var item in pointGroup)
            item.SetActive(false);
    }

    public void CallNewPoint(Vector2 position)
    {    
        StartCoroutine(ShowOffPoint(position, currentPoint));
        if (currentPoint < pointGroup.Length - 1)
            currentPoint++;
        else
            currentPoint = 0;
    }

    private IEnumerator ShowOffPoint(Vector2 position, int value)
    {
        pointGroup[value].transform.position = new Vector2(position.x, position.y);
        pointGroup[value].SetActive(true);
        yield return new WaitForSeconds(0.8f);
        pointGroup[value].SetActive(false);
    }
}
