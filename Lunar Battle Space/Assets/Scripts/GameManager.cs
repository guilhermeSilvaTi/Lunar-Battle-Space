using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Player player;

    private int level = 1;
    public int GetLevel() { return level; }

    float timeGame = 0;
    [SerializeField]
    float timeEndLevel = 40;

    bool stopLevel;

    [SerializeField]
    EnemiesManager enemiesManager;

    [SerializeField]
    TextMeshProUGUI textLevel;

    [SerializeField]
    TextMeshProUGUI textTime;

    private void Update()
    {
        if (!stopLevel)
        {
            timeGame += Time.deltaTime;
            textTime.text = timeGame.ToString();
            if (timeGame >= timeEndLevel)
            {
                timeGame = 0;
                StartCoroutine(NewLevel());
            }
        }
    }

    private IEnumerator NewLevel()
    {
        stopLevel = true;
        level++;
        timeGame = 0;
        enemiesManager.CleaEnemy();
        player.SetPlayerIsActive(false);
        textLevel.text = "Next  -Level " + level;
        yield return new WaitForSeconds(3.5f);
        textLevel.text = "";
        player.SetPlayerIsActive(true);
        stopLevel = false;
    }
}
