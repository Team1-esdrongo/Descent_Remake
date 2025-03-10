using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Canvases")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject uiPlayer;

    [SerializeField] private KeyCode pauseKey;

    //[field : SerializeField] public Movement_Player Movement_Player { private set; get; }
    
    private bool _IsPaused;

    void Start()
    {
        pauseMenu.SetActive(false);
        uiPlayer.SetActive(true);
        MouseManager.LockMouse();
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (_IsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (_IsPaused)
        {

            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        uiPlayer.SetActive(false);
        //Movement_Player.enabled = false;
        Time.timeScale = 0.0f;
        _IsPaused = true;
        MouseManager.UnlockMouse();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        uiPlayer.SetActive(true);
        //Movement_Player.enabled = true;
        Time.timeScale = 1.0f;
        _IsPaused = false;
        MouseManager.LockMouse();
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1.0f;
        _IsPaused = false;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.LogWarning("Quitting application");
        Application.Quit();
    }
}
