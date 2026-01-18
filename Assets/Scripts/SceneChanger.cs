using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;
    public string nextSceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName: sceneName);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName: nextSceneName);
    }

}
