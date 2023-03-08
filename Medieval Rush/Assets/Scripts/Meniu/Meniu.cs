
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meniu : MonoBehaviour
{
    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
