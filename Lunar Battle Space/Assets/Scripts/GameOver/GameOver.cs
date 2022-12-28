using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    bool isActive;

    [SerializeField]
    LoadLevel loadLevel;

    [SerializeField]
    GameObject gameOverScreen;

    private const string MAINMENU = "MainMenu";

    public IEnumerator EndGame()
    {
        if (!isActive)
        {
            isActive = true;          
            gameOverScreen.SetActive(true);
            yield return new WaitForSecondsRealtime(1.4f);
            loadLevel.newLevel(MAINMENU);
        }
    }
}
