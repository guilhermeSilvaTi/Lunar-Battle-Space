using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesGame : MonoBehaviour
{
    private static bool activeGame;
    private static int level = 1;

    private static float volumeMusic = 0.5f;
    private static float volumeFX = 0.5f;


    public static void ResetGame()
    {
        activeGame = true;  
        level = 1;
    }
    public static int GetLevel() { return level; }
    public static void SetLevel(int value) { level = value; }
    public static float GetVolumeMusic() { return volumeMusic; }
    public static void SetVolumeMusic(float value) { volumeMusic = value; }
    public static float GetVolumeFX() { return volumeFX; }
    public static void SetVolumeFX(float value) { volumeFX = value; }  
    public static void SetActiveGame(bool value) { activeGame = value; }
    public static bool GetActiveGame() { return activeGame; }
}
