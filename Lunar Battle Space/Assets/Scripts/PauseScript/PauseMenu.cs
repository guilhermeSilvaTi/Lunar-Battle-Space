using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject windowsPause;

    [SerializeField]
    LoadLevel loadLevel;

    [SerializeField]
    Player player;

    float valueSound;

    [SerializeField]
    AudioSource music;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && player.GetPlayerIsActive())
            OpenMenu();     
    }

    private void OpenMenu()
    {  
        player.SetPlayerIsActive(false);
        windowsPause.SetActive(true);
        Time.timeScale = 0;
        valueSound = music.volume;
        music.volume = 0.1f;
    }

    public void CloseMenu()
    {
        windowsPause.SetActive(false);
        player.SetPlayerIsActive(true);    
        music.volume = valueSound;
        Time.timeScale = 1;
    }
    public void CallMenu()
    {
        loadLevel.newLevel("MainMenu");
        Time.timeScale = 1;
    }
}
