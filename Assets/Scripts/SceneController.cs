using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void startCheck()
    {
        SceneManager.LoadScene("gameScene");
        AudioManager.instance.PlaySFX("clickeffect ");
    }

    // Home Button
    public void mainButton()
    {
        SceneManager.LoadScene("mainMenu");
        AudioManager.instance.PlaySFX("clickeffect ");
    }

    public void GameQuit()
    {
        Application.Quit();
        AudioManager.instance.PlaySFX("clickeffect ");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioManager.instance.PlaySFX("clickeffect ");
    }
}
