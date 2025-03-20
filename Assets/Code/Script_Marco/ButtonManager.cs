using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOver_Canvas;
    [SerializeField] private GameObject win_Canvas;

    private void Start()
    {
        gameOver_Canvas.SetActive(false);
        win_Canvas.SetActive(false);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.LogWarning("Quitting application");
        Application.Quit();
    }
}
