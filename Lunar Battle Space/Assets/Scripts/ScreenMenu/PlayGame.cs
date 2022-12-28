using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    [SerializeField]
    LoadLevel loadLevel;
    [SerializeField]
    string newLevel = "Game";
    [SerializeField]
    AudioSource playSound;

   public void PlayGameActive()
    {
        playSound.Play();
        loadLevel.newLevel(newLevel);
    }
}
