using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ResetGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ToMenu() {
        SceneManager.LoadScene(0);
    }

    public void Quit() {
        Application.Quit();
    }
}
