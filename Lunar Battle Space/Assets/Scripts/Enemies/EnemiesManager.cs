
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    GameObject[] objectEnemyGet;

    GameObject[] bloqueGetObject;

    List<Enemy> enemiesList = new List<Enemy>();

    [SerializeField]
    Player player;

    [SerializeField]
    int currentEnemy;

    [SerializeField]
    GameManager gameManager;

    float timeRespawn = 0.9f;

    float time = 0;

    [SerializeField]
    TextMeshProUGUI pointText;

    [SerializeField]
    PointManager pointManager;

    [SerializeField]
    ParticleManager particleManager;

    float points;

    private void Start()
    {
        SetValuesBeggin();
        foreach (var item in enemiesList)
            item.OnHoldEnemy();
    }

    void Update()
    {
        if (player.GetPlayerIsActive())
        {
            time += Time.deltaTime;
            if (time >= timeRespawn)
            {
                CallEnemies();
                time = 0;
            }
        }
    }
    private void CallEnemies()
    {
        bool callingEnemy = false;
        while(!callingEnemy)
        {
            currentEnemy = UnityEngine.Random.Range(0, enemiesList.Count - 1);

            if (!enemiesList[currentEnemy].IsActive() && gameManager.GetLevel() >= enemiesList[currentEnemy].GetLEvel())
            {
                float xRandom = UnityEngine.Random.Range(-2.31f, 1.66f);
                Vector2 randomPosition = new Vector2(xRandom, enemiesList[currentEnemy].GetYPosition());
                enemiesList[currentEnemy].EnabledEnemy(randomPosition);
                callingEnemy = true;
            }
        }
       
    }
    public void CleaEnemy()
    {
        currentEnemy = 0;
        if (0.2f < timeRespawn)
            timeRespawn -= 0.1f;

        foreach (var item in enemiesList)
            StartCoroutine(item.DisabledEnemy());
    }
    private void SetValuesBeggin()
    {
        objectEnemyGet = GameObject.FindGameObjectsWithTag("Enemy");
        bloqueGetObject = GameObject.FindGameObjectsWithTag("Bloque");
        for (int i = 0; i < bloqueGetObject.Length; i++)
        {
            enemiesList.Add(bloqueGetObject[i].GetComponent<Enemy>());
            enemiesList[i].OnHoldEnemy();
        }
        for (int i = 0; i < objectEnemyGet.Length; i++)
        {
            enemiesList.Add(objectEnemyGet[i].GetComponent<Enemy>());
            enemiesList[i].OnHoldEnemy();
        }
    }

    public void GetValuePoint(int value,Vector2 position)
    {
        points += value;
        pointText.text = ((int)points).ToString();
        pointManager.CallNewPoint(position);
        particleManager.CallParticle(position);
    }
}
