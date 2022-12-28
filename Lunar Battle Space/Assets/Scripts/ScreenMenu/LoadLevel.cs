using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    bool isActive;
    public void newLevel(string sceneLoad)
    {
        if (!isActive)
        {
            SceneManager.LoadSceneAsync(sceneLoad);
            isActive = true;
        }
    }
}
